using BLL;
using Model;
using Dal;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

public partial class Admin_UserManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            bind();
            this.LoadData("", "");
        }
    }

    private void bind()
    {
        
 
        DepartmentBll departmentBll = new DepartmentBll();
        this.OkDepartment.Items.Clear();
   //     this.OkDepartment.Items.Insert(0, "==请选择部门==");
        this.OkDepartment.DataTextField = "DepartmentName";
        this.OkDepartment.DataValueField = "DepartmentID";
        this.OkDepartment.DataSource=departmentBll.GetAll();
        
        this.OkDepartment.DataBind();
        this.OkDepartment.Items.Insert(0, "==请选择项目组==");
    }

    public void LoadData(string userName, string userID)
    {
        UserBll userBll = new UserBll();
        UserEntity userEntity = new UserEntity();
        userEntity.UserID = userID;
        userEntity.UserName = userName;
        userBll.Asp(this.GridView1, this.AspNetPager1, userEntity);
    }
    public void LoadPage()
    {
        if (this.dropSearch.SelectedValue == "1")
        {
            this.LoadData("", this.txtSearch.Text.ToString());
            return;
        }
        this.LoadData(this.txtSearch.Text.ToString(), "");
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        UserBll userBll = new UserBll();
        UserEntity userEntity = new UserEntity();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].FindControl("lbID");
        userEntity.UserID = label.Text.Trim();
        try
        {
            if (userBll.Delete(userEntity))
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('用户删除成功');</script>");
            }
        }
        catch
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('删除失败，请先删除用户的考试情况');</script>");
        }
        this.LoadPage();
    }
    public string MD5(string pwd)
    {
        MD5 mD = System.Security.Cryptography.MD5.Create();
        byte[] bytes = Encoding.Unicode.GetBytes(pwd);
        byte[] value = mD.ComputeHash(bytes);
        return BitConverter.ToString(value);
    }
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        this.ChangePwd.Visible = true;
        this.Renewal.Visible = false;
        this.add.Visible = false;
        this.upPwd.CommandArgument = e.CommandArgument.ToString().Trim();
    }
    protected void LinkButton3_Command(object sender, CommandEventArgs e)
    {
        this.ChangePwd.Visible = false;
        this.add.Visible = false;
        this.Renewal.Visible = true;
        
        this.RenewalUp.CommandArgument = e.CommandArgument.ToString().Trim();
    }
    protected void ibSearch_Click(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void upPwd_Click(object sender, EventArgs e)
    {
        UserBll userBll = new UserBll();
        if (userBll.Update_Pwd(new UserEntity
        {
            UserID = this.upPwd.CommandArgument.Trim(),
            UserPwd = this.MD5(this.txtPwd.Text.Trim())
        }))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('修改密码成功');</script>");
        }
        this.ChangePwd.Visible = false;
        this.Renewal.Visible = false;
        this.txtPwd.Text = "";
        this.LoadPage();
    }
    protected void upCancel_Click1(object sender, EventArgs e)
    {
        this.ChangePwd.Visible = false;
        this.Renewal.Visible = false;
        this.txtPwd.Text = "";
    }
    protected void RenewalUp_Click(object sender, EventArgs e)
    {
        UserBll userBll = new UserBll();
        if (userBll.UpdateOverDate(new UserEntity
        {
            UserID = this.RenewalUp.CommandArgument.Trim()
        }, int.Parse(this.DropDay.SelectedValue.ToString())))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('续期成功');</script>");
        }
        this.ChangePwd.Visible = false;
        this.Renewal.Visible = false;
        this.LoadPage();
    }
    protected void RenewalCancel_Click(object sender, EventArgs e)
    {
        this.ChangePwd.Visible = false;
        this.Renewal.Visible = false;
    }
    protected void chkBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        if (checkBox.Checked)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox checkBox2 = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("chkBox");
                if (!checkBox2.Checked)
                {
                    checkBox2.Checked = true;
                }
            }
            return;
        }
        for (int j = 0; j < this.GridView1.Rows.Count; j++)
        {
            CheckBox checkBox3 = (CheckBox)this.GridView1.Rows[j].Cells[0].FindControl("chkBox");
            if (checkBox3.Checked)
            {
                checkBox3.Checked = false;
            }
        }
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        UserBll studentBll = new UserBll();
        UserEntity studentEntity = new UserEntity();
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBox checkBox = (CheckBox)this.GridView1.Rows[i].FindControl("chkBox");
            if (checkBox != null && checkBox.Checked)
            {
                Label label = (Label)this.GridView1.Rows[i].FindControl("lbID");
                if (label != null)
                {
                    studentEntity.UserID = Convert.ToInt32(label.Text).ToString();
                    studentBll.Delete(studentEntity);
                }
            }
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('删除成功');", true);
        this.LoadPage();
    }
    protected void btSearch_Click1(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (this.OkDepartment.SelectedIndex != 0)
        {
            UserBll userBll = new UserBll();
            UserEntity userEntity = new UserEntity();
            string userID = base.Server.HtmlEncode(this.txtUserID.Text);
            string userName = base.Server.HtmlEncode(this.txtUserName.Text);
            string text = base.Server.HtmlEncode(this.txtUserPwd.Text);
            string userDes = base.Server.HtmlEncode(this.txtUserDes.Text);
            userEntity.UserID = userID;
            userEntity.UserName = userName;
            userEntity.DepartmentID = Convert.ToInt32(this.OkDepartment.SelectedValue.Trim());
            userEntity.UserPwd = this.MD5(text.Trim());
            userEntity.UserDes = userDes;

            try
            {
                if (userBll.Register(userEntity))
                {

                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('添加成功')</script>");
                    txtUserName.Text = "";
                    txtPwd.Text = "";
                    txtUserDes.Text = "";
                    this.OkDepartment.Items.Insert(0, "==请选择项目组==");
                    this.LoadData("", "");
                }
                else
                {
                    base.Response.Write("<script>alert('添加失败');</script>");
                }
            }
            catch (Exception)
            {

                base.Response.Write("<script>alert('添加失败');</script>");
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void OkDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}