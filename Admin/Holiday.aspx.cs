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

public partial class Admin_Holiday : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.IsQue();
    }
    private void IsQue()
    {
        if (this.Session["ManagerID"] == null && this.Session["ManagerID"].ToString() == "")
        {
            base.Response.Redirect("~/login.aspx");
            return;
        }
        this.BindDataList();
    }
    private void BindDataList()
    {
        RewardProblemEntity rewardProblemEntity = new RewardProblemEntity();
        RewardProbelmBll wrongProblemBll = new RewardProbelmBll();
        rewardProblemEntity.RecordState = 1;
        rewardProblemEntity.UserID = "";
        wrongProblemBll.Asp(this.DataList1, this.AspNetPager1, rewardProblemEntity);
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.BindDataList();
    }
}