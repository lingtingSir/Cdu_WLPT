using Dal;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    public class UserBll
    {
        private UserDal dal = new UserDal();
        public bool Add(UserEntity en)
        {
            return this.dal.Add(en);
        }
        public bool Update(UserEntity en)
        {
            return this.dal.Update(en);
        }
        public bool Delete(UserEntity en)
        {
            return this.dal.Delete(en);
        }
        public bool Update_Pwd(UserEntity en)
        {
            return this.dal.Update_Pwd(en);
        }
        public bool UpdateOverDate(UserEntity en, int day)
        {
            return this.dal.UpdateOverDate(en, day);
        }
        public bool IsOverDate(UserEntity en)
        {
            return this.dal.IsOverDate(en);
        }
        public bool Validate_Login(UserEntity en)
        {
            return this.dal.Validate_Login(en);
        }
        public DataTable GetByID(UserEntity en)
        {
            return this.dal.GetByID(en);
        }
        public DataTable GetAll()
        {
            return this.dal.GetAll();
        }
        public void Asp(GridView gv, AspNetPager pager, UserEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public void Asp(DataList gv, AspNetPager pager, UserEntity en)
        {
            this.dal.Asp(gv, pager, en);
        }
        public bool Update_Integral(UserEntity en)
        {
            return this.dal.Update_Integral(en);
        }
        public void Asp_Wrong(GridView gv, AspNetPager pager, UserEntity en)
        {
            this.dal.Asp_Wrong(gv, pager, en);
        }
        public bool Register(UserEntity en)
        {
            return this.dal.Register(en);
        }
        public void Asp_Holiday(GridView gv, AspNetPager pager, UserEntity en)
        {
            this.dal.Asp_Holiday(gv, pager, en);
        }
    }
}
