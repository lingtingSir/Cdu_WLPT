using BLL;
using Model;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class Admin_UserIntegralManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadData("", "");
        }
    }
    private void LoadData(string userid, string username)
    {
        UserEntity userEntity = new UserEntity();
        UserBll userBll = new UserBll();
        userEntity.UserID = userid;
        userEntity.UserName = username;
        userBll.Asp_Wrong(this.GridView1, this.AspNetPager1, userEntity);
    }
    private void LoadPage()
    {
        if (this.dropSearch.SelectedValue == "1")
        {
            this.LoadData(this.txtSearch.Text.Trim(), "");
            return;
        }
        this.LoadData("", this.txtSearch.Text.Trim());
    }
    protected void btSearch_Click1(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void lbCheck_Command(object sender, CommandEventArgs e)
    {
        base.Response.Redirect("UserIntegralDetailManage.aspx?id=" + e.CommandArgument + "&type=1");
    }
    protected void lbDetail_Command(object sender, CommandEventArgs e)
    {
        base.Response.Redirect("UserIntegralDetailManage.aspx?id=" + e.CommandArgument + "&type=2");
    }
}