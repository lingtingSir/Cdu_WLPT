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
public partial class Admin_PowerManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LoadData();
            this.btOK.CommandName = "ok";
            this.btReset.CommandName = "reset";
        }
    }
    public string GetSub(string str, int len)
    {
        if (str.Length > len)
        {
            return str.Substring(0, len);
        }
        return str;
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.LoadData();
    }
    public void LoadData()
    {
        PowerBll powerBll = new PowerBll();
        powerBll.Asp(this.GridView1, this.AspNetPager1);
       
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        this.Label1.Visible = false;
        this.txtID.Visible = false;
        this.RequiredFieldValidator3.Visible = false;
        this.RegularExpressionValidator1.Visible = false;
        this.btOK.CommandName = "edit";
        this.btReset.CommandName = "cancel";
        PowerBll powerBll = new PowerBll();
        DataTable byID = powerBll.GetByID(new PowerEntity
        {
            PowerID = Convert.ToInt32(e.CommandArgument.ToString().Trim())
        });
        if (byID != null && byID.Rows.Count == 1)
        {
            this.txtName.Text = byID.Rows[0]["PowerName"].ToString().Trim();
            this.txtDes.Text = byID.Rows[0]["PowerDes"].ToString().Trim();
        }
        this.btOK.CommandArgument = e.CommandArgument.ToString().Trim();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PowerBll powerBll = new PowerBll();
        PowerEntity powerEntity = new PowerEntity();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].FindControl("lbID");
        powerEntity.PowerID = Convert.ToInt32(label.Text.Trim());
        try
        {
            if (powerBll.Delete(powerEntity))
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('删除权限成功')</script>");
            }
        }
        catch
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('删除权限失败')</script>");
        }
        this.LoadData();
    }
    protected void btOK_Click1(object sender, EventArgs e)
    {
        if(this.btOK.CommandName.Trim() == "ok")
		{
			PowerBll powerBll = new PowerBll();
			PowerEntity powerEntity = new PowerEntity();
			powerEntity.PowerName = base.Server.HtmlEncode(this.txtName.Text.Trim());
			powerEntity.PowerDes = base.Server.HtmlEncode(this.txtDes.Text.Trim());
			powerEntity.PowerID = Convert.ToInt32(this.txtID.Text.Trim());
			try
			{
				if (powerBll.Add(powerEntity))
				{
					this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('添加权限成功')</script>");
					this.LoadData();
					this.txtName.Text = "";
					this.txtDes.Text = "";
					this.txtID.Text = "";
				}
				return;
			}
			catch
			{
				this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('ID已存在，请重新输入')</script>");
				return;
			}
		}
		PowerBll powerBll2 = new PowerBll();
		if (powerBll2.Update(new PowerEntity
		{
			PowerName = this.txtName.Text.Trim(),
			PowerDes = this.txtDes.Text.Trim(),
			PowerID = Convert.ToInt32(this.btOK.CommandArgument.Trim())
		}))
		{
			this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('修改成功')</script>");
		}
		else
		{
			this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('修改失败')</script>");
		}
		this.Label1.Visible = true;
		this.txtID.Visible = true;
		this.RequiredFieldValidator3.Visible = true;
		this.RegularExpressionValidator1.Visible = true;
		this.btOK.CommandName = "ok";
		this.btReset.CommandName = "reset";
		this.LoadData();
		this.txtName.Text = "";
		this.txtDes.Text = "";
		this.txtID.Text = "";
    }
    protected void btReset_Click1(object sender, EventArgs e)
    {
        this.txtName.Text = "";
        this.txtDes.Text = "";
        this.txtID.Text = "";
        if (this.btReset.CommandName.Trim() == "cancel")
        {
            this.Label1.Visible = true;
            this.txtID.Visible = true;
            this.RequiredFieldValidator3.Visible = true;
            this.RegularExpressionValidator1.Visible = true;
            this.btOK.CommandName = "ok";
            this.btReset.CommandName = "reset";
        }
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
}