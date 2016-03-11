using BLL;
using FredCK.FCKeditorV2;
using Model;
using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_UserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadData();
        }
    }
    public void LoadData()
    {
        string userID = this.Session["UserID"].ToString().Trim();
        UserBll userBll = new UserBll();
        DataTable byID = userBll.GetByID(new UserEntity
        {
            UserID = userID
        });
        if (byID != null && byID.Rows.Count == 1)
        {
            
            this.txtName.Text = byID.Rows[0]["UserName"].ToString().Trim();
            this.upImage.ImageUrl = "~/" + byID.Rows[0]["UserImage"].ToString().Trim();
            this.txtUserDes.Value = byID.Rows[0]["UserDes"].ToString().Trim();
            this.lbImage.Text = byID.Rows[0]["UserImage"].ToString().Trim();
        }
    }
    protected void IsOK_Click(object sender, EventArgs e)
    {
        this.upFileUpLoad.Visible = true;
        this.RegularExpressionValidator1.Visible = true;
    }
  
   
    protected void btOK_Click1(object sender, EventArgs e)
    {
        string userID = this.Session["UserID"].ToString().Trim();
        UserBll userBll = new UserBll();
        UserEntity userEntity = new UserEntity();
        userEntity.UserID = userID;
        userEntity.UserName = base.Server.HtmlEncode(this.txtName.Text.Trim());
        userEntity.UserDes = this.txtUserDes.Value.ToString();
        string fileName = this.upFileUpLoad.FileName;
        if (fileName == "")
        {
            userEntity.UserImage = this.lbImage.Text.Trim();
        }
        else
        {
            if (this.lbImage.Text.Trim() != "")
            {
                File.Delete(base.Server.MapPath("~/" + this.lbImage.Text.Trim()));
            }
            string str = DateTime.Now.ToString("yyyyMMddHHmmssms") + Path.GetExtension(fileName);
            this.upFileUpLoad.SaveAs(base.Server.MapPath("~/UserImage/" + str));
            userEntity.UserImage = "UserImage/" + str;
        }
        if (userBll.Update(userEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('成功');</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('失败');</script>");
        }
        this.LoadData();
        this.RegularExpressionValidator1.Visible = false;
        this.upFileUpLoad.Visible = false;
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        this.RegularExpressionValidator1.Visible = false;
        this.LoadData();
        this.upFileUpLoad.Visible = false;
    }
}