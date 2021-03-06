﻿using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Dal
{
    public class UserHolidayDal
    {
        
        private DataBase db = new DataBase();
        public bool AddRewardProblem(UserHolidayEntity en)
        {
            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            p[0].Value = en.UserID;
            p[1] = new SqlParameter("@Des", SqlDbType.VarChar, 1000);
            p[1].Value = en.Des;
            p[2] = new SqlParameter("@ManagerBack", SqlDbType.VarChar, 1000);
            if (en.ManagerBack != null)
            {
                p[3].Value = en.ManagerBack;
            }
            else
            {
                p[3].Value = "";
            }
            string sql = "insert into UserHoliday (UserID,UserHolidayDes,ManagerBack) values(@UserID,@Des,@ManagerBack)";
            return this.db.ExecuteSql(sql, p) > 0;
        }
        public bool DeleteWrongProblembyID(UserHolidayEntity en)
        {
            SqlParameter[] p = new SqlParameter[]
			{
				new SqlParameter("@UserHolidayID", SqlDbType.Int, 4)
			};
            p[0].Value = en.UserHolidayID;
            string sql = "delete from UserHoliday where UserHolidayID=@UserHolidayID";
            return this.db.ExecuteSql(sql, p) > 0;
        }
        public void Asp(GridView gv, AspNetPager pager, UserHolidayEntity en)
        {
            SqlParameter[] p = new SqlParameter[]
			{
				new SqlParameter("@UserID", SqlDbType.VarChar, 50)
			};
            p[0].Value = en.UserID;
            string sql = "with AllUserProblem as( select UserHolidayID,UserHolidayDes,ManagerBack,DateUp,Row_Number() over(order by UserHolidayID) as row_number from UserHoliday where UserID=@UserID )  select  *  from AllUserProblem where  row_number>{0} and row_number<={1}";
            string sql2 = "select count (*) from WrongProblem where UserID=@UserID";
            sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(this.db.ExecuteValue(sql2, p));
            gv.DataSource = this.db.GetDataTable(sql, p);
            gv.DataBind();
        }
        public void Asp(GridView gv, AspNetPager pager)
        {
            string sql = "with AllWrongProblem as(select UserHolidayID,UserHolidayDes,ManagerBack,DateUp,UserID,Row_Number() over(order by UserHolidayID) as row_number from WrongProblem)select * from AllWrongProblem where row_number>{0} and row_number<={1}";
            string sql2 = "select count(*) from WrongProblem";
            sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(this.db.ExecuteValue(sql2));
            gv.DataSource = this.db.GetDataTable(sql);
            gv.DataBind();
        }


        public bool Add(UserHolidayEntity mo)
        {
            DataBase db = new DataBase();
            string sql = "insert into UserHoliday(UserID,UserHolidayDes,DateUp,RecordState) values(@UserID,@Des,@DateUp,@RecordState)";
            SqlParameter[] param = new SqlParameter[4];


            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = mo.UserID;
            param[1] = new SqlParameter("@Des", SqlDbType.VarChar, 1000);
            param[1].Value = mo.Des;

            param[2] = new SqlParameter("@DateUp", SqlDbType.DateTime);
            param[2].Value = mo.DateUp;
            param[3] = new SqlParameter("@RecordState", SqlDbType.Int);
            param[3].Value = mo.RecordState;
            return db.ExecuteSql(sql, param) > 0;
        }

        public bool Update_Back(UserHolidayEntity mo)
        {
            DataBase db = new DataBase();
            string sql = "update UserHoliday set ManagerBack=@ManagerBack,RecordState=@RecordState where UserHolidayID=@UserHolidayID";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@UserHolidayID", SqlDbType.Int);
            param[0].Value = mo.UserHolidayID;
            param[1] = new SqlParameter("@ManagerBack", SqlDbType.VarChar, 1000);
            param[1].Value = mo.ManagerBack;
            param[2] = new SqlParameter("@RecordState", SqlDbType.Int);
            param[2].Value = mo.RecordState;
            return db.ExecuteSql(sql, param) > 0;
        }

        public DataTable GetByID(UserHolidayEntity mo)
        {
            DataBase db = new DataBase();
            string sql = "select UserHoliday.*,Users.UserName as UserName from Users,UserHoliday where UserHoliday.UserID=Users.UserID ";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserHolidayID", SqlDbType.Int);
            param[0].Value = mo.UserHolidayID;
            param[1] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[1].Value = mo.UserID;
            if (mo.UserHolidayID != 0)
            {
                sql += " and UserHoliday.UserHolidayID=@UserHolidayID";
            }

            if (mo.UserID != null && mo.UserID != "")
            {
                sql += " and UserHoliday.UserID=@UserID";
            }
            return db.GetDataTable(sql, param);
        }
        public void Asp(DataList gv, AspNetPager pager, UserHolidayEntity mo)
        {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = mo.UserID;
            param[1] = new SqlParameter("@RecordState", SqlDbType.Int);
            param[1].Value = mo.RecordState;

            string comstr = "with UserHolidayInfo as\r\n           (\r\n             select UserHoliday.*,(case when RecordState=1  then '未读'  when RecordState=2  then '已读,认同加分'  else  '已读,不认同加分' end ) as  CheckState,Users.UserName as UserName,Row_Number() over(order by UserHolidayID) as row_number from Users,UserHoliday where UserHoliday.UserID=Users.UserID";

            //   string comstr = "with WrongProblemInfo as\r\n           (\r\n             select WrongProblem.*,(case when RecordState=1  then '教师未读'  when RecordState=2  then '教师已读,认同加分'  else  '教师已读,不认同加分' end ) as  CheckState,Problems.ProblemName as ProblemName,Problems.ProblemDes as ProblemDes,Users.UserName as UserName,Row_Number() over(order by WrongProblemID) as row_number from Problems,Users,WrongProblem where WrongProblem.UserID=Users.UserID and WrongProblem.ProblemID=Problems.ProblemID";
            string comstr2 = "select count(*) from  Users,UserHoliday where UserHoliday.UserID=Users.UserID ";
            if (mo.UserID != null && mo.UserID != "")
            {
                comstr += " and UserHoliday.UserID=@UserID";
                comstr2 += " and UserHoliday.UserID=@UserID";
            }
            if (mo.RecordState != 0)
            {
                comstr += " and UserHoliday.RecordState=@RecordState";
                comstr2 += " and UserHoliday.RecordState=@RecordState";
            }
            comstr += " )select * from UserHolidayInfo where row_number>{0} and row_number<={1}";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }

        public void Asp2(DataList gv, AspNetPager pager, UserHolidayEntity mo)
        {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = mo.UserID;


            string comstr = "with UserHolidayInfo as\r\n           (\r\n             select UserHoliday.*,(case when RecordState=1  then '未读'  when RecordState=2  then '已读,认同加分'  else  '已读,不认同加分' end ) as  CheckState,Users.UserName as UserName,ChangDes,Row_Number() over(order by UserHolidayID) as row_number from Users,UserHoliday,UserIntegraDetail where UserHoliday.UserID=Users.UserID,Users.UserID=UserIntegraDetail.UserID";

            //   string comstr = "with WrongProblemInfo as\r\n           (\r\n             select WrongProblem.*,(case when RecordState=1  then '教师未读'  when RecordState=2  then '教师已读,认同加分'  else  '教师已读,不认同加分' end ) as  CheckState,Problems.ProblemName as ProblemName,Problems.ProblemDes as ProblemDes,Users.UserName as UserName,Row_Number() over(order by WrongProblemID) as row_number from Problems,Users,WrongProblem where WrongProblem.UserID=Users.UserID and WrongProblem.ProblemID=Problems.ProblemID";
            string comstr2 = "select count(*) from  Users,UserHoliday where UserHoliday.UserID=Users.UserID ";
            if (mo.UserID != null && mo.UserID != "")
            {
                comstr += " and UserHoliday.UserID=@UserID";
                comstr2 += " and UserHoliday.UserID=@UserID";
            }

            comstr += " )select * from UserHolidayInfo where row_number>{0} and row_number<={1}";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }

    }
}

