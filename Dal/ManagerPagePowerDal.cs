using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
namespace Dal
{
    public class ManagerPagePowerDal
    {
        public bool Add(ManagerPagePowerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "Insert into ManagerPagePower(ManagerID,ID) values(@ManagerID,@ID)";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            param[0].Value = en.Id;
            param[1] = new SqlParameter("@ManagerID", SqlDbType.VarChar, 50);
            param[1].Value = en.ManagerID;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public bool DeleteByManager(ManagerPagePowerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "delete ManagerPagePower where ManagerID=@ManagerID";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@ManagerID", SqlDbType.VarChar, 50)
			};
            param[0].Value = en.ManagerID;
            return db.ExecuteSql(comstr, param) > 0;
        }
        public DataTable GetByID(ManagerPagePowerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select p.id,p.pagesort,p.parentid,p.pid,p.pagename,p.pageurl   from pages p ,ManagerPagePower tpp,Manager t where tpp.id=p.id and tpp.managerid=t.managerid and tpp.TPP_ID=@ID";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@TPP_ID", SqlDbType.Int, 4)
			};
            param[0].Value = en.Tpp_ID;
            return db.GetDataTable(comstr, param);
        }
        public DataTable GetByManager(ManagerPagePowerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select pagesort as id,pagename as title  ,pageurl as url,pid as ParentID from Managerpagepower tpp,pages p  where p.id=tpp.id   and tpp.Managerid=@ManagerID order by p.pagesort  ";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@ManagerID", SqlDbType.VarChar, 50)
			};
            param[0].Value = en.ManagerID;
            return db.GetDataTable(comstr, param);
        }
        public DataTable GetByManager(ManagerPagePowerEnitity en, int i)
        {
            DataBase db = new DataBase();
            string comstr = "select p.id,p.pagesort,p.parentid,p.pid,p.pagename,p.pageurl ,(select count(*) from pages pp where pp.parentid=p.id )as ChildCount ,tpp.Managerid   from Managerpagepower tpp,pages p  where p.id=tpp.id   and tpp.Managerid=@ManagerID and p.parentid=" + i + " order by p.pagesort   ";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@ManagerID", SqlDbType.VarChar, 50)
			};
            param[0].Value = en.ManagerID;
            return db.GetDataTable(comstr, param);
        }
        public DataTable GetAllByManager(ManagerPagePowerEnitity en)
        {
            DataBase db = new DataBase();
            string comstr = "select p.id,p.pagesort,p.parentid,p.pid,p.pagename,p.pageurl ,(select count(*) from pages pp where pp.parentid=p.id )as ChildCount ,tpp.managerid   from managerpagepower tpp,pages p  where p.id=tpp.id   and tpp.Managerid=@ManagerID order by p.pagesort   ";
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@ManagerID", SqlDbType.VarChar, 50)
			};
            param[0].Value = en.ManagerID;
            return db.GetDataTable(comstr, param);
        }
    }
}
