using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace Dal
{
    public class ProjectPaperDal
    {
        private DataBase db = new DataBase();
        public void Asp(GridView gv, AspNetPager pager,ProjectPaperEntity en)
        {
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@PPID", SqlDbType.Int);
            para[0].Value = en.PPID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;
            para[2] = new SqlParameter("@PTID", SqlDbType.Int);
            para[2].Value = en.PTID;
            string comstr = "with ProjectPaperInfo  as \r\n(\r\n\tselect ProjectPaper.*,PTName,Row_Number() over(order by PPID ) as row_number from ProjectPaper,PaperType where 1=1 and PaperType.PTID=ProjectPaper.PTID";
            string comstr2 = "select count(*) from ProjectPaper where 1=1";
            if (en.PPID != 0)
            {
                comstr += " and PPID = @PPID";
                comstr2 += " and PPID = @PPID";
            }
            if (en.Name != null)
            {
                comstr += " and Name Like '%'+@Name+'%'";
                comstr2 += " and Name Like '%'+@Name+'%'";
            }
           
            comstr += ") select * from ProjectPaperInfo where row_number>{0} and row_number<={1};";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(this.db.ExecuteValue(comstr2, para));
            gv.DataSource = this.db.GetDataTable(comstr, para);
            gv.DataBind();
        }

        public void Asp666(GridView gv, AspNetPager pager, ProjectPaperEntity en)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PPID", SqlDbType.Int);
            para[0].Value = en.PPID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;
            para[2] = new SqlParameter("@PTID", SqlDbType.Int);
            para[2].Value = en.PTID;
            para[3] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            para[3].Value = en.DepartmentId;
;
            string comstr = "with ProjectPaperInfo  as \r\n(\r\n\tselect ProjectPaper.*,PTName,Row_Number() over(order by PPID ) as row_number from ProjectPaper,PaperType where 1=1 and PaperType.PTID=ProjectPaper.PTID and DepartmentID=@DepartmentID";
            string comstr2 = "select count(*) from ProjectPaper where 1=1";
            if (en.PPID != 0)
            {
                comstr += " and PPID = @PPID";
                comstr2 += " and PPID = @PPID";
            }
            if (en.Name != null)
            {
                comstr += " and Name Like '%'+@Name+'%'";
                comstr2 += " and Name Like '%'+@Name+'%'";
            }

            comstr += ") select * from ProjectPaperInfo where row_number>{0} and row_number<={1};";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(this.db.ExecuteValue(comstr2, para));
            gv.DataSource = this.db.GetDataTable(comstr, para);
            gv.DataBind();
        }

        public void Asp5(GridView gv, AspNetPager pager, ProjectPaperEntity en)
        {
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@PPID", SqlDbType.Int);
            para[0].Value = en.PPID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;
            para[2] = new SqlParameter("@PTID", SqlDbType.Int);
            para[2].Value = en.PTID;
            para[3] = new SqlParameter("@ClientID", SqlDbType.VarChar, 256);
            para[3].Value = en.ClientID;
            string comstr = "with ProjectPaperInfo  as \r\n(\r\n\tselect (case when State=2 then '已承接' else '未承接' end) as IsAccept,ProjectPaper.PPID,ProjectPaper.Name,ProjectPaper.FhdateTime,PTName,Row_Number() over(order by PPID ) as row_number from ProjectPaper,PaperType where 1=1 and PaperType.PTID=ProjectPaper.PTID  and ClientID=@ClientID";
            string comstr2 = "select count(*) from ProjectPaper where 1=1";
            if (en.PPID != 0)
            {
                comstr += " and PPID = @PPID";
                comstr2 += " and PPID = @PPID";
            }
            if (en.Name != null)
            {
                comstr += " and Name Like '%'+@Name+'%'";
                comstr2 += " and Name Like '%'+@Name+'%'";
            }

            comstr += ") select * from ProjectPaperInfo where row_number>{0} and row_number<={1};";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(this.db.ExecuteValue(comstr2, para));
            gv.DataSource = this.db.GetDataTable(comstr, para);
            gv.DataBind();
        }




        public void Asp2(GridView gv, AspNetPager pager, ProjectPaperEntity en)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PPID", SqlDbType.Int, 4);
            param[0].Value = en.PPID;

            string comstr = "with ProjectPaperInfo as\r\n(select ProjectPaper.Name,ProjectPaper.ProjectHead,Department.*  from ProjectPaper,Department  where   ProjectPaper.State =2  and ProjectPaper.DepartmentID=Department.DepartmentID  ";
            string comstr2 = "select count(*) from ProjectPaper ";
            if (en.PPID != 0 )
            {
                comstr += "  and ProjectPaper.PPID=@PPID     ";
                comstr2 += "   where  ProjectPaper.PPID=@PPID   ";
            }
            comstr += "  )select * from ProjectPaperInfo;";
            comstr = string.Format(comstr, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            DataBase db = new DataBase();
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(comstr2, param));
            gv.DataSource = db.GetDataTable(comstr, param);
            gv.DataBind();
        }


       





        public bool Add(ProjectPaperEntity en)
        {
            string sql = "insert into ProjectPaper(PTID,Name,ClientID,RegisterDate,OverDate,PPDesc) values (@PTID,@Name,@ClientID,@RegisterDate,@OverDate,@PPDesc)  ";
            SqlParameter[] para = new SqlParameter[6];

            para[0] = new SqlParameter("@PTID", SqlDbType.Int);
            para[0].Value = en.PTID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;


            para[2] = new SqlParameter("@RegisterDate", SqlDbType.DateTime);
            para[2].Value = en.RegisterDate;
            para[3] = new SqlParameter("@OverDate", SqlDbType.DateTime);
            para[3].Value = en.OverDate;

            para[4] = new SqlParameter("@PPDesc", SqlDbType.VarChar, 1024);
            para[4].Value = en.PPDesc;
            para[5] = new SqlParameter("@ClientID", SqlDbType.VarChar, 256);
            para[5].Value = en.ClientID;
            
            return  this.db.ExecuteSql(sql, para) == 1;
        }
        public bool Add2(ProjectPaperEntity en)
        {
            string sql = "insert into ProjectPaper(PTID,Name,RegisterDate,OverDate,PPDesc) values (@PTID,@Name,@RegisterDate,@OverDate,@PPDesc)  ";
            SqlParameter[] para = new SqlParameter[5];

            para[0] = new SqlParameter("@PTID", SqlDbType.Int);
            para[0].Value = en.PTID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;


            para[2] = new SqlParameter("@RegisterDate", SqlDbType.DateTime);
            para[2].Value = en.RegisterDate;
            para[3] = new SqlParameter("@OverDate", SqlDbType.DateTime);
            para[3].Value = en.OverDate;

            para[4] = new SqlParameter("@PPDesc", SqlDbType.VarChar, 1024);
            para[4].Value = en.PPDesc;
            

            return this.db.ExecuteSql(sql, para) == 1;
        }



        public bool Delete(ProjectPaperEntity en)
        {
            string sql = " delete from  ProjectPaper where PPID = @PPID ";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@PPID", SqlDbType.Int, 4)
			};
            para[0].Value = en.PPID;
            return this.db.ExecuteSql(sql, para) == 1;
        }
        public bool Update(ProjectPaperEntity en)
        {
            string sql = "update ProjectPaper set PTID=@PTID,Name=@Name,FhdateTime=@FhdateTime,PPDesc=@PPDesc where PPID=@PPID";
            SqlParameter[] para = new SqlParameter[5];
            
            para[0] = new SqlParameter("@PTID", SqlDbType.Int);
            para[0].Value = en.PTID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;

            para[2] = new SqlParameter("@FhdateTime", SqlDbType.DateTime);
            para[2].Value = en.FhdateTime;
            para[3] = new SqlParameter("@PPDesc", SqlDbType.VarChar, 1024);
            para[3].Value = en.PPDesc;
            
            para[4] = new SqlParameter("@PPID", SqlDbType.Int);
            para[4].Value = en.PPID;
            return this.db.ExecuteSql(sql, para) == 1;
        }

        public bool Update2(ProjectPaperEntity en)
        {
            string sql = "update ProjectPaper set PTID=@PTID,Name=@Name,FhdateTime=@FhdateTime where PPID=@PPID";
            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter("@PTID", SqlDbType.Int);
            para[0].Value = en.PTID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;

            para[2] = new SqlParameter("@FhdateTime", SqlDbType.DateTime);
            para[2].Value = en.FhdateTime;
           

            para[3] = new SqlParameter("@PPID", SqlDbType.Int);
            para[3].Value = en.PPID;
            return this.db.ExecuteSql(sql, para) == 1;
        }

        public bool Update6(ProjectPaperEntity en)
        {
            string sql = "update ProjectPaper set PTID=@PTID,Name=@Name,RegisterDate=@RegisterDate,OverDate=@OverDate,PPDesc=@PPDesc where PPID=@PPID";
            SqlParameter[] para = new SqlParameter[6];

            para[0] = new SqlParameter("@PTID", SqlDbType.Int);
            para[0].Value = en.PTID;
            para[1] = new SqlParameter("@Name", SqlDbType.VarChar, 256);
            para[1].Value = en.Name;

            para[2] = new SqlParameter("@RegisterDate", SqlDbType.DateTime);
            para[2].Value = en.RegisterDate;


            para[3] = new SqlParameter("@PPID", SqlDbType.Int);
            para[3].Value = en.PPID;
            para[4] = new SqlParameter("@OverDate", SqlDbType.DateTime);
            para[4].Value = en.OverDate;
            para[5] = new SqlParameter("@PPDesc", SqlDbType.VarChar, 5000);
            para[5].Value = en.PPDesc;
            return this.db.ExecuteSql(sql, para) == 1;
        }


        public bool Update3(ProjectPaperEntity en)
        {
            string sql = "update ProjectPaper set DepartmentID=@DepartmentID,ProjectHead=@ProjectHead,State=2 where PPID=@PPID";
            SqlParameter[] para = new SqlParameter[4];

            para[0] = new SqlParameter("@PTID", SqlDbType.Int);
            para[0].Value = en.PTID;
            para[1] = new SqlParameter("@DepartmentID", SqlDbType.Int);
            para[1].Value = en.DepartmentId;

            para[2] = new SqlParameter("@ProjectHead", SqlDbType.VarChar,256);
            para[2].Value = en.ProjectHead;
            para[3] = new SqlParameter("@PPID", SqlDbType.Int);
            para[3].Value = en.PPID;
          
            return this.db.ExecuteSql(sql, para) == 1;
        }

        public DataTable GetAll()
        {
            string sql = "select PPID,PRKID,PTID,Name,PICPath,SelfResource,UpdateTime,PPDesc,ProblemNum from ProblemPaper";
            DataBase db = new DataBase();
            return db.GetDataTable(sql);
        }
        public DataTable GetProblemNum(ProjectPaperEntity en)
        {
            DataBase db = new DataBase();
            string sql = "select ProblemNum from ProblemPaper where PPID=@PPID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@PPID", SqlDbType.Int)
			};
            para[0].Value = en.PPID;
            return db.GetDataTable(sql, para);
        }
       
        public DataTable GetById(ProjectPaperEntity en)
        {
            DataBase db = new DataBase();
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@PPID", SqlDbType.Int, 4)
			};
            param[0].Value = en.PPID;
            string sql = "select ProjectPaper.*,PaperType.PTName from ProjectPaper,PaperType where PPID=@PPID and PaperType.PTID=ProjectPaper.PTID";
            return db.GetDataTable(sql, param);
        } 
        /*
        public DataTable GetPaperTypeByPRKID(ProjectPaperEntity en)
        {
            SqlParameter[] param = new SqlParameter[]
			{
				new SqlParameter("@PRKID", SqlDbType.Int)
			};
            param[0].Value = en.PRKID;
            string sql = "select distinct pt.* from ProblemPaper pp inner join PaperType pt on pt.PTID=pp.PTID where pp.PRKID=@PRKID  ";
            return this.db.GetDataTable(sql, param);
        }
        public DataTable GetPaperByPTIDAndPRKID(ProjectPaperEntity en)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PRKID", SqlDbType.Int);
            param[0].Value = en.PRKID;
            param[1] = new SqlParameter("@PTID", SqlDbType.Int);
            param[1].Value = en.PTID;
            string sql = "select pp.* from ProblemPaper pp where pp.PRKID=@PRKID and pp.PTID=@PTID";
            return this.db.GetDataTable(sql, param);
        }  */
    }
}
