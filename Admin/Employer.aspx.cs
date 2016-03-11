using System.Collections.Generic;
using BLL;
using Model;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using System.Data;

public partial class Admin_Employer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadData(0, "");
            bind();
            
        }
    }
    private void bind()
    {


        DepartmentBll departmentBll = new DepartmentBll();
        this.OkDepartment.Items.Clear();
        //     this.OkDepartment.Items.Insert(0, "==请选择部门==");
        this.OkDepartment.DataTextField = "DepartmentName";
        this.OkDepartment.DataValueField = "DepartmentID";
        this.OkDepartment.DataSource = departmentBll.GetAll();

        this.OkDepartment.DataBind();
        this.OkDepartment.Items.Insert(0, "==请选择项目组==");
    }

    protected void LoadData(int PPID, string Name)
    {
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        projectPaperEntity.PPID = PPID;
        projectPaperEntity.Name = Name;
        projectPaperBll.Asp(this.GridView1, this.AspNetPager1, projectPaperEntity);
    }
    protected void LoadPage()
    {
        if (this.dropSearch.SelectedIndex != 0)
        {
            this.LoadData(0, this.txtSearch.Text.ToString().Trim());
            return;
        }
        if (this.txtSearch.Text.ToString() == "")
        {
            this.LoadData(0, "");
            return;
        }
        this.LoadData(Convert.ToInt32(this.txtSearch.Text.Trim()), "");
    }
    protected void btSearch_Click1(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBox checkBox = (CheckBox)this.GridView1.Rows[i].FindControl("chkBox");
            if (checkBox != null && checkBox.Checked)
            {
                Label label = (Label)this.GridView1.Rows[i].FindControl("lbID");

                if (label != null)
                {
                    projectPaperEntity.PPID = int.Parse(label.Text.ToString().Trim());
                    projectPaperBll.Delete(projectPaperEntity);
                }
            }
        }
        this.LoadData(0, "");
    }
    protected string getstring()
    {
        Random random = new Random(DateTime.Now.Millisecond);
        return random.Next(10).ToString();
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
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        projectPaperEntity.PPID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
        
        projectPaperBll.Asp2(this.GridView2, this.AspNetPager1, projectPaperEntity);
    //    this.Label2.Text = projectPaperEntity.ClassID.ToString().Trim();
        this.Look.Visible = true;
        this.add.Visible = false;
        
    }
    protected void LinkButton3_Command(object sender, CommandEventArgs e)
    {
        
        this.add.Visible = true;
        this.Look.Visible = false;
        this.Label2.Text = e.CommandArgument.ToString().Trim();
    }
    protected void btOpen_Click1(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string ManagerID = this.Session["ManagerID"].ToString().Trim();
        ManagerBll managerBll = new ManagerBll();
        DataTable byID = managerBll.GetByID(new ManagerEnitity
        {
            ManagerID = ManagerID
        });


       
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        projectPaperEntity.PPID = Convert.ToInt32(Label2.Text);
        projectPaperEntity.ProjectHead = byID.Rows[0]["ManagerName"].ToString().Trim();
        projectPaperEntity.DepartmentId = Convert.ToInt32(this.OkDepartment.SelectedValue);
        projectPaperBll.Update3(projectPaperEntity);
        base.ClientScript.RegisterStartupScript(base.GetType(), "msg", "<script>alert('项目分配成功');</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
}