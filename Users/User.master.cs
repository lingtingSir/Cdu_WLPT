using BLL;
using Model;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Users_User : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.IsQue();
            this.bind();
        }
    }
    private void IsQue()
    {
        if (base.Session["UserID"] == null || base.Session["UserID"].ToString() == "")
        {
            base.Response.Redirect("~/login_1.aspx");
        }
    }
    private void isOutDate()
    {
        UserBll userBll = new UserBll();
        if (!userBll.IsOverDate(new UserEntity
        {
            UserID = base.Session["UserID"].ToString()
        }))
        {
            base.Response.Redirect("../login_1.aspx");
        }
    }
    private void bind()
    {
        string userID = base.Session["UserID"].ToString();
        UserEntity userEntity = new UserEntity();
        UserBll userBll = new UserBll();
        userEntity.UserID = userID;
        DataTable byID = userBll.GetByID(userEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            this.lblUserID.Text = byID.Rows[0]["UserID"].ToString().Trim();
            this.lblUserName.Text = byID.Rows[0]["UserName"].ToString().Trim();
            this.lblIntegral.Text = byID.Rows[0]["UserIntegral"].ToString().Trim();
            this.lblIntegral0.Text = byID.Rows[0]["DepartmentName"].ToString().Trim();
        }
    }
}
