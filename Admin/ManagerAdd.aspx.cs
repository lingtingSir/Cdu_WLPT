using BLL;
using Model;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
public partial class Admin_ManagerAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadData("", "", 0, 0);
            this.LoadDrop();
        }
     //   this.upFileUpLoad.Attributes.Add("onchange", "PictureShow()");
    }
    public void LoadData(string managerID, string managerName, int DepartmentID, int PowerID)
    {
        ManagerBll managerBll = new ManagerBll();
        ManagerEnitity managerEntity = new ManagerEnitity();
        managerEntity.ManagerID = managerID;
        managerEntity.ManagerName = managerName;
        managerEntity.DepartmentID = DepartmentID;
        managerEntity.PowerID = PowerID;
        managerBll.Asp(this.GridView1, this.AspNetPager1, managerEntity);
    }
    public void LoadDrop()
    {
        this.dropDepartment.Items.Clear();
        this.OkDepartment.Items.Clear();
        this.upDepartment.Items.Clear();
        this.dropPower.Items.Clear();
        this.OkPower.Items.Clear();
        this.upPower.Items.Clear();
        DepartmentBll departmentBll = new DepartmentBll();
        this.dropDepartment.DataTextField = "DepartmentName";
        this.dropDepartment.DataValueField = "DepartmentID";
        this.dropDepartment.DataSource = departmentBll.GetAll();
        this.dropDepartment.DataBind();
        this.dropDepartment.Items.Insert(0, "==请选择部门==");
        this.OkDepartment.DataTextField = "DepartmentName";
        this.OkDepartment.DataValueField = "DepartmentID";
        this.OkDepartment.DataSource = departmentBll.GetAll();
        this.OkDepartment.DataBind();
        this.OkDepartment.Items.Insert(0, "==请选择部门==");
        this.upDepartment.DataTextField = "DepartmentName";
        this.upDepartment.DataValueField = "DepartmentID";
        this.upDepartment.DataSource = departmentBll.GetAll();
        this.upDepartment.DataBind();
        this.upDepartment.Items.Insert(0, "==请选择部门==");
        PowerBll powerBll = new PowerBll();
        this.dropPower.DataTextField = "PowerName";
        this.dropPower.DataValueField = "PowerID";
        this.dropPower.DataSource = powerBll.GetAll();
        this.dropPower.DataBind();
        this.dropPower.Items.Insert(0, "==请选择角色==");
        this.OkPower.DataTextField = "PowerName";
        this.OkPower.DataValueField = "PowerID";
        this.OkPower.DataSource = powerBll.GetAll();
        this.OkPower.DataBind();
        this.OkPower.Items.Insert(0, "==请选择角色==");
        this.upPower.DataTextField = "PowerName";
        this.upPower.DataValueField = "PowerID";
        this.upPower.DataSource = powerBll.GetAll();
        this.upPower.DataBind();
        this.upPower.Items.Insert(0, "==请选择角色==");
    }
    public void LoadPage()
    {
        if (this.dropSearch.SelectedIndex == 0)
        {
            if (this.dropDepartment.SelectedIndex == 0)
            {
                if (this.dropPower.SelectedIndex == 0)
                {
                    this.LoadData(this.txtSearch.Text.Trim(), "", 0, 0);
                    return;
                }
                this.LoadData(this.txtSearch.Text.Trim(), "", 0, Convert.ToInt32(this.dropPower.SelectedValue.Trim()));
                return;
            }
            else
            {
                if (this.dropPower.SelectedIndex == 0)
                {
                    this.LoadData(this.txtSearch.Text.Trim(), "", Convert.ToInt32(this.dropDepartment.SelectedValue.Trim()), 0);
                    return;
                }
                this.LoadData(this.txtSearch.Text.Trim(), "", Convert.ToInt32(this.dropDepartment.SelectedValue.Trim()), Convert.ToInt32(this.dropPower.SelectedValue.Trim()));
                return;
            }
        }
        else
        {
            if (this.dropDepartment.SelectedIndex == 0)
            {
                if (this.dropPower.SelectedIndex == 0)
                {
                    this.LoadData("", this.txtSearch.Text.Trim(), 0, 0);
                    return;
                }
                this.LoadData("", this.txtSearch.Text.Trim(), 0, Convert.ToInt32(this.dropPower.SelectedValue.Trim()));
                return;
            }
            else
            {
                if (this.dropPower.SelectedIndex == 0)
                {
                    this.LoadData("", this.txtSearch.Text.Trim(), Convert.ToInt32(this.dropDepartment.SelectedValue.Trim()), 0);
                    return;
                }
                this.LoadData("", this.txtSearch.Text.Trim(), Convert.ToInt32(this.dropDepartment.SelectedValue.Trim()), Convert.ToInt32(this.dropPower.SelectedValue.Trim()));
                return;
            }
        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ManagerBll managerBll = new ManagerBll();
        ManagerEnitity managerEntity = new ManagerEnitity();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].FindControl("lbID");
        managerEntity.ManagerID = label.Text.Trim();
      /* string a = managerBll.DeleteProc(managerEntity);
        if (a == "1")
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('删除管理员成功')</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('删除管理员失败')</script>");
        } */
        this.LoadPage();
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        ManagerBll managerBll = new ManagerBll();
        ManagerEnitity managerEntity = new ManagerEnitity();
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBox checkBox = (CheckBox)this.GridView1.Rows[i].FindControl("chkBox");
            if (checkBox != null && checkBox.Checked)
            {
                Label label = (Label)this.GridView1.Rows[i].FindControl("lbID");
                if (label != null)
                {
                    managerEntity.ManagerID = label.Text.Trim();
          //          managerBll.(managerEntity);
                }
            }
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('批量删除成功');", true);
        this.LoadPage();
    }
    public string MD5(string pwd)
    {
        MD5 mD = System.Security.Cryptography.MD5.Create();
        byte[] bytes = Encoding.Unicode.GetBytes(pwd);
        byte[] value = mD.ComputeHash(bytes);
        return BitConverter.ToString(value);
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        ManagerBll managerBll = new ManagerBll();
        DataTable byID = managerBll.GetByID(new ManagerEnitity
        {
            ManagerID = e.CommandArgument.ToString().Trim()
        });
        if (byID != null && byID.Rows.Count == 1)
        {
            this.upID.Text = byID.Rows[0]["ManagerID"].ToString().Trim();
            this.upName.Text = byID.Rows[0]["ManagerName"].ToString().Trim();
            this.upDepartment.SelectedValue = byID.Rows[0]["DepartmentID"].ToString().Trim();
            this.upPower.SelectedValue = byID.Rows[0]["PowerID"].ToString().Trim();
       //     this.upImage.ImageUrl = "~/ManagerImage/" + byID.Rows[0]["ManagerImage"].ToString().Trim();
            this.upDes.Text = byID.Rows[0]["ManagerDes"].ToString().Trim();
          //  this.lbImage.Text = byID.Rows[0]["ManagerImage"].ToString().Trim();
        }
        this.btUp.CommandArgument = e.CommandArgument.ToString().Trim();
        this.add.Visible = false;
        this.edit.Visible = true;
        this.ChangePwd.Visible = false;
    }
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        this.add.Visible = false;
        this.edit.Visible = false;
        this.ChangePwd.Visible = true;
        this.upPwd.CommandArgument = e.CommandArgument.ToString().Trim();
    }
   
    protected void btOk_Click1(object sender, EventArgs e)
    {
        if (this.Session["ManageLand"].ToString() == this.txtCode.Text)
        {
            if (this.OkPower.SelectedIndex != 0 && this.OkDepartment.SelectedIndex != 0)
            {
                ManagerBll managerBll = new ManagerBll();
                ManagerEnitity managerEntity = new ManagerEnitity();
                managerEntity.ManagerID = base.Server.HtmlEncode(this.OkID.Text.Trim());
                managerEntity.ManagerName = base.Server.HtmlEncode(this.OkName.Text.Trim());
                managerEntity.ManagerPwd = this.MD5(managerEntity.ManagerID);
                managerEntity.DepartmentID = Convert.ToInt32(this.OkDepartment.SelectedValue.Trim());
                managerEntity.PowerID = Convert.ToInt32(this.OkPower.SelectedValue.Trim());
                managerEntity.ManagerImage = "";
                managerEntity.ManagerDes = "";
                try
                {
                    if (managerBll.Add(managerEntity))
                    {
                        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加管理员成功');</script>");
                        this.LoadPage();
                        this.OkID.Text = "";
                        this.OkName.Text = "";
                    }
                    return;
                }
                catch
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('该管理员号已存在，请重新输入');</script>");
                    return;
                }
            }
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('请先选择角色和部门');</script>");
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('验证码错误')</script>");
    }
    protected void btReset_Click1(object sender, EventArgs e)
    {
        this.OkID.Text = "";
        this.OkName.Text = "";
        this.OkDepartment.SelectedIndex = 0;
        this.OkPower.SelectedIndex = 0;
        this.add.Visible = true;
        this.edit.Visible = false;
        this.ChangePwd.Visible = false;
        this.txtPwd.Text = "";
    }
    protected void btUp_Click1(object sender, EventArgs e)
    {
        if (this.Session["ManageLand"].ToString() == this.TextBox1.Text)
        {
            if (this.upDepartment.SelectedIndex != 0 && this.upPower.SelectedIndex != 0)
            {
                ManagerBll managerBll = new ManagerBll();
                ManagerEnitity managerEntity = new ManagerEnitity();
                managerEntity.ManagerID = this.btUp.CommandArgument.Trim();
                managerEntity.ManagerName = base.Server.HtmlEncode(this.upName.Text.Trim());
                managerEntity.ManagerDes = base.Server.HtmlEncode(this.upDes.Text.Trim());
                managerEntity.DepartmentID = Convert.ToInt32(this.upDepartment.SelectedValue);
                managerEntity.PowerID = Convert.ToInt32(this.upPower.SelectedValue);
              
                if (managerBll.Update(managerEntity))
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('修改管理员成功');</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('修改管理员失败');</script>");
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('请先选择角色和项目组');</script>");
            }
            this.upName.Text = "";
          
            this.upDes.Text = "";
            this.LoadPage();
            this.add.Visible = true;
            this.edit.Visible = false;
            this.ChangePwd.Visible = false;
            
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('验证码错误')</script>");
    }
    protected void btCancel_Click1(object sender, EventArgs e)
    {
        this.upName.Text = "";
        
        this.upDes.Text = "";
        this.add.Visible = true;
        this.edit.Visible = false;
        this.ChangePwd.Visible = false;
      
    }
    protected void upPwd_Click1(object sender, EventArgs e)
    {
        ManagerBll managerBll = new ManagerBll();
        if (managerBll.Update_Pwd(new ManagerEnitity
        {
            ManagerID = this.upPwd.CommandArgument.Trim(),
            ManagerPwd = this.MD5(this.txtPwd.Text.Trim())
        }))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('修改密码成功');</script>");
        }
        this.add.Visible = true;
        this.edit.Visible = false;
        this.ChangePwd.Visible = false;
        this.txtPwd.Text = "";
        this.LoadPage();
    }
    protected void upCancel_Click1(object sender, EventArgs e)
    {
        this.add.Visible = true;
        this.edit.Visible = false;
        this.ChangePwd.Visible = false;
        this.txtPwd.Text = "";
    }
    protected void btSearch_Click1(object sender, EventArgs e)
    {
        this.LoadPage();
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
    protected void dropDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void dropPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }
}