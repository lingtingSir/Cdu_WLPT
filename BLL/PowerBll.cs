using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Dal;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    
    public  class PowerBll
    {
        PowerDal dal = new PowerDal();
        public DataTable GetAll()
        {
            return this.dal.GetAll();
        }
        public void Asp(GridView gv, AspNetPager pager)
        {
             this.dal.Asp(gv, pager);
        }
        public DataTable GetByID(PowerEntity en)
        {
            return this.dal.GetByID(en);
        }
        public bool Update(PowerEntity en)
        {
            return this.dal.Update(en);
        }
        public bool Delete(PowerEntity en)
        {
            return this.dal.Delete(en);
        }
        public bool Add(PowerEntity en)
        {
            return this.dal.Add(en);
        }
    }
}
