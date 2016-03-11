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
public partial class Admin_UpdatePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = this.Session["ManagerID"].ToString();
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
        string managerID = this.Session["ManagerID"].ToString();
        ManagerBll managerBll = new ManagerBll();
        ManagerEnitity managerEntity = new ManagerEnitity();
        managerEntity.ManagerID = managerID;
        DataTable byID = managerBll.GetByID(managerEntity);
        if(this.MD5(this.TextBox1.Text.Trim())!=byID.Rows[0]["ManagerPwd"].ToString().Trim())
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('旧密码错误')</script>");
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            return;
        }
        managerEntity.ManagerID = managerID;
        managerEntity.ManagerPwd = this.MD5(this.TextBox3.Text.Trim());
        if (managerBll.Update_Pwd(managerEntity))
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