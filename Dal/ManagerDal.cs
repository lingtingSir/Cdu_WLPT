using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace Dal
{
    public class ManagerDal
    {
        DataBase db = new DataBase();
        public bool Validate_Login(ManagerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select count(*) from Manager where  ManagerID=@ManagerID and ManagerPwd=@ManagerPwd";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ManagerID", SqlDbType.VarChar, 50);
            param[0].Value = en.ManagerID;
            param[1] = new SqlParameter("@ManagerPwd", SqlDbType.VarChar, 50);
            param[1].Value = en.ManagerPwd;
            int flag = Convert.ToInt32(db.ExecuteValue(comstr, param));
            return flag > 0;
        }
        public DataTable select(ManagerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select ManagerName from Manager where  ManagerID=@ManagerID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ManagerID", SqlDbType.VarChar, 50);
            param[0].Value = en.ManagerID;
            return db.GetDataTable(comstr, param);
        }
        public void Asp(GridView gv,AspNetPager pager, ManagerEnitity en)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ManagerID",SqlDbType.VarChar,50);
            param[0].Value = en.ManagerID;
            param[1] = new SqlParameter("@DepartmentID",SqlDbType.Int,4);
            param[1].Value = en.DepartmentID;
            param[2] = new SqlParameter("@PowerID",SqlDbType.Int,4);
            param[2].Value = en.PowerID;
            param[3] = new SqlParameter("@ManagerName",SqlDbType.VarChar,100);
            param[3].Value = en.ManagerName;
            /*row_number() over (order by '字段名')是
微软最新发布的MSSQL2005,对TSQL进行了小规模的加强 按照字段名进行排序，可以实现数据分页功能
             
             */
            string comstr = "with ManagerInfo as\r\n(\r\nselect Manager.ManagerID,Manager.DepartmentID,Manager.PowerID,ManagerName,ManagerPwd,ManagerImage,ManagerDes\r\n ,Powers.PowerName,Department.DepartmentName\t,\r\nRow_Number() over(order by ManagerID) as row_number\tfrom Manager ,Powers,Department\r\nwhere\tManager.PowerID=powers.PowerID\tand Manager.DepartmentID=Department.DepartmentID";

      //      string comstr = "with ManagerInfo as\r\n(\r\nselect Manager.ManagerID,Manager.DepartmentID,Manager.PowerID,ManagerName,ManagerPwd,ManagerImage,ManagerDes\r\n,Powers.PowerName,Department.DepartmentName\t,\r\nRow_Number() over(order by ManagerID) as row_number\tfrom Manager,Powers,Department\r\nwhere\tManager.PowerID=powers.PowerID\tand Manager.DepartmentID=Department.DepartmentID)";
         //   string comstr2 = "select count(*) from Manager,Powers,Department\r\nwhere\tManager.PowerID=Powers.PowerID\t and Manager.DepartmentID=Department.DepartmentID";

            string comstr2 = "select count(*)\tfrom Manager ,Powers,Department\r\nwhere\tManager.PowerID=Powers.PowerID\tand Manager.DepartmentID=Department.DepartmentID";
            if(en.DepartmentID !=0)
            {
                comstr += "  and Manager.DepartmentID=@DepartmentID";
                comstr2 += "   and Manager.DepartmentID=@DepartmentID";
            }
            if(en.PowerID !=0)
            {
                comstr += "  and Manager.PowerID=@PowerID";
                comstr2 += "  and Manager.PowerID=@PowerID";
            }
            if(en.ManagerID!="" &&en.ManagerID!=null)
            {
                comstr += "   and ManagerID=@ManagerID";
                comstr2 += "  and ManagerID=@ManagerID";
            }
            if(en.ManagerName!="" &&en.ManagerName!=null)
            {
                comstr += "  and  ManagerName Like '%'+@ManagerName+'%'";
                comstr2 += "   and ManagerName Like '%'+ManagerName+'%'";

            }
            comstr += "  )select * from ManagerInfo where row_number>{0} and row_number<={1};";

            
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2,param));
            gv.DataSource =db.GetDataTable(comstr,param);
            gv.DataBind();
        }
        public DataTable GetByID(ManagerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select Manager.ManagerID,Manager.DepartmentID,Manager.PowerID,ManagerName,ManagerPwd,ManagerImage,ManagerDes\r\n,Powers.PowerName,Department.DepartmentName\tfrom Manager,Powers,Department\r\nwhere\tManager.PowerID=Powers.PowerID\tand Manager.DepartmentID=Department.DepartmentID\r\nand ManagerID=@ManagerID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ManagerID",SqlDbType.VarChar,500)
            };
            param[0].Value=en.ManagerID;
            return db.GetDataTable(comstr,param);
        }
        public bool Update_Pwd(ManagerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "update Manager set ManagerPwd=@ManagerPwd where ManagerID=@ManagerID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ManagerID", SqlDbType.VarChar, 50);
            param[0].Value = en.ManagerID;
            param[1] = new SqlParameter("@ManagerPwd", SqlDbType.VarChar, 50);
            param[1].Value = en.ManagerPwd;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Update(ManagerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "update Manager set";
            int flag = 0;
            if (en.DepartmentID != 0)
            {
                comstr += "  DepartmentID=@DepartmentID";
                flag++;
            }
            if (en.PowerID != 0)
            {
                if (flag == 0)
                {
                    comstr += "  PowerID=@PowerID";
                }
                else
                {
                    comstr += ",  PowerID=@PowerID";
                }
            }
            if (en.ManagerName == null)
            {
                en.ManagerName = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += "  ManagerName=@ManagerName";
                    flag++;
                }
                else
                {
  
                    comstr += " , ManagerName=@ManagerName";
                }

            }
            if (en.ManagerImage == null)
            {
                en.ManagerImage = ""; 
            }
            else{
                if(flag==0){
                    comstr += " ManagerImage=@ManagerImage";
                    flag++;
                }
                else{
                    comstr += "  , ManagerImage=@ManagerImage";
                }
            }
            if(en.ManagerDes==null){
                en.ManagerDes="";
            }
            else{
                if(flag==0){
                    comstr +=" ManagerDes=@ManagerDes";
                    flag++;
                }
                else{
                    comstr +="  ,  ManagerDes =@ManagerDes";
                }
            }
            comstr +=" where ManagerID=@ManagerID";
            SqlParameter[] param = new SqlParameter[6];
			param[0] = new SqlParameter("@ManagerID", SqlDbType.VarChar, 50);
			param[0].Value = en.ManagerID;
			param[1] = new SqlParameter("@DepartmentID", SqlDbType.Int, 4);
			param[1].Value = en.DepartmentID;
			param[2] = new SqlParameter("@PowerID", SqlDbType.Int, 4);
			param[2].Value = en.PowerID;
			param[3] = new SqlParameter("@ManagerName", SqlDbType.VarChar, 100);
			param[3].Value = en.ManagerName;
			param[5] = new SqlParameter("@ManagerImage", SqlDbType.VarChar, 500);
			param[5].Value = en.ManagerImage;
			param[4] = new SqlParameter("@ManagerDes", SqlDbType.VarChar, 500);
			param[4].Value = en.ManagerDes;
			return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Add(ManagerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "Insert into Manager (ManagerID,DepartmentID,PowerID,ManagerName,ManagerPwd,ManagerImage,ManagerDes)values(@ManagerID,@DepartmentID,@PowerID,@ManagerName,@ManagerPwd,@ManagerImage,@ManagerDes)";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ManagerID", SqlDbType.VarChar, 50);
            param[0].Value = en.ManagerID;
            param[1] = new SqlParameter("@DepartmentID", SqlDbType.Int, 4);
            param[1].Value = en.DepartmentID;
            param[2] = new SqlParameter("@PowerID", SqlDbType.Int, 4);
            param[2].Value = en.PowerID;
            param[3] = new SqlParameter("@ManagerName", SqlDbType.VarChar, 100);
            param[3].Value = en.ManagerName;
            param[4] = new SqlParameter("@ManagerPwd", SqlDbType.VarChar, 50);
            param[4].Value = en.ManagerPwd;
            param[5] = new SqlParameter("@ManagerImage", SqlDbType.VarChar, 500);
            param[5].Value = en.ManagerImage;
            param[6] = new SqlParameter("@ManagerDes", SqlDbType.VarChar, 500);
            param[6].Value = en.ManagerDes;
            return db.ExecuteSql(comstr, param) > 0;
        }
        
    }
}