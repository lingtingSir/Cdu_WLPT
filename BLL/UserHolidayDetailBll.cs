using Dal;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace BLL
{
    public class UserHolidayDetailBll
    {
        private UserHolidayDetailDal dal = new UserHolidayDetailDal();
        public bool Add(UserHolidayDetailEntity mo)
        {
            return this.dal.Add(mo);
        }
        public bool Update(UserHolidayDetailEntity mo)
        {
            return this.dal.Update(mo);
        }
        public bool Delete(UserHolidayDetailEntity mo)
        {
            return this.dal.Delete(mo);
        }
        public DataTable GetAll()
        {
            return this.dal.GetAll();
        }
        public DataTable GetByID(UserHolidayDetailEntity mo)
        {
            return this.dal.GetByID(mo);
        }
        public void Asp(GridView gv, AspNetPager pager, UserHolidayDetailEntity mo)
        {
            this.dal.Asp(gv, pager, mo);
        }
    }
}
