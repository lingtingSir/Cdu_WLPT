using Dal;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    public class ProjectPaperBll
    {
        public void Asp(GridView gv, AspNetPager pager, ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            dal.Asp(gv, pager, en);
        }
       public void Asp2(GridView gv, AspNetPager pager, ProjectPaperEntity en)
        {
           ProjectPaperDal dal = new ProjectPaperDal();
            dal.Asp2(gv, pager, en);
        
        }
         public void Asp5(GridView gv, AspNetPager pager, ProjectPaperEntity en)
       {
           ProjectPaperDal dal = new ProjectPaperDal();
           dal.Asp5(gv, pager, en);

       }



        public bool Add(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.Add(en);
        }

        public bool Add2(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.Add2(en);
        }

        public bool Delete(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.Delete(en);
        }
        public bool Update(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.Update(en);
        }
        public bool Update2(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.Update2(en);
        }
         public bool Update6(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.Update6(en);
        }
        

        public bool Update3(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.Update3(en);
        }
        public DataTable GetAll()
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.GetAll();
        }
        
       
        public DataTable GetProblemNum(ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            return dal.GetProblemNum(en);
        }
        public DataTable GetById(ProjectPaperEntity en)
        {
             ProjectPaperDal dal = new ProjectPaperDal();
             return dal.GetById(en);
        }
        public void Asp666(GridView gv, AspNetPager pager, ProjectPaperEntity en)
        {
            ProjectPaperDal dal = new ProjectPaperDal();
            dal.Asp666(gv, pager, en);
        }
    }
}
