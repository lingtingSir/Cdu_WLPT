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
    public class ManagerBll
    {
        private ManagerDal dal = new ManagerDal();
        public bool Validate_Login(ManagerEnitity en)
		{
			return this.dal.Validate_Login(en);
		}
        public DataTable select(ManagerEnitity en)
        {
            return this.dal.select(en);
        }
         public void Asp(GridView gv, AspNetPager pager, ManagerEnitity en)
         {
              this.dal.Asp(gv,pager,en);
         }
         public DataTable GetByID(ManagerEnitity en)
         {
             return this.dal.GetByID(en);
         }
         public bool Update_Pwd(ManagerEnitity en)
         {
             return this.dal.Update_Pwd(en);
         }
         public bool Update(ManagerEnitity en)
         {
             return this.dal.Update(en);
         }
         public bool Add(ManagerEnitity en)
         {
             return this.dal.Add(en);
         }
    }
}
