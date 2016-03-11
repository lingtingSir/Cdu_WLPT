using BLL;
using Model;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_UpdatePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["UserID"] == null || this.Session["UserID"].ToString() == "")
        {
            base.Response.Redirect("~/login1.aspx");
        }
    }
    public string MD5(string pwd)
    {
        MD5 mD = System.Security.Cryptography.MD5.Create();
        byte[] bytes = Encoding.Unicode.GetBytes(pwd);
        byte[] value = mD.ComputeHash(bytes);
        return BitConverter.ToString(value);
    }
    protected void ibOK_Click(object sender, EventArgs e)
    {
        UserBll userBll = new UserBll();
        UserEntity userEntity = new UserEntity();
        userEntity.UserID = this.Session["UserID"].ToString();
        DataTable byID = userBll.GetByID(userEntity);
        if (this.MD5(this.TextBox1.Text.Trim()) != byID.Rows[0]["UserPwd"].ToString().Trim())
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('旧密码错误')</script>");
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            return;
        }
        userEntity.UserPwd = this.MD5(this.TextBox3.Text.Trim());
        if (userBll.Update_Pwd(userEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('密码修改成功')</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('密码修改失败')</script>");
        }
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        this.TextBox3.Text = "";
    }
}