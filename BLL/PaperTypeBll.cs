using Dal;
using Model;
using System;
using System.Data;
namespace BLL
{
    public class PaperTypeBll
    {
        private PaperTypeDal dal = new PaperTypeDal();
        public bool Add(PaperTypeEntity en)
        {
            return this.dal.Add(en);
        }
        public DataTable GetAll(PaperTypeEntity en)
        {
            return this.dal.GetAll(en);
        }
        public bool Delete(PaperTypeEntity en)
        {
            return this.dal.Delete(en);
        }
        public bool Update(PaperTypeEntity en)
        {
            return this.dal.Update(en);
        }
    }
}
