using Dal;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    public class UserIntegralDetailBll
    {
        private UserIntegralDetailDal dal = new UserIntegralDetailDal();
        public bool Add(UserIntegralDetailEntity mo)
        {
            return this.dal.Add(mo);
        }
        public bool Update(UserIntegralDetailEntity mo)
        {
            return this.dal.Update(mo);
        }
        public bool Delete(UserIntegralDetailEntity mo)
        {
            return this.dal.Delete(mo);
        }
        public DataTable GetAll()
        {
            return this.dal.GetAll();
        }
        public DataTable GetByID(UserIntegralDetailEntity mo)
        {
            return this.dal.GetByID(mo);
        }
        public void Asp(GridView gv, AspNetPager pager, UserIntegralDetailEntity mo)
        {
            this.dal.Asp(gv, pager, mo);
        }
    }
}
