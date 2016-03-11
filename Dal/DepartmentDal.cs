using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Wuqi.Webdiyer;
namespace Dal
{
    public class DepartmentDal
    {
        public DataTable GetAll(){
            DataBase db = new DataBase();
            string comstr = "select DepartmentID,DepartmentName,DepartmentDes,X,Y,Z from Department";
            return db.GetDataTable(comstr);
        }
        public bool Add(DepartmentEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "insert into Department(DepartmentName,DepartmentDes) values (@DepartmentName,@DepartmentDes)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DepartmentName", SqlDbType.VarChar, 100);
            param[0].Value = en.DepartmentName;
            param[1] = new SqlParameter("@DepartmentDes", SqlDbType.VarChar, 500);
            param[1].Value = en.DepartmentDes;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Delete(DepartmentEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Delete from Department where DepartmentNameID=@DepartmentID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@DepartmentID",SqlDbType.Int,4)
            };
            param[0].Value = en.DepartmentID;
            return db.ExecuteSql(comstr, param)>0;
        }
        public void Asp(GridView gv, AspNetPager pager,DepartmentEntity en)
        {
            SqlParameter[] param=new SqlParameter[]
            {
                new SqlParameter("@DepartmentName",SqlDbType.VarChar,100)
            };
            param[0].Value=en.DepartmentName;
            DataBase db = new DataBase();

            string comstr = "with DepartmentsInfo as\r\n(select *,Row_Number() over(order by DepartmentID) as row_number from Department\twhere 1=1";

         //   string comstr="with DepartmentsInfo as\r\n(select *,Row_Number() over(order by DepartmentID) as row_number from Department\twhere 1=1";
            string comstr2 = "select count(*) from Department\twhere 1=1";

    //        string comstr2 = "select count(*) from Department\twhere 1=1";
            if(en.DepartmentName!=null &&en.DepartmentName!=""){
                comstr += "  and DepartmentName Like '%'+@DepartmentName+'%'";
                comstr2 += "  and DepartmentName Like '%'+@DepartmentName+'%'";
            }
           

            comstr += "  )select * from DepartmentsInfo where row_number>{0} and row_number<={1}";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount=Convert.ToInt32(db.ExecuteValue(comstr2,param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }
        public DataTable GetByID(DepartmentEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select DepartmentName,DepartmentDes,X,Y,Z from Department where DepartmentID=@DepartmentID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@DepartmentID",SqlDbType.Int,4)
            };
            param[0].Value=en.DepartmentID;
            return db.GetDataTable(comstr,param);
        }
        public bool Update(DepartmentEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Update Department set";
            int flag = 0;
            if (en.DepartmentName == null)
            {
                en.DepartmentName = "";
            }
            else
            {
                comstr += "  DepartmentName=@DepartmentName";
                flag++;
            }
            if (en.DepartmentDes == null)
            {
                en.DepartmentDes = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += " DepartmentDes=@DepartmentDes";
                    flag++;
                }
                else
                {
                    comstr += " ,DepartmentDes=@DepartmentDes";
                }
            }
            comstr += " where DepartmentID=@DepartmentID";
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@DepartmentName", SqlDbType.VarChar, 100);
            param[0].Value = en.DepartmentName;
            param[1] = new SqlParameter("@DepartmentDes", SqlDbType.VarChar, 500);
            param[1].Value = en.DepartmentDes;
            param[2] = new SqlParameter("@DepartmentID", SqlDbType.Int, 4);
            param[2].Value = en.DepartmentID;
            return db.ExecuteSql(comstr, param) > 0;
        }

       

    }
}
