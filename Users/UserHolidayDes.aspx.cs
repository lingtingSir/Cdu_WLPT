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

public partial class Users_UserHolidayBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {



        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserHolidayBll rewardProblemBll = new UserHolidayBll();
        UserHolidayEntity rewardProblemEntity = new UserHolidayEntity();




        if (this.txtDes.Text != null && this.txtDes.Text != "")
        {
            rewardProblemEntity.UserID = base.Session["UserID"].ToString();
            rewardProblemEntity.DateUp = DateTime.Now;
            rewardProblemEntity.RecordState = 1;
            rewardProblemEntity.Des = this.txtDes.Text;
        }
        else
        {
            rewardProblemEntity.Des = "";
        }



        if (rewardProblemBll.Add(rewardProblemEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加成功');</script>");


            this.txtDes.Text = "";

            base.Response.Redirect("UserHolidayManage.aspx");
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加失败');</script>");
    }
}