using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model;
using Dal;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    public class DepartmentBll
    {
        DepartmentDal dal = new DepartmentDal();
        public DataTable GetAll()
        {
            return this.dal.GetAll();
        }
        public bool Add(DepartmentEntity en)
        {
            return this.dal.Add(en);
        }
        public bool Delete(DepartmentEntity en)
        {
            return this.dal.Delete(en);
        }
        public void Asp(GridView gv, AspNetPager pager, DepartmentEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
         public DataTable GetByID(DepartmentEntity en)
        {
            return this.dal.GetByID(en);
        }
         public bool Update(DepartmentEntity en)
         {
             return this.dal.Update(en);
         }
    }
}
