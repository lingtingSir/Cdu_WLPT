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
    public class ClientBll
    {
        private ClientDal dal = new ClientDal();
        public bool Validate_Login(ClientEntity en)
        {
            return this.dal.Validate_Login(en);
        }
        public DataTable select(ClientEntity en)
        {
            return this.dal.select(en);
        }
        public void Asp(GridView gv, AspNetPager pager, ClientEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public DataTable GetByID(ClientEntity en)
        {
            return this.dal.GetByID(en);
        }
        public bool Update_Pwd(ClientEntity en)
        {
            return this.dal.Update_Pwd(en);
        }
        public bool Update(ClientEntity en)
        {
            return this.dal.Update(en);
        }
        public bool Add(ClientEntity en)
        {
            return this.dal.Add(en);
        }
        public bool Register(ClientEntity en)
        {
            return this.dal.Register(en);
        }
    }
}
