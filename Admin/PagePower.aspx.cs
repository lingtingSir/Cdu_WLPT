using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Dal;
using BLL;
public partial class PagePower : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadData("", "", 0, 0);
            this.LoadDrop();
        }
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
        this.dropPower.Items.Clear();
        DepartmentBll departmentBll = new DepartmentBll();
        this.dropDepartment.DataTextField = "DepartmentName";
        this.dropDepartment.DataValueField = "DepartmentID";
        this.dropDepartment.DataSource = departmentBll.GetAll();
        this.dropDepartment.DataBind();
        this.dropDepartment.Items.Insert(0, "===请选择项目组===");
        PowerBll powerBll = new PowerBll();
        this.dropPower.DataTextField = "PowerName";
        this.dropPower.DataValueField = "PowerID";
        this.dropPower.DataSource = powerBll.GetAll();
        this.dropPower.DataBind();
        this.dropPower.Items.Insert(0,"====请选择角色====");
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
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        ManagerPagePowerBll teacherPagePowerBll = new ManagerPagePowerBll();
        teacherPagePowerBll.DeleteByManager(new ManagerPagePowerEnitity
        {
            ManagerID = e.CommandArgument.ToString().Trim()
        });
        this.LoadPage();
    }
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        LinkButton linkButton = (LinkButton)sender;
        int index = int.Parse(e.CommandName.ToString());
        GridView gridView = (GridView)this.GridView1.Rows[index].FindControl("GridView2");
        if (gridView != null)
        {
            if (!gridView.Visible)
            {
                gridView.Visible = true;
                linkButton.Text = "关闭";
                return;
            }
            gridView.Visible = false;
            linkButton.Text = "查看";
        }
    }
    protected void btSearch_Click1(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gridView = (GridView)e.Row.FindControl("GridView2");
            Label label = (Label)e.Row.FindControl("lbID");
            if (gridView != null && label != null)
            {
                ManagerPagePowerBll teacherPagePowerBll = new ManagerPagePowerBll();
                gridView.DataSource = teacherPagePowerBll.GetByTeacher(new ManagerPagePowerEnitity
                {
                    ManagerID = label.Text
                }, 0);
                gridView.DataBind();
            }
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ManagerPagePowerBll teacherPagePowerBll = new ManagerPagePowerBll();
            ManagerPagePowerEnitity teacherPagePowerEntity = new ManagerPagePowerEnitity();
            DataList dataList = (DataList)e.Row.FindControl("DataList1");
            LinkButton linkButton = (LinkButton)e.Row.FindControl("lkPages");
            Label label = (Label)e.Row.FindControl("lbID");
            if (dataList != null && linkButton != null && label != null)
            {
                int i = int.Parse(linkButton.CommandArgument.ToString());
                teacherPagePowerEntity.ManagerID = label.Text;
                dataList.DataSource = teacherPagePowerBll.GetByTeacher(teacherPagePowerEntity, i);
                dataList.DataBind();
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