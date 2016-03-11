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

public partial class Users_UserHolidayManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.IsQue();
    }
    private void IsQue()
    {
        if (this.Session["UserID"] == null && this.Session["UserID"].ToString() == "")
        {
            base.Response.Redirect("~/login_1.aspx");
            return;
        }
        this.BindDataList();
    }
    private void BindDataList()
    {
        UserHolidayEntity rewardProblemEntity = new UserHolidayEntity();
        UserHolidayBll wrongProblemBll = new UserHolidayBll();
        
        rewardProblemEntity.UserID = "";
        wrongProblemBll.Asp(this.DataList1, this.AspNetPager1, rewardProblemEntity);
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.BindDataList();
    }
}