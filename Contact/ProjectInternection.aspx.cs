using Model;
using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using System.Data;
using BLL;
public partial class Contact_Contact_ProjectInternection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LoadData(0, "");
        }
    }
    protected void LoadData(int PPID, string Name)
    {
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        projectPaperEntity.PPID = PPID;
        projectPaperEntity.Name = Name;
        projectPaperEntity.ClientID = base.Session["ClientID"].ToString(); ;
        projectPaperBll.Asp5(this.GridView1, this.AspNetPager1, projectPaperEntity);
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
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.GridView1.EditIndex = -1;
        this.LoadData(0, "");
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        this.LoadData(0, "");
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].FindControl("lbID");
        TextBox textBox = (TextBox)this.GridView1.Rows[e.RowIndex].FindControl("txtName");
        DropDownList CboTP2;
        CboTP2 = (DropDownList)this.GridView1.Rows[e.RowIndex].FindControl("CboTP2");


        if (label != null && textBox != null)
        {
            projectPaperEntity.PPID = Convert.ToInt32(label.Text.ToString());
            //   projectPaperEntity.PTID = txtName2;


            projectPaperEntity.PTID = int.Parse(CboTP2.SelectedValue);
            projectPaperEntity.Name = textBox.Text.ToString();
            projectPaperEntity.FhdateTime = DateTime.Now;
            if (projectPaperBll.Update2(projectPaperEntity))
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('更新成功');", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('更新失败');", true);
            }
        }
        this.GridView1.EditIndex = -1;
        this.LoadData(0, "");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].Cells[1].FindControl("lbID");
        int num = int.Parse(label.Text.ToString());

        projectPaperEntity.PPID = num;
        if (projectPaperBll.Delete(projectPaperEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('删除成功');", true);
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('删除失败');", true);
        }
        this.LoadData(0, "");
        return;


    }
    protected void btSearch_Click1(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        this.LoadPage();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
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
}