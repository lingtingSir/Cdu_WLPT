using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using Wuqi.Webdiyer;
using System.Web.UI.WebControls;
namespace Dal
{
    public class RecordDal
    {
        private DataBase db = new DataBase();
        public bool AddRecordProblem(RecordEntity en)
        {
            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@PPID", SqlDbType.Int);
            p[0].Value = en.PpID;
            p[1] = new SqlParameter("@PresentDate", SqlDbType.DateTime);
            p[1].Value = en.PresentDate;
            p[2] = new SqlParameter("@Des", SqlDbType.VarChar, 1000);
           
            if (en.Des != null)
            {
                p[2].Value = en.Des;
            }
            else
            {
                p[2].Value = "";
            }

            string sql = "insert into Record (PPIDD,PresentDate,Des) values(@PPID,@PresentDate,@Des)";
            return this.db.ExecuteSql(sql, p) > 0;
        }

        public void Asp(GridView gv, AspNetPager pager, RecordEntity en)
        {
            SqlParameter[] p = new SqlParameter[]
			{
				new SqlParameter("@PPID", SqlDbType.Int)
			};
            p[0].Value = en.PpID;
            string sql = "with AllRecord as( select RecordID,PPIDD,PresentDate,Des,ProjectPaper.Name,Row_Number() over(order by RecordID) as row_number from Record,ProjectPaper where PPIDD=@PPID and PPID=PPIDD )  select  *  from AllRecord where  row_number>{0} and row_number<={1}";
            string sql2 = "select count (*) from Record where PPIDD=@PPID";
            sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(this.db.ExecuteValue(sql2, p));
            gv.DataSource = this.db.GetDataTable(sql, p);
            gv.DataBind();
        }
        public DataTable GetById(RecordEntity en)
        {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@RecordID", SqlDbType.Int, 4)
			};
            param[0].Value = en.RecordID;
            string sql = "select Record.* from Record where RecordID=@RecordID ";
            return db.GetDataTable(sql, param);
        }
        public bool Update(RecordEntity en)
        {
            string sql = "update Record set Des=@Des,PresentDate=@PresentDate where RecordID=@RecordID";
            SqlParameter[] para = new SqlParameter[3];

            para[0] = new SqlParameter("@RecordID", SqlDbType.Int);
            para[0].Value = en.RecordID;
            para[1] = new SqlParameter("@PresentDate", SqlDbType.DateTime);
            para[1].Value = en.PresentDate;
            para[2] = new SqlParameter("@Des", SqlDbType.VarChar,1000);
            para[2].Value = en.Des;

          
            return this.db.ExecuteSql(sql, para) == 1;
        }
    }
}
