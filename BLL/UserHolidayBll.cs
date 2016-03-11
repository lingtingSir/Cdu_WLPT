using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using Dal;
namespace BLL
{
    public class UserHolidayBll
    {
        private UserHolidayDal dal = new UserHolidayDal();
        /*   public bool AddWrongProblem(RewardProblemEntity en)
           {
               return this.dal.AddWrongProblem(en);
           } */
        public bool DeleteWrongProblembyID(UserHolidayEntity en)
        {
            return this.dal.DeleteWrongProblembyID(en);
        }
        public void Asp(GridView gv, AspNetPager pager, UserHolidayEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public void Asp(GridView gv, AspNetPager pager)
        {
            this.dal.Asp(gv, pager);
        }

        public bool Add(UserHolidayEntity mo)
        {
            return this.dal.Add(mo);
        }

        public bool Update_Back(UserHolidayEntity mo)
        {
            return this.dal.Update_Back(mo);
        }

        public DataTable GetByID(UserHolidayEntity mo)
        {
            return this.dal.GetByID(mo);
        }
        public void Asp(DataList gv, AspNetPager pager, UserHolidayEntity mo)
        {
            this.dal.Asp(gv, pager, mo);
        }
        public void Asp2(DataList gv, AspNetPager pager, UserHolidayEntity mo)
        {
            this.dal.Asp2(gv, pager, mo);
        }
    }
}
