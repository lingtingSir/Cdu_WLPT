using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Dal;
using BLL;
using System.Data;
public partial class Admin_DepartmenManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadData("");
            this.btOK.CommandName = "ok";
            this.btReset.CommandName = "reset";
        }
    }
    protected void btOK_Click1(object sender, EventArgs e)
    {
        if (this.Session["ManageLand"].ToString() == this.txtCode.Text)
        {
            if (this.btOK.CommandName.Trim() == "ok")
            {
                DepartmentBll departmentBll = new DepartmentBll();
                if (departmentBll.Add(new DepartmentEntity
                {
                    DepartmentName = base.Server.HtmlEncode(this.txtName.Text.Trim()),
                    DepartmentDes = base.Server.HtmlEncode(this.txtDes.Text.Trim())
                }))
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('添加项目组成功')</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('添加项目组失败')</script>");
                }
            }
            else
            {
                DepartmentBll departmentBll2 = new DepartmentBll();
                if (departmentBll2.Update(new DepartmentEntity
                {
                    DepartmentName = this.txtName.Text.Trim(),
                    DepartmentDes = this.txtDes.Text.Trim(),
                    DepartmentID = Convert.ToInt32(this.btOK.CommandArgument.Trim())
                }))
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('修改项目组成功')</script>");
                }
                this.btOK.CommandName = "ok";
                this.btReset.CommandName = "reset";
            }
            if (this.txtSearch.Text.Trim() == "")
            {
                this.LoadData("");
            }
            else
            {
                this.LoadData(this.txtSearch.Text.Trim());
            }
            this.txtName.Text = "";
            this.txtDes.Text = "";
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('验证码错误')</script>");
    }
    protected void btReset_Click1(object sender, EventArgs e)
    {
        this.txtName.Text = "";
        this.txtDes.Text = "";
        if (this.btReset.CommandName == "cancel")
        {
            this.btOK.CommandName = "ok";
            this.btReset.CommandName = "reset";
        }




        
    }
    public void LoadData(string departmentName)
    {
        DepartmentBll departmentBll = new DepartmentBll();
        DepartmentEntity departmentEntity = new DepartmentEntity();
        departmentEntity.DepartmentName = departmentName;
        departmentBll.Asp(this.GridView1, this.AspNetPager1, departmentEntity);
    }
    public string GetSub(string str, int len)
    {
        if (str.Length > len)
        {
            return str.Substring(0, len) + "...";
        }
        return str;
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        if (this.txtSearch.Text.Trim() == "")
        {
            this.LoadData("");
            return;
        }
        this.LoadData(this.txtSearch.Text.Trim());
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DepartmentBll departmentBll = new DepartmentBll();
        DepartmentEntity departmentEntity = new DepartmentEntity();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].FindControl("lbID2");
        departmentEntity.DepartmentID = Convert.ToInt32(label.Text.Trim());
        try
        {
            if (departmentBll.Delete(departmentEntity))
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('删除项目组成功')</script>");
            }
        }
        catch
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('删除失败，请先删除项目组下的组员')</script>");
        }
        if (this.txtSearch.Text.Trim() == "")
        {
            this.LoadData("");
            return;
        }
        this.LoadData(this.txtSearch.Text.Trim());
    }

    protected void btSearch_Click1(object sender, EventArgs e)
    {
     
		if (this.txtSearch.Text.Trim() == "")
		{
			this.LoadData("");
			return;
		}
		this.LoadData(this.txtSearch.Text.Trim());
	
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
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        this.btOK.CommandName = "edit";
        this.btReset.CommandName = "cancel";
        DepartmentBll departmentBll = new DepartmentBll();
        DataTable byID = departmentBll.GetByID(new DepartmentEntity
        {
            DepartmentID = Convert.ToInt32(e.CommandArgument.ToString().Trim())
        });
        if (byID != null && byID.Rows.Count == 1)
        {
            this.txtName.Text = byID.Rows[0]["DepartmentName"].ToString().Trim();
            this.txtDes.Text = byID.Rows[0]["DepartmentDes"].ToString().Trim();
        }
        this.btOK.CommandArgument = e.CommandArgument.ToString().Trim();
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('该数据是根源数据，不支持批量删除')</script>");
    }
}