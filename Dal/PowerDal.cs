using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using Model;
using System.Data.SqlClient;

namespace Dal
{
    public class PowerDal
    {
        public DataTable GetAll()
        {
            DataBase db = new DataBase();
            string comstr = "select PowerID,PowerName,PowerDes from Powers";
            return db.GetDataTable(comstr);
        }
        public void Asp(GridView gv, AspNetPager pager)
        {
            DataBase db = new DataBase();
            string comstr = "with PowersInfo  as \r\n(\r\n\tselect *,Row_Number() over(order by PowerID ) as row_number from Powers \r\n)\r\nselect * from PowersInfo where row_number>{0} and row_number<={1}";
            string comstr2 = "select count(*) from Powers";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2));
            gv.DataSource = db.GetDataTable(comstr);
            gv.DataBind();
        }
        public DataTable GetByID(PowerEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select PowerID,PowerName,PowerDes from Powers where PowerID=@PowerID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("PowerID",SqlDbType.Int,4)
            };
            param[0].Value=en.PowerID;
            return db.GetDataTable(comstr,param);
            
        }
        public bool Delete(PowerEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Delete from Powers where PowerID=@PowerID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@PowerID",SqlDbType.Int,4)
            };
            param[0].Value=en.PowerID;
            return db.ExecuteSql(comstr,param)>0;
        }
        public bool Update(PowerEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "update Powers set ";
            int flag = 0;
            if (en.PowerName == null)
            {
                en.PowerName = "";
            }
            else
            {
                comstr += " PowerName=@PowerName";
                flag++;
            }
            if(en.PowerDes ==null)
            {
                en.PowerDes = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += " PowerDes=@PowerDes";

                }
                else
                {
                    comstr += "  ,PowerDes=@PowerDes";
                }
            }
            comstr += "where PowerID=@PowerID";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@PowerName",SqlDbType.VarChar,100);
            param[0].Value = en.PowerName;
            param[1] = new SqlParameter("@PowerDes", SqlDbType.VarChar, 500);
            param[1].Value = en.PowerDes;
            param[2] = new SqlParameter("@PowerID", SqlDbType.Int, 4);
            param[2].Value = en.PowerID;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Add(PowerEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "insert into Powers(PowerID,PowerName,PowerDes) values(@PowerID,@PowerName,@PowerDes)";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@PowerName", SqlDbType.VarChar, 100);
            param[0].Value = en.PowerName;
            param[1] = new SqlParameter("@PowerDes", SqlDbType.VarChar, 500);
            param[1].Value = en.PowerDes;
            param[2] = new SqlParameter("@PowerID", SqlDbType.Int, 4);
            param[2].Value = en.PowerID;
            return db.ExecuteSql(comstr, param) > 0;
        }
    }
}
