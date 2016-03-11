using Dal;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    public class RewardProbelmBll
    {
        private RewardProblemDal dal = new RewardProblemDal();
     /*   public bool AddWrongProblem(RewardProblemEntity en)
        {
            return this.dal.AddWrongProblem(en);
        } */
        public bool DeleteWrongProblembyID(RewardProblemEntity en)
        {
            return this.dal.DeleteWrongProblembyID(en);
        }
        public void Asp(GridView gv, AspNetPager pager, RewardProblemEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public void Asp(GridView gv, AspNetPager pager)
        {
            this.dal.Asp(gv, pager);
        }
      
        public bool Add(RewardProblemEntity mo)
        {
            return this.dal.Add(mo);
        }
     
        public bool Update_Back(RewardProblemEntity mo)
        {
            return this.dal.Update_Back(mo);
        }
      
        public DataTable GetByID(RewardProblemEntity mo)
        {
            return this.dal.GetByID(mo);
        }
        public void Asp(DataList gv, AspNetPager pager, RewardProblemEntity mo)
        {
            this.dal.Asp(gv, pager, mo);
        }
        public void Asp2(DataList gv, AspNetPager pager, RewardProblemEntity mo)
        {
            this.dal.Asp2(gv, pager, mo);
        }
    }
}
