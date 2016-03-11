using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace Dal
{
    public class UserIntegralDetailDal
    {
        public bool Add(UserIntegralDetailEntity mo)
        {
            DataBase db = new DataBase();
            string sql = "insert into UserIntegralDetail(UserID,IntegralChange,ChangeDes) values(@UserID,@IntegralChange,@ChangeDes)";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = mo.UserID;
            param[1] = new SqlParameter("@IntegralChange", SqlDbType.Int);
            param[1].Value = mo.IntegralChange;
            param[2] = new SqlParameter("@ChangeDes", SqlDbType.VarChar, 1000);
            param[2].Value = mo.ChangeDes;
            return db.ExecuteSql(sql, param) > 0;
        }
        public bool Update(UserIntegralDetailEntity mo)
        {
            DataBase db = new DataBase();
            string sql = "update UserIntegralDetail set UserID=@UserID,IntegralChange=@IntegralChange,ChangeDes=@ChangeDes where DetailID=@DetailID";
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = mo.UserID;
            param[1] = new SqlParameter("@IntegralChange", SqlDbType.Int);
            param[1].Value = mo.IntegralChange;
            param[2] = new SqlParameter("@ChangeDes", SqlDbType.VarChar, 1000);
            param[2].Value = mo.ChangeDes;
            param[3] = new SqlParameter("@DetailID", SqlDbType.Int);
            param[3].Value = mo.DetailID;
            return db.ExecuteSql(sql, param) > 0;
        }
        public bool Delete(UserIntegralDetailEntity mo)
        {
            DataBase db = new DataBase();
            string sql = "delete from UserIntegralDetail where DetailID=@DetailID";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@DetailID", SqlDbType.Int)
			};
            param[0].Value = mo.DetailID;
            return db.ExecuteSql(sql, param) > 0;
        }
        public DataTable GetAll()
        {
            DataBase db = new DataBase();
            string sql = "select * from UserIntegralDetail";
            return db.GetDataTable(sql);
        }
        public DataTable GetByID(UserIntegralDetailEntity mo)
        {
            DataBase db = new DataBase();
            string sql = "select ui.DetailID as DetailID,ui.UserID as UserID,ui.IntegralChange as IntegralChange,ui.ChangeDes as ChangeDes,us.UserName as UserName from UserIntegralDetail ui,Users us where ui.UserID=us.UserID";
            if (mo.DetailID != 0)
            {
                sql += " and ui.DetailID=@DetailID";
            }
            if (mo.UserID != null && mo.UserID != "")
            {
                sql += " and ui.UserID=@UserID";
            }
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DetailID", SqlDbType.Int);
            param[0].Value = mo.DetailID;
            param[1] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[1].Value = mo.UserID;
            return db.GetDataTable(sql, param);
        }
        public void Asp(GridView gv, AspNetPager pager, UserIntegralDetailEntity mo)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DetailID", SqlDbType.Int);
            param[0].Value = mo.DetailID;
            param[1] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[1].Value = mo.UserID;
            string comstr = "with IntegralInfo as\r\n           (\r\n            select ui.DetailID as DetailID,ui.UserID as UserID,ui.IntegralChange as IntegralChange,ui.ChangeDes as ChangeDes,us.UserName as UserName,Row_Number() over(order by DetailID) as row_number from UserIntegralDetail ui,Users us where ui.UserID=us.UserID";
            string comstr2 = "select count(*) from UserIntegralDetail ui,Users us where ui.UserID=us.UserID";
            if (mo.DetailID != 0)
            {
                comstr += " and ui.DetailID=@DetailID";
                comstr2 += " and ui.DetailID=@DetailID";
            }
            if (mo.UserID != null && mo.UserID != "")
            {
                comstr += " and ui.UserID=@UserID";
                comstr2 += " and ui.UserID=@UserID";
            }
            comstr += " ) select * from IntegralInfo where row_number>{0} and row_number<{1}";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }
    }
}
