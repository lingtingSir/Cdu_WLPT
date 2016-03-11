using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;

namespace Dal
{
    public class PageDal
    {
        public DataTable GetByUrl(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select p.pageDes    from pages p  where p.PageUrl=@PageUrl";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@PageUrl", SqlDbType.VarChar, 200)
			};
            param[0].Value = en.PageURL;
            return db.GetDataTable(comstr, param);
        }
        public DataTable GetByParent(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select p.pageDes,p.id,p.pagesort,p.parentid,p.pid,p.pagename,p.pageurl ,(select count(*) from pages pp where pp.parentid=p.id )as ChildCount   from pages p  where p.parentid=@ParentID order by p.pagesort";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ParentID",SqlDbType.Int,4)
            };
            param[0].Value=en.ParentID;
            return db.GetDataTable(comstr,param);
        }
        public DataTable GetByID(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select p.pageDes,p.id,p.pagesort,p.parentid,p.pid,p.pagename,p.pageurl   from pages p  where p.id=@ID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",SqlDbType.Int,4)

            };
            param[0].Value = en.Id;
            return db.GetDataTable(comstr, param);
        }
        public int GetMaxSort(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select max(pagesort) from pages where parentid=@ParentID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ParentID",SqlDbType.Int,4)
            };
            param[0].Value = en.ParentID;
            string str = db.ExecuteValue(comstr, param);
            int result;
            if(str.Length>0)
            {
                result = int.Parse(str) + 1;
            }
            else
            {
                result = 1;
            }
            return result;
           
        }
        public bool Add(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "insert into Pages(PageSort,ParentID,PID,PageName,PageUrl) values(@PageSort,@ParentID,@PID,@PageName,@PageUrl)";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@PageSort", SqlDbType.Int, 4);
            param[0].Value = en.PageSort;
            param[1] = new SqlParameter("@ParentID", SqlDbType.Int);
            param[1].Value = en.ParentID;
            param[2] = new SqlParameter("@PageName", SqlDbType.VarChar, 100);
            param[2].Value = en.PageName;
            param[3] = new SqlParameter("@PageUrl", SqlDbType.VarChar, 200);
            param[3].Value = en.PageURL;
            param[4] = new SqlParameter("@PID", SqlDbType.Int);
            param[4].Value = en.PID;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Update(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "update Pages set pagename=@pagename,pageurl=@pageurl where id=@ID";
            SqlParameter[] param = new SqlParameter[4];
            param[2] = new SqlParameter("@PageName", SqlDbType.VarChar, 100);
            param[2].Value = en.PageName;
            param[0] = new SqlParameter("@PageUrl", SqlDbType.VarChar, 200);
            param[0].Value = en.PageURL;
            param[1]= new SqlParameter("@ID",SqlDbType.Int,4);
            param[1].Value = en.Id;
            param[3] = new SqlParameter("@PageSort",SqlDbType.Int,4);
            param[3].Value = en.PageSort;
            bool result;
            if(db.ExecuteSql(comstr,param)>0)
            {
                this.Update_Sort(en);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public bool Update_Sort(PagesEnitity en)
        {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PageSort", SqlDbType.Int, 4);
            param[0].Value = en.PageSort;
            param[1] = new SqlParameter("@ID", SqlDbType.Int, 4);
            param[1].Value = en.Id;
            string comstr = "Update Pages set PageSort=@PageSort where id=@ID  ";
            comstr += "update pages set pid=@pageSort where parentid=@ID  ";
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool Delete(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "delete Pages where id=@ID";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
            param[0].Value = en.Id;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public int GetChildCount(PagesEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select count(*) from pages where parentid=@ID";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",SqlDbType.Int,4)
            };
            param[0].Value=en.Id;
            string str=db.ExecuteValue(comstr,param);
            int result;
            if(str.Length>0)
            {
                result=int.Parse(str);
            }
            else{
                result=0;

            }
            return result;
        }
        public bool Update_Des(PagesEnitity en)
        {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PageDes",SqlDbType.VarChar,200);
            param[0].Value = en.PageDes;
            param[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            param[0].Value = en.Id;
            string comstr = "update Pages set PageDes=@PageDes where id=@ID";
            return db.ExecuteSql(comstr, param) > 0;
        }
    }
}
