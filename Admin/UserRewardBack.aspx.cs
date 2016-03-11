using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Dal;
using BLL;
using System.Data;
public partial class Admin_UserRewardBack : System.Web.UI.Page
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
        if (base.Request.QueryString["id"] != null && base.Request.QueryString["id"].ToString() != "")
        {
            this.ViewState["id"] = base.Request.QueryString["id"].ToString();
            this.SetTextBoxText();
            return;
        }
        base.Response.Redirect("UserIntegral_Manage.aspx");
    }
    private void SetTextBoxText()
    {
        if (base.Request.QueryString["type"].ToString() == "1")
        {
            this.txtDes.Text = "谢谢您的上报，你提出的问题，我们为您加5分";
            return;
        }
        if (base.Request.QueryString["type"].ToString() == "2")
        {
            this.txtDes.Text = "谢谢您的上报，你提出的问题，我们不给你加分";
            return;
        }
        base.Response.Redirect("UserWrongProblemManageTwo.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (base.Request.QueryString["type"].ToString() == "1")
        {
            RewardProblemEntity rewardProblemEntity = new RewardProblemEntity();
            RewardProbelmBll rewarProblemBll = new RewardProbelmBll();
            rewardProblemEntity.RewardProblemID = int.Parse(this.ViewState["id"].ToString());
            rewardProblemEntity.UserID = "";
          
            DataTable byID = rewarProblemBll.GetByID(rewardProblemEntity);
            if (byID == null || byID.Rows.Count != 1)
            {
                base.Response.Redirect("~/login_1.aspx");
                return;
            }
            string userID = byID.Rows[0]["UserID"].ToString();
            UserEntity userEntity = new UserEntity();
            UserBll userBll = new UserBll();
            userEntity.UserID = userID;
            DataTable byID2 = userBll.GetByID(userEntity);
            if (byID2 != null && byID2.Rows.Count == 1)
            {
                userEntity.UserID = userID;
                userEntity.UserIntegral = int.Parse(byID2.Rows[0]["UserIntegral"].ToString()) + 5;
                userBll.Update_Integral(userEntity);
                UserIntegralDetailEntity userIntegralDetailEntity = new UserIntegralDetailEntity();
                UserIntegralDetailBll userIntegralDetailBll = new UserIntegralDetailBll();
                userIntegralDetailEntity.UserID = userID;
                userIntegralDetailEntity.IntegralChange = 5;
                userIntegralDetailEntity.ChangeDes = "提出问题认同上报";
                userIntegralDetailBll.Add(userIntegralDetailEntity);
                rewardProblemEntity.ManagerBack = this.txtDes.Text.Trim();
                rewardProblemEntity.RecordState = 2;
                rewarProblemBll.Update_Back(rewardProblemEntity);
                base.Response.Redirect("UserRewardManager.aspx");
                return;
            }
            base.Response.Redirect("~/login_1.aspx");
            return;
        }
        else
        {
            RewardProblemEntity rewardProblemEntity2 = new RewardProblemEntity();
            RewardProbelmBll wrongProblemBll2 = new RewardProbelmBll();
            rewardProblemEntity2.RewardProblemID = int.Parse(this.ViewState["id"].ToString());
            rewardProblemEntity2.UserID = "";

            DataTable byID3 = wrongProblemBll2.GetByID(rewardProblemEntity2);
            if (byID3 != null && byID3.Rows.Count == 1)
            {
                string userID2 = byID3.Rows[0]["UserID"].ToString();
                UserIntegralDetailEntity userIntegralDetailEntity2 = new UserIntegralDetailEntity();
                UserIntegralDetailBll userIntegralDetailBll2 = new UserIntegralDetailBll();
                userIntegralDetailEntity2.UserID = userID2;
                userIntegralDetailEntity2.IntegralChange = 0;
                userIntegralDetailEntity2.ChangeDes = "提出问题不认同上报";
                userIntegralDetailBll2.Add(userIntegralDetailEntity2);
                rewardProblemEntity2.ManagerBack = this.txtDes.Text.Trim();
                rewardProblemEntity2.RecordState = 3;
                wrongProblemBll2.Update_Back(rewardProblemEntity2);
                base.Response.Redirect("UserRewardManager.aspx");
                return;
            }
            base.Response.Redirect("~/login_1.aspx");
            return;
        }
    }
}