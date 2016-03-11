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
public partial class Login_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public string MD5(string pwd)
    {
        MD5 mD = System.Security.Cryptography.MD5.Create();
        byte[] bytes = Encoding.Unicode.GetBytes(pwd);
        byte[] value = mD.ComputeHash(bytes);
        return BitConverter.ToString(value);
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        this.Session.RemoveAll();
        ManagerBll managerBll = new ManagerBll();
        ManagerEnitity managerEntity = new ManagerEnitity();
        UserEntity uen = new UserEntity();
        UserBll ubll = new UserBll();
        ClientEntity clientEntity = new ClientEntity();
        ClientBll clientBll = new ClientBll();
//      StudentBll sbll = new StudentBll();
    
    //    StudentEntity sen = new StudentEntity();
        if (RBtnUser.Checked)
        {
            uen.UserID = TxtID.Text.Trim();
            uen.UserPwd = MD5(TxtPwd.Text.Trim());

            //if (ubll.IsOverDate(uen))
            //{
            if (ubll.Validate_Login(uen))
            {
                Session.RemoveAll();
                Session["UserID"] = uen.UserID;//建议存放数据表中的主键值
                Response.Redirect("Users/UserIndex.aspx");
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('密码错误！')</script>");
           
        }
        if (this.RBtnManager.Checked)
        {
            managerEntity.ManagerID = this.TxtID.Text.Trim();
            managerEntity.ManagerPwd = this.MD5(this.TxtPwd.Text.Trim());
            //    Response.Write(teacherEntity.ManagerPwd);
            if (managerBll.Validate_Login(managerEntity))
            {
                this.Session.RemoveAll();
                this.Session["ManagerID"] = managerEntity.ManagerID;
                base.Response.Redirect("default.aspx");
            }
           
        }
        if (RBtnContact.Checked)
        {
            clientEntity.ClientID = this.TxtID.Text.Trim();
            clientEntity.ClientPwd = this.MD5(this.TxtPwd.Text.Trim());
            //    Response.Write(teacherEntity.ManagerPwd);
            if (clientBll.Validate_Login(clientEntity))
            {
                this.Session.RemoveAll();
                this.Session["ClientID"] = clientEntity.ClientID;
                base.Response.Redirect("Contact/default.aspx");
            }
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        this.TxtID.Text = "";
        this.TxtPwd.Text = "";
    }
    protected string getstring()
    {
        Random random = new Random(DateTime.Now.Millisecond);
        return random.Next(10).ToString();
    }
    
}