using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace Dal
{
    public class UserDal
    {
        public bool Add(UserEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Insert into users (userID,userPwd,userName,userImage,userDes)  values(@userID,@userPwd,@userName,@userImage,@userDes)";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@userID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@userPwd", SqlDbType.VarChar, 50);
            param[1].Value = en.UserPwd;
            param[2] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            param[2].Value = en.UserName;
            param[3] = new SqlParameter("@userImage", SqlDbType.VarChar, 200);
            param[3].Value = en.UserImage;
            param[4] = new SqlParameter("@userDes", SqlDbType.VarChar, -1);
            param[4].Value = en.UserDes;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Update(UserEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Update users set ";
            int flag = 0;
            if (en.UserName == null)
            {
                en.UserName = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += " UserName=@UserName";
                    flag++;
                }
                else
                {
                    comstr += " ,UserName=@UserName";
                }
            }
            if (en.UserImage == null)
            {
                en.UserImage = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += " UserImage=@UserImage";
                    flag++;
                }
                else
                {
                    comstr += " ,UserImage=@UserImage";
                }
            }
            if (en.UserDes == null)
            {
                en.UserDes = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += " UserDes=@UserDes";
                    flag++;
                }
                else
                {
                    comstr += " ,UserDes=@UserDes";
                }
            }
            comstr += " where UserID=@UserID";
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param[1].Value = en.UserName;
            param[2] = new SqlParameter("@UserImage", SqlDbType.VarChar, 200);
            param[2].Value = en.UserImage;
            param[3] = new SqlParameter("@UserDes", SqlDbType.VarChar, -1);
            param[3].Value = en.UserDes;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool UpdateOverDate(UserEntity en, int day)
        {
            DataBase db = new DataBase();
            string comstr = "update   users set OverDate=OverDate+@Day where UserID=@UserID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@Day", SqlDbType.Int);
            param[1].Value = day;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool IsOverDate(UserEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select   count(*) from users where UserID=@UserID and OverDate>getdate() ";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@UserID", SqlDbType.VarChar, 50)
			};
            param[0].Value = en.UserID;
            return int.Parse(db.ExecuteValue(comstr, param)) > 0;
        }
        public bool Delete(UserEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Delete from users where UserID=@UserID";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@UserID", SqlDbType.VarChar, 50)
			};
            param[0].Value = en.UserID;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Update_Pwd(UserEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Update users set userpwd=@userpwd where UserID=@UserID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@userpwd", SqlDbType.VarChar, 50);
            param[1].Value = en.UserPwd;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Update_Integral(UserEntity en)
        {
            DataBase db = new DataBase();
            string sql = "update users set UserIntegral=@UserIntegral where UserID=@UserID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserIntegral", SqlDbType.Int);
            param[0].Value = en.UserIntegral;
            param[1] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[1].Value = en.UserID;
            return db.ExecuteSql(sql, param) > 0;
        }
        public bool Validate_Login(UserEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select count(*) from users where  userid=@UserID and userPwd=@UserPwd";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@UserPwd", SqlDbType.VarChar, 50);
            param[1].Value = en.UserPwd;
            int flag = Convert.ToInt32(db.ExecuteValue(comstr, param));
            return flag > 0;
        }
        public DataTable GetByID(UserEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select users.*,DepartmentName from users,Department where userid=@UserID  and users.DepartmentID= Department.DepartmentID";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@UserID", SqlDbType.VarChar, 50)
			};
            param[0].Value = en.UserID;
            return db.GetDataTable(comstr, param);
        }
        public DataTable GetAll()
        {
            DataBase db = new DataBase();
            string comstr = "select users.* from users where 1=1";
            return db.GetDataTable(comstr);
        }
        public void Asp(GridView gv, AspNetPager pager, UserEntity en)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param[1].Value = en.UserName;
            string comstr = "with UsersInfo as(select users.*,DepartmentName,Row_Number() over(order by UserID) as row_number from users,Department  where 1=1  and Department.DepartmentID=users.DepartmentID";
            string comstr2 = "select count(*) from users where 1=1 \t";
            if (en.UserID != null && en.UserID != "")
            {
                comstr += "  and UserID=@UserID";
                comstr2 += "  and UserID=@UserID";
            }
            if (en.UserName != null && en.UserName != "")
            {
                comstr += "  and UserName Like '%'+@UserName+'%'";
            }
            comstr += "  )select * from UsersInfo  where row_number>{0} and row_number<={1};";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }
        public void Asp(DataList gv, AspNetPager pager, UserEntity en)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param[1].Value = en.UserName;
            string comstr = "with UsersInfo as(select users.*,Row_Number() over(order by UserID) as row_number from users where 1=1 ";
            string comstr2 = "select count(*) from users where 1=1 \t";
            if (en.UserID != null && en.UserID != "")
            {
                comstr += "  and UserID=@UserID";
                comstr2 += "  and UserID=@UserID";
            }
            if (en.UserName != null && en.UserName != "")
            {
                comstr += "  and UserName Like '%'+@UserName+'%'";
                comstr2 += "  and UserName Like '%'+@UserName+'%'";
            }
            comstr += "  )select * from UsersInfo where row_number>{0} and row_number<={1};";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }
        public void Asp_Wrong(GridView gv, AspNetPager pager, UserEntity en)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param[1].Value = en.UserName;
            string comstr = "with UsersInfo as(select users.*,\r\n                             (\r\n                              select count(*) from RewardProblem where RewardProblem.UserID=users.UserID and RewardProblem.RecordState=1) as num,\r\n                                 Row_Number() over(order by users.UserID) as row_number from users where 1=1";
            string comstr2 = "select count(*) from users where 1=1 \t";
            if (en.UserID != null && en.UserID != "")
            {
                comstr += "  and UserID=@UserID";
                comstr2 += "  and UserID=@UserID";
            }
            if (en.UserName != null && en.UserName != "")
            {
                comstr += "  and UserName Like '%'+@UserName+'%'";
                comstr2 += "  and UserName Like '%'+@UserName+'%'";
            }
            comstr += "  )select * from UsersInfo where row_number>{0} and row_number<={1};";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }


        public void Asp_Holiday(GridView gv, AspNetPager pager, UserEntity en)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            param[0].Value = en.UserID;
            param[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param[1].Value = en.UserName;
            string comstr = "with UsersInfo as(select users.*,\r\n                             (\r\n                              select count(*) from UserHoliday where UserHoliday.UserID=users.UserID and UserHoliday.RecordState=1) as num,\r\n                                 Row_Number() over(order by users.UserID) as row_number from users where 1=1";
            string comstr2 = "select count(*) from users where 1=1 \t";
            if (en.UserID != null && en.UserID != "")
            {
                comstr += "  and UserID=@UserID";
                comstr2 += "  and UserID=@UserID";
            }
            if (en.UserName != null && en.UserName != "")
            {
                comstr += "  and UserName Like '%'+@UserName+'%'";
                comstr2 += "  and UserName Like '%'+@UserName+'%'";
            }
            comstr += "  )select * from UsersInfo where row_number>{0} and row_number<={1};";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }


        public bool Register(UserEntity en)
        {
            DataBase db = new DataBase();
            string sql = "Insert into users (userID,DepartmentID,userPwd,userName,userDes)  values(@userID,@departmentID,@userPwd,@userName,@userDes)";
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@UserID", SqlDbType.VarChar, 50);
            p[0].Value = en.UserID;

            p[1] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            p[1].Value = en.UserName;
            p[2] = new SqlParameter("@UserPwd", SqlDbType.VarChar, 50);
            p[2].Value = en.UserPwd;
            p[3] = new SqlParameter("@UserDes", SqlDbType.VarChar, 500);
            p[3].Value = en.UserDes;
            p[4] = new SqlParameter("@departmentID", SqlDbType.Int, 4);
            p[4].Value = en.DepartmentID;
            int b = db.ExecuteSql(sql, p);
            return b > 0;
        }
    }
}
