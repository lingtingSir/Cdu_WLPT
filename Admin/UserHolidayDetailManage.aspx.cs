using BLL;
using Model;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class Admin_UserHolidayDetailManage : System.Web.UI.Page
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
        if (base.Request.QueryString["id"] == null || base.Request.QueryString["id"].ToString() == "")
        {
            base.Response.Redirect("AdminManager.aspx");
            return;
        }
        this.ViewState["id"] = base.Request.QueryString["id"].ToString();
        this.ShowView();
    }
    private void ShowView()
    {
        string text = base.Request.QueryString["type"].ToString();
        string a;
        if ((a = text) != null)
        {
            
            if (!(a == "2"))
            {
                return;
            }
            this.MultiView1.SetActiveView(this.view2);
            this.BindView2();
        }
    }
  
    private void BindView2()
    {
        UserHolidayDetailEntity UserHolidayDetailEntity = new UserHolidayDetailEntity();
        UserHolidayDetailBll UserHolidayDetailBll = new UserHolidayDetailBll();
        UserHolidayDetailEntity.DetailID = 0;
        UserHolidayDetailEntity.UserID = this.ViewState["id"].ToString();
        UserHolidayDetailBll.Asp(this.GridView2, this.AspNetPager2, UserHolidayDetailEntity);
        UserEntity userEntity = new UserEntity();
        UserBll userBll = new UserBll();
        userEntity.UserID = this.ViewState["id"].ToString();
        DataTable byID = userBll.GetByID(userEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            this.Label1.Text = byID.Rows[0]["UserName"].ToString();
            this.Label2.Text = byID.Rows[0]["UserIntegral"].ToString();
        }
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        this.BindView2();
    }
}