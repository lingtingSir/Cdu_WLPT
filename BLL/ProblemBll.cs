using Dal;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    public class ProblemBll
    {
        private ProblemDal dal = new ProblemDal();
        public bool Add(ProblemEntity en)
        {
            return this.dal.Add(en);
        }
        public bool AddBasic(ProblemEntity en)
        {
            return this.dal.AddBasic(en);
        }
        public bool Add_Read(ProblemEntity en)
        {
            return this.dal.Add_Read(en);
        }
        public bool Update(ProblemEntity en)
        {
            return this.dal.Update(en);
        }
        public bool UpdateCourse(ProblemEntity en)
        {
            return this.dal.UpdateCourse(en);
        }
        public bool Delete(ProblemEntity en)
        {
            return this.dal.Delete(en);
        }
        public string DeleteProc(ProblemEntity en)
        {
            return this.dal.DeleteProc(en);
        }
        public DataTable GetByID(ProblemEntity en)
        {
            return this.dal.GetByID(en);
        }
        public void Asp(GridView gv, AspNetPager pager, ProblemEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public void Asp(DataList gv, AspNetPager pager, ProblemEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public int GetProblemCountByCourseAndType(ProblemEntity en)
        {
            return this.dal.GetProblemCountByCourseAndType(en);
        }
        public int GetProblemCountByCourseAndType(ProblemEntity en, string flag1, string flag2)
        {
            return this.dal.GetProblemCountByCourseAndType(en, flag1, flag2);
        }
        public int GetProblemCountByCourseAndTypeTest(ProblemEntity en, string flag1, string flag2)
        {
            return this.dal.GetProblemCountByCourseAndTypeTest(en, flag1, flag2);
        }
    }
}
