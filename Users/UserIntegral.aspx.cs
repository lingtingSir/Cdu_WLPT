using BLL;
using Model;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

public partial class Users_UserIntegral : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.IsQue();
        }
    }
    private void IsQue()
    {
        if (this.Session["UserID"] == null || this.Session["UserID"].ToString() == "")
        {
            base.Response.Redirect("~/Login1.aspx");
            return;
        }
        this.BindView1();
    }
    private void BindView1()
    {
        UserIntegralDetailEntity userIntegralDetailEntity = new UserIntegralDetailEntity();
        UserIntegralDetailBll userIntegralDetailBll = new UserIntegralDetailBll();
        userIntegralDetailEntity.UserID = this.Session["UserID"].ToString();
        userIntegralDetailEntity.DetailID = 0;
        userIntegralDetailBll.Asp(this.GridView1, this.AspNetPager1, userIntegralDetailEntity);
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.BindView1();
    }
}