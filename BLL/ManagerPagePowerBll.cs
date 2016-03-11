using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Dal;
using System.Data;
namespace BLL
{
    public class ManagerPagePowerBll
    {
        private ManagerPagePowerDal dal = new ManagerPagePowerDal();
        public DataTable GetByID(ManagerPagePowerEnitity en)
        {
            return this.dal.GetByID(en);
        }
        public DataTable GetByManager(ManagerPagePowerEnitity en)
        {
            return this.dal.GetByManager(en);
        }
        public DataTable GetAllByManager(ManagerPagePowerEnitity en)
        {
            return this.dal.GetAllByManager(en);
        }
        public DataTable GetByTeacher(ManagerPagePowerEnitity en, int i)
        {
            return this.dal.GetByManager(en, i);
        }
        public bool DeleteByManager(ManagerPagePowerEnitity en)
        {
            return this.dal.DeleteByManager(en);
        }
        public bool Add(ManagerPagePowerEnitity en)
        {
            return this.dal.Add(en);
        }
    }
}
