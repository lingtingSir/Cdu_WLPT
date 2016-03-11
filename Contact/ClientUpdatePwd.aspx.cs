using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Dal;
using BLL;

public partial class Contact_ClientUpdatePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = this.Session["ClientID"].ToString();
    }
    public string MD5(string pwd)
    {
        MD5 mD = System.Security.Cryptography.MD5.Create();
        byte[] bytes = Encoding.Unicode.GetBytes(pwd);
        byte[] value = mD.ComputeHash(bytes);
        return BitConverter.ToString(value);
    }
    protected void Button_Click1(object sender, EventArgs e)
    {
        string clientID = this.Session["ClientID"].ToString();
        ClientBll clientBll = new ClientBll();
        ClientEntity clientEntity = new ClientEntity();
        clientEntity.ClientID = clientID;
        DataTable byID = clientBll.GetByID(clientEntity);
        if (this.MD5(this.TextBox1.Text.Trim()) != byID.Rows[0]["ClientPwd"].ToString().Trim())
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('旧密码错误')</script>");
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            return;
        }
        clientEntity.ClientID = clientID;
        clientEntity.ClientPwd = this.MD5(this.TextBox3.Text.Trim());
        if (clientBll.Update_Pwd(clientEntity))
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