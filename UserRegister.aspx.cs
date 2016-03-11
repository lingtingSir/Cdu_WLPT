using BLL;
using Model;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class UserRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool arg_06_0 = base.IsPostBack;
    }
    public string MD5(string pwd)
    {
        MD5 mD = System.Security.Cryptography.MD5.Create();
        byte[] bytes = Encoding.Unicode.GetBytes(pwd);
        byte[] value = mD.ComputeHash(bytes);
        return BitConverter.ToString(value);
    }
    
    protected void btRegister_Click1(object sender, EventArgs e)
    {
        ClientBll clientBll = new ClientBll();
        ClientEntity clientEntity = new ClientEntity();
      
       
        string clientID = base.Server.HtmlEncode(this.txtUserID.Text);
        string clientName = base.Server.HtmlEncode(this.txtUserName.Text);
        string text = base.Server.HtmlEncode(this.txtUserPwd.Text);
        string clientDes = base.Server.HtmlEncode(this.txtUserDes.Text);
        clientEntity.ClientID = clientName; 
        clientEntity.ClientName = clientID;
        clientEntity.ClientPwd = this.MD5(text.Trim());
        clientEntity.ClientDes = clientDes;
        try
        {
            if (clientBll.Register(clientEntity))
            {
                base.Response.Write("<script>alert('注册成功');location.href='Login_1.aspx';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('注册失败');location.href='Login_1.aspx';</script>");
            }
        }
        catch (Exception)
        {
            base.Response.Write("<script>alert('注册失败');location.href='Login_1.aspx';</script>");
        }
    }
}