using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Dal;
using System.Data;

public partial class Users_UserRewardDes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
              
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        RewardProbelmBll rewardProblemBll = new RewardProbelmBll();
        RewardProblemEntity rewardProblemEntity = new RewardProblemEntity();
        



        if (this.txtDes.Value != null && this.txtDes.Value != "")
        {
            rewardProblemEntity.UserID = base.Session["UserID"].ToString();
            rewardProblemEntity.DateUp = DateTime.Now;
            rewardProblemEntity.RecordState = 1;
            rewardProblemEntity.Des = this.txtDes.Value;
        }
        else
        {
            rewardProblemEntity.Des = "";
        }



        if (rewardProblemBll.Add(rewardProblemEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加成功');</script>");
            

            this.txtDes.Value = "";

            base.Response.Redirect("UserRewardManager.aspx");
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加失败');</script>");
    }
}