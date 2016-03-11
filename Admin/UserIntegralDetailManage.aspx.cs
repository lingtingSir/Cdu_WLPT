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
public partial class Admin_UserIntegralDetailManage : System.Web.UI.Page
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
            base.Response.Redirect("UserIntegral_Manage.aspx");
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
            if (a == "1")
            {
                this.MultiView1.SetActiveView(this.view1);
                this.BindView1();
                return;
            }
            if (!(a == "2"))
            {
                return;
            }
            this.MultiView1.SetActiveView(this.view2);
            this.BindView2();
        }
    }
    private void BindView1()
    {
        RewardProblemEntity wrongProblemEntity = new RewardProblemEntity();
        RewardProbelmBll wrongProblemBll = new RewardProbelmBll();
        wrongProblemEntity.RecordState = 1;
        wrongProblemEntity.UserID = this.ViewState["id"].ToString();
        wrongProblemBll.Asp(this.DataList1, this.AspNetPager1, wrongProblemEntity);
        UserEntity userEntity = new UserEntity();
        UserBll userBll = new UserBll();
        userEntity.UserID = this.ViewState["id"].ToString();
        DataTable byID = userBll.GetByID(userEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            this.lblUserName.Text = byID.Rows[0]["UserName"].ToString();
            this.lblIntegral.Text = byID.Rows[0]["UserIntegral"].ToString();
        }
    }
    private void BindView2()
    {
        UserIntegralDetailEntity userIntegralDetailEntity = new UserIntegralDetailEntity();
        UserIntegralDetailBll userIntegralDetailBll = new UserIntegralDetailBll();
        userIntegralDetailEntity.DetailID = 0;
        userIntegralDetailEntity.UserID = this.ViewState["id"].ToString();
        userIntegralDetailBll.Asp(this.GridView2, this.AspNetPager2, userIntegralDetailEntity);
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
    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        UserEntity userEntity = new UserEntity();
        UserBll userBll = new UserBll();
        string userID = this.ViewState["id"].ToString();
        userEntity.UserID = userID;
        DataTable byID = userBll.GetByID(userEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            int num = int.Parse(byID.Rows[0]["UserIntegral"].ToString());
            userEntity.UserID = userID;
            userEntity.UserIntegral = num + 5;
            userBll.Update_Integral(userEntity);
            UserIntegralDetailEntity userIntegralDetailEntity = new UserIntegralDetailEntity();
            UserIntegralDetailBll userIntegralDetailBll = new UserIntegralDetailBll();
            userIntegralDetailEntity.UserID = userID;
            userIntegralDetailEntity.IntegralChange = 5;
            userIntegralDetailEntity.ChangeDes = "上报";
            userIntegralDetailBll.Add(userIntegralDetailEntity);
            RewardProblemEntity wrongProblemEntity = new RewardProblemEntity();
            RewardProbelmBll wrongProblemBll = new RewardProbelmBll();
            wrongProblemEntity.RewardProblemID = int.Parse(e.CommandArgument.ToString());
            wrongProblemEntity.ManagerBack = "谢谢您的上报，我们为您加5分";
            wrongProblemEntity.RecordState = 2;
            wrongProblemBll.Update_Back(wrongProblemEntity);
            base.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('谢谢您的上报，我们为您加5分');</script>");
            int num2 = int.Parse(this.lblIntegral.Text);
            this.lblIntegral.Text = (num2 + 5).ToString();
            return;
        }
        base.Response.Redirect("UserIntegral_Manage.aspx");
    }
 
    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        RewardProblemEntity wrongProblemEntity = new RewardProblemEntity();
        RewardProbelmBll wrongProblemBll = new RewardProbelmBll();
        wrongProblemEntity.RewardProblemID = int.Parse(e.CommandArgument.ToString());
        wrongProblemEntity.ManagerBack = "谢谢您的上报，我们不给你加分";
        wrongProblemEntity.RecordState = 3;
        wrongProblemBll.Update_Back(wrongProblemEntity);
        base.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('谢谢您的上报，我们不给你加分');</script>");
    }
    protected void Button3_Command(object sender, CommandEventArgs e)
    {
       
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.BindView1();
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        this.BindView2();
    }
}