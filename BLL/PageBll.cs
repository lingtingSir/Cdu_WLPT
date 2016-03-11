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
    public class PageBll
    {
        PageDal dal = new PageDal();
        public DataTable GetByUrl(PagesEnitity en)
        {
            return this.dal.GetByUrl(en);
        }
        public DataTable GetByParent(PagesEnitity en)
        {
            return this.dal.GetByParent(en);
        }
        public bool Delete(PagesEnitity en)
        {
            return this.dal.Delete(en);
        }
        public DataTable GetByID(PagesEnitity en)
        {
            return this.dal.GetByID(en);
        }
        public int GetMaxSort(PagesEnitity en)
        {
            return this.dal.GetMaxSort(en);
        }
        public bool Add(PagesEnitity en)
        {
            return this.dal.Add(en);
        }
        public int GetChildCount(PagesEnitity en)
        {
            return this.dal.GetChildCount(en);
        }
        public bool Update(PagesEnitity en)
        {
            return this.dal.Update(en);
        }
         public bool Update_Des(PagesEnitity en)
        {
            return this.dal.Update_Des(en);
        }
        
    }
}
