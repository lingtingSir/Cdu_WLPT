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

public partial class Admin_UserHolidayBack : System.Web.UI.Page
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
        base.Response.Redirect("UserHolidayManage.aspx");
    }
    private void SetTextBoxText()
    {
        if (base.Request.QueryString["type"].ToString() == "1")
        {
            this.txtDes.Text = "谢谢您的上报，请假我们为您加5分";
            return;
        }
        if (base.Request.QueryString["type"].ToString() == "2")
        {
            this.txtDes.Text = "谢谢您的上报，请假我们不给你加分";
            return;
        }
        base.Response.Redirect("UserWrongProblemManageTwo.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (base.Request.QueryString["type"].ToString() == "1")
        {
            UserHolidayEntity rewardProblemEntity = new UserHolidayEntity();
            UserHolidayBll rewarProblemBll = new UserHolidayBll();
            rewardProblemEntity.UserHolidayID = int.Parse(this.ViewState["id"].ToString());
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
                UserHolidayDetailEntity UserHolidayDetailEntity = new UserHolidayDetailEntity();
                UserHolidayDetailBll UserHolidayDetailBll = new UserHolidayDetailBll();
                UserHolidayDetailEntity.UserID = userID;
                UserHolidayDetailEntity.IntegralChange = 5;
                UserHolidayDetailEntity.ChangeDes = "请假认同上报";
                UserHolidayDetailBll.Add(UserHolidayDetailEntity);
                rewardProblemEntity.ManagerBack = this.txtDes.Text.Trim();
                rewardProblemEntity.RecordState = 2;
                rewarProblemBll.Update_Back(rewardProblemEntity);
                base.Response.Redirect("UserHolidayManage.aspx");
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
                UserHolidayDetailEntity UserHolidayDetailEntity2 = new UserHolidayDetailEntity();
                UserHolidayDetailBll UserHolidayDetailBll2 = new UserHolidayDetailBll();
                UserHolidayDetailEntity2.UserID = userID2;
                UserHolidayDetailEntity2.IntegralChange = 0;
                UserHolidayDetailEntity2.ChangeDes = "请假不认同上报";
                UserHolidayDetailBll2.Add(UserHolidayDetailEntity2);
                rewardProblemEntity2.ManagerBack = this.txtDes.Text.Trim();
                rewardProblemEntity2.RecordState = 3;
                wrongProblemBll2.Update_Back(rewardProblemEntity2);
                base.Response.Redirect("UserHolidayManage.aspx");
                return;
            }
            base.Response.Redirect("~/login_1.aspx");
            return;
        }
    }
}