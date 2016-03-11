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

public partial class LoginDialog : System.Web.UI.Page
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
        //   UserEntity userEntity = new UserEntity();
        //   UserBll userBll = new UserBll();
        //   StudentBll studentBll = new StudentBll();
        //   StudentEntity studentEntity = new StudentEntity();
        if (this.RBtnAdmin.Checked)
        {
            //    userEntity.UserID = this.TxtID.Text.Trim();
            //    userEntity.UserPwd = this.MD5(this.TxtPwd.Text.Trim());
            //     if (userBll.Validate_Login(userEntity))
            //     {
            //         this.Session.RemoveAll();
            //        this.Session["UserID"] = userEntity.UserID;
            //        base.Response.Redirect("Users/UserIndex.aspx");
            //   }
            //  else
            //  {
            //     this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('密码错误！')</script>");
            //  }
        }
        if (this.RBtnTeacher.Checked)
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
        //      if (this.RBtnStudent.Checked)
        //    {
        //      studentEntity.StudentID = this.TxtID.Text.Trim();
        //    studentEntity.StudentPwd = this.MD5(this.TxtPwd.Text.Trim());
        //  if (studentBll.Validate_Login(studentEntity))
        //  {
        //    this.Session.RemoveAll();
        //  this.Session["StudentID"] = studentEntity.StudentID;
        //  base.Response.Redirect("Student.aspx");
        //  return;
        // }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('密码错误')</script>");
        //  }
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