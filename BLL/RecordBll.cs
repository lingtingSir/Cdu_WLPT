using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Dal;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using System.Data;
namespace BLL
{
    public class RecordBll
    {
        private RecordDal dal = new RecordDal();
        public bool AddRewardProblem(RecordEntity en)
        {
            return this.dal.AddRecordProblem(en);
        }
        public void Asp(GridView gv, AspNetPager pager, RecordEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public DataTable GetById(RecordEntity en)
        {
          
            return dal.GetById(en);
        }
        public bool Update(RecordEntity en)
        {
            return dal.Update(en);
        }
    }
}
