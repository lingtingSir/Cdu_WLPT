using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Dal
{
    public class ClientDal
    {
        DataBase db = new DataBase();
        public bool Validate_Login(ClientEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select count(*) from Client where  ClientID=@ClientID and ClientPwd=@ClientPwd";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ClientID", SqlDbType.VarChar, 50);
            param[0].Value = en.ClientID;
            param[1] = new SqlParameter("@ClientPwd", SqlDbType.VarChar, 50);
            param[1].Value = en.ClientPwd;
            int flag = Convert.ToInt32(db.ExecuteValue(comstr, param));
            return flag > 0;
        }
        public DataTable select(ClientEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select ClientName from Client where  ClientID=@ClientID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ClientID", SqlDbType.VarChar, 50);
            param[0].Value = en.ClientID;
            return db.GetDataTable(comstr, param);
        }
        public void Asp(GridView gv, AspNetPager pager, ClientEntity en)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ClientID", SqlDbType.VarChar, 50);
            param[0].Value = en.ClientID;
            param[1] = new SqlParameter("@ClientName", SqlDbType.VarChar, 100);
            param[1].Value = en.ClientName;
            /*row_number() over (order by '字段名')是
微软最新发布的MSSQL2005,对TSQL进行了小规模的加强 按照字段名进行排序，可以实现数据分页功能
             
             */
            string comstr = "with ClientInfo as\r\n(\r\nselect Client.ClientID,Client.DepartmentID,Client.PowerID,ClientName,ClientPwd,ClientImage,ClientDes\r\n ,Powers.PowerName,Department.DepartmentName\t,\r\nRow_Number() over(order by ClientID) as row_number\tfrom Client ,Powers,Department\r\nwhere\tClient.PowerID=powers.PowerID\tand Client.DepartmentID=Department.DepartmentID";

            //      string comstr = "with ClientInfo as\r\n(\r\nselect Client.ClientID,Client.DepartmentID,Client.PowerID,ClientName,ClientPwd,ClientImage,ClientDes\r\n,Powers.PowerName,Department.DepartmentName\t,\r\nRow_Number() over(order by ClientID) as row_number\tfrom Client,Powers,Department\r\nwhere\tClient.PowerID=powers.PowerID\tand Client.DepartmentID=Department.DepartmentID)";
            //   string comstr2 = "select count(*) from Client,Powers,Department\r\nwhere\tClient.PowerID=Powers.PowerID\t and Client.DepartmentID=Department.DepartmentID";

            string comstr2 = "select count(*)\tfrom Client\r\n";
           
            if (en.ClientID != "" && en.ClientID != null)
            {
                comstr += "   and ClientID=@ClientID";
                comstr2 += "  and ClientID=@ClientID";
            }
            if (en.ClientName != "" && en.ClientName != null)
            {
                comstr += "  and  ClientName Like '%'+@ClientName+'%'";
                comstr2 += "   and ClientName Like '%'+ClientName+'%'";

            }
            comstr += "  )select * from ClientInfo where row_number>{0} and row_number<={1};";


            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }
        public DataTable GetByID(ClientEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "select Client.ClientID,ClientName,ClientPwd,ClientImage,ClientDes\r\nfrom Client\r\nwhere ClientID=@ClientID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ClientID",SqlDbType.VarChar,500)
            };
            param[0].Value = en.ClientID;
            return db.GetDataTable(comstr, param);
        }
        public bool Update_Pwd(ClientEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "update Client set ClientPwd=@ClientPwd where ClientID=@ClientID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ClientID", SqlDbType.VarChar, 50);
            param[0].Value = en.ClientID;
            param[1] = new SqlParameter("@ClientPwd", SqlDbType.VarChar, 50);
            param[1].Value = en.ClientPwd;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Update(ClientEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "update Client set";
            int flag = 0;
           
            if (en.ClientName == null)
            {
                en.ClientName = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += "  ClientName=@ClientName";
                    flag++;
                }
                else
                {

                    comstr += " , ClientName=@ClientName";
                }

            }
            if (en.ClientImage == null)
            {
                en.ClientImage = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += " ClientImage=@ClientImage";
                    flag++;
                }
                else
                {
                    comstr += "  , ClientImage=@ClientImage";
                }
            }
            if (en.ClientDes == null)
            {
                en.ClientDes = "";
            }
            else
            {
                if (flag == 0)
                {
                    comstr += " ClientDes=@ClientDes";
                    flag++;
                }
                else
                {
                    comstr += "  ,  ClientDes =@ClientDes";
                }
            }
            comstr += " where ClientID=@ClientID";
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ClientID", SqlDbType.VarChar, 50);
            param[0].Value = en.ClientID;
            param[1] = new SqlParameter("@ClientName", SqlDbType.VarChar, 100);
            param[1].Value = en.ClientName;
            param[2] = new SqlParameter("@ClientImage", SqlDbType.VarChar, 500);
            param[2].Value = en.ClientImage;
            param[3] = new SqlParameter("@ClientDes", SqlDbType.VarChar, 500);
            param[3].Value = en.ClientDes;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Add(ClientEntity en)
        {
            DataBase db = new DataBase();
            string comstr = "Insert into Client (ClientID,ClientName,ClientPwd,ClientImage,ClientDes)values(@ClientID,,@ClientName,@ClientPwd,@ClientImage,@ClientDes)";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ClientID", SqlDbType.VarChar, 50);
            param[0].Value = en.ClientID;
       
            param[1] = new SqlParameter("@ClientName", SqlDbType.VarChar, 100);
            param[1].Value = en.ClientName;
            param[2] = new SqlParameter("@ClientPwd", SqlDbType.VarChar, 50);
            param[2].Value = en.ClientPwd;
            param[3] = new SqlParameter("@ClientImage", SqlDbType.VarChar, 500);
            param[3].Value = en.ClientImage;
            param[4] = new SqlParameter("@ClientDes", SqlDbType.VarChar, 500);
            param[4].Value = en.ClientDes;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Register(ClientEntity en)
        {
            DataBase db = new DataBase();
            string sql = "Insert into Client (ClientID,ClientName,ClientPwd,ClientDes)  values(@clientID,@ClientName,@clientPwd,@clientDes)";
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@ClientID", SqlDbType.VarChar, 50);
            p[0].Value = en.ClientID;

            p[1] = new SqlParameter("@ClientPwd", SqlDbType.VarChar, 50);
            p[1].Value = en.ClientPwd;
            p[2] = new SqlParameter("@ClientDes", SqlDbType.VarChar, 256);
            p[2].Value = en.ClientDes;
            p[3] = new SqlParameter("@ClientName", SqlDbType.VarChar, 256);
            p[3].Value = en.ClientName;
         
            int b = db.ExecuteSql(sql, p);
            return b > 0;
        }
    }
}
