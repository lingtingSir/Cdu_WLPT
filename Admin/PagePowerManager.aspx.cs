using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Dal;
using BLL;
using Wuqi.Webdiyer;
using System.Data;
public partial class Admin_PagePowerManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            bind1();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ManagerPagePowerBll managerPagePowerBll = new ManagerPagePowerBll();
        ManagerPagePowerEnitity managerPagePowerEntity = new ManagerPagePowerEnitity();
        string managerID = this.GetManagerID();
        managerPagePowerEntity.ManagerID = managerID;
        managerPagePowerBll.DeleteByManager(managerPagePowerEntity);
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBoxList checkBoxList = (CheckBoxList)this.GridView1.Rows[i].FindControl("ckChild");
            LinkButton linkButton = (LinkButton)this.GridView1.Rows[i].FindControl("lkPages");
            CheckBox checkBox = (CheckBox)this.GridView1.Rows[i].FindControl("ckParent");
            if (checkBoxList != null && linkButton != null && checkBox != null && checkBox.Checked)
            {
                managerPagePowerEntity.ManagerID = managerID;
                managerPagePowerEntity.Id = int.Parse(linkButton.CommandArgument);
                managerPagePowerBll.Add(managerPagePowerEntity);
                for (int j = 0; j < checkBoxList.Items.Count; j++)
                {
                    if(checkBoxList.Items[j].Selected)
                    {
                   
                        managerPagePowerEntity.Id = int.Parse(checkBoxList.Items[j].Value);
                        managerPagePowerBll.Add(managerPagePowerEntity);
                    }

                }
            }
        }

    }
    private string GetManagerID()
    {
        if(Request["id"]==null&&Request["id"].ToString()=="")
        {
            Response.Redirect("../login.aspx");
        }
        return Request.QueryString["id"].ToString();
    }
    private void bind()
    {
        PageBll pageBll = new PageBll();
        PagesEnitity pageEntity = new PagesEnitity();
        pageEntity.ParentID = 0;
        this.GridView1.DataSource = pageBll.GetByParent(pageEntity);
        this.GridView1.DataBind();
    }
    private void bind1()
    {
        ManagerBll managerBll = new ManagerBll();
        string managerID = this.GetManagerID();
        ManagerEnitity managerEntity = new ManagerEnitity();
        managerEntity.ManagerID = managerID;
        DataTable byID = managerBll.GetByID(managerEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            this.lbManager.Text = byID.Rows[0]["ManagerName"].ToString();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            PageBll pageBll = new PageBll();
            PagesEnitity pageEntity = new PagesEnitity();
            CheckBoxList checkBoxList = (CheckBoxList)e.Row.FindControl("ckChild");
            CheckBox checkBox = (CheckBox)e.Row.FindControl("ckParent");
            LinkButton linkButton = (LinkButton)e.Row.FindControl("lkPages");

            if (checkBoxList != null && linkButton != null && checkBox != null)
            {
                int parentID = int.Parse(linkButton.CommandArgument.ToString());
                pageEntity.ParentID = parentID;
                checkBoxList.DataSource = pageBll.GetByParent(pageEntity);
                checkBoxList.DataTextField = "pagename";
                checkBoxList.DataValueField = "ID";
                checkBoxList.DataBind();
                ManagerPagePowerBll managerPagePowerBll = new ManagerPagePowerBll();
                DataTable allByManager = managerPagePowerBll.GetAllByManager(new ManagerPagePowerEnitity{
                    ManagerID =this.GetManagerID()
                });
                if (allByManager != null)
                {
                    for (int i = 0; i < allByManager.Rows.Count; i++)
                    {
                        if (allByManager.Rows[i]["ID"].ToString() == parentID.ToString())
                        {
                            checkBox.Checked = true;
                        }
                        for (int j = 0; j < checkBoxList.Items.Count; j++)
                        {
                            if (allByManager.Rows[i]["ID"].ToString() == checkBoxList.Items[j].Value.ToString())
                            {
                                checkBoxList.Enabled = true;
                                checkBoxList.Items[j].Selected = true;
                            }
                        }
                    }
                }

            }
        }
    }
    protected void ckParent_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        int index = int.Parse(checkBox.ToolTip.ToString());
        CheckBoxList checkBoxList = (CheckBoxList)this.GridView1.Rows[index].FindControl("ckChild");
        if (checkBoxList != null)
        {
            if (!checkBox.Checked)
            {
                checkBoxList.Enabled = false;
                for (int i = 0; i < checkBoxList.Items.Count; i++)
                {
                    checkBoxList.Items[i].Selected = false;
                }
                return;
            }
            checkBoxList.Enabled = true;
            for (int j = 0; j < checkBoxList.Items.Count; j++)
            {
                checkBoxList.Items[j].Selected = true;
            }
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('权限修改成功！');</script>");
    }
    
}
