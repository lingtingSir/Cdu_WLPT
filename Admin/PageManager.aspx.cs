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
public partial class Admin_PageManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.bind();
        }
    }
    private void bind()
    {
        int parentID = 0;
        if (base.Request.QueryString["id"] != null)
        {
            parentID = int.Parse(base.Request.QueryString["id"].ToString());
            this.GridView1.Columns[2].Visible = false;
            this.GridView1.Columns[3].Visible = true;
        }
        PageBll pageBll = new PageBll();
        PagesEnitity pageEntity = new PagesEnitity();
        pageEntity.ParentID = parentID;
        this.GridView1.DataSource = pageBll.GetByParent(pageEntity);
        this.GridView1.DataBind();
    }
    
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.GridView1.EditIndex = -1;
        this.bind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.GridView1.EditIndex = e.NewEditIndex;
        this.bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        PageBll pageBll = new PageBll();
        PagesEnitity pageEntity = new PagesEnitity();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].FindControl("lbID");
        TextBox textBox = (TextBox)this.GridView1.Rows[e.RowIndex].FindControl("txtName1");
        TextBox textBox2 = (TextBox)this.GridView1.Rows[e.RowIndex].FindControl("txtUrl");
        TextBox textBox3 = (TextBox)this.GridView1.Rows[e.RowIndex].FindControl("txtSort");
        if (label != null && textBox != null && textBox2 != null && textBox3 != null)
        {
            pageEntity.PageName = textBox.Text;
            pageEntity.PageSort = int.Parse(textBox3.Text);
            pageEntity.PageURL = textBox2.Text;
            pageEntity.Id = int.Parse(label.Text);
            if (pageBll.Update(pageEntity))
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('更新成功');", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('更新失败');", true);
            }
        }
        this.GridView1.EditIndex = -1;
        this.bind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        PageBll pageBll = new PageBll();
        PagesEnitity pageEntity = new PagesEnitity();
        Label label = (Label)this.GridView1.Rows[e.RowIndex].Cells[1].FindControl("lbID");
        if (label != null)
        {
            pageEntity.Id = int.Parse(label.Text);
            int childCount = pageBll.GetChildCount(pageEntity);
            if (childCount > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('有子项不允许删除！');", true);
            }
            else
            {
                if (pageBll.Delete(pageEntity))
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('删除成功');", true);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('删除失败');", true);
                }
            }
            this.bind();
        }
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "msg", "alert('该数据是基本数据，不能批量删除');", true);
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
    protected string getstring()
    {
        Random random = new Random(DateTime.Now.Millisecond);
        return random.Next(10).ToString();
    }
    protected void ImagesButton1_Click(object sender, EventArgs e)
    {
        if (this.Session["ManageLand"].ToString() == this.txtCode.Text)
        {
            PageBll pageBll = new PageBll();
            PagesEnitity pageEntity = new PagesEnitity();
            new DataBase();
            int num = 0;
            int pID = 0;
            string pageName = base.Server.HtmlEncode(this.txtName.Text);
            string pageUrl = base.Server.HtmlEncode(this.txtDes.Text);
            if (base.Request.QueryString["id"] != null)
            {
                num = int.Parse(base.Request.QueryString["id"].ToString());
                pageEntity.Id = num;
                DataTable byID = pageBll.GetByID(pageEntity);
                if (byID != null && byID.Rows.Count == 1)
                {
                    pID = int.Parse(byID.Rows[0]["PageSort"].ToString());
                }
            }
            pageEntity.ParentID = num;
            pageEntity.PageSort = pageBll.GetMaxSort(pageEntity);
            pageEntity.PID = pID;
            pageEntity.PageName = pageName;
            pageEntity.PageURL = pageUrl;
            pageBll.Add(pageEntity);
            this.txtDes.Text = "";
            this.txtName.Text = "";
            this.bind();
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('验证码错误')</script>");
    }
}