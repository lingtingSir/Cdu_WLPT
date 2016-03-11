using BLL;
using FredCK.FCKeditorV2;
using Model;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Admin_EditorProjectPaper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
          
            this.bindPaperType();
        }
    }
    public void bindPaperType()
    {
        PaperTypeEntity en = new PaperTypeEntity();
        PaperTypeBll paperTypeBll = new PaperTypeBll();
        DataTable all = paperTypeBll.GetAll(en);
        this.PaperType.DataTextField = "PTName";
        this.PaperType.DataValueField = "PTID";
        this.PaperType.DataSource = all.DefaultView;
        this.PaperType.DataBind();
        this.PaperType.Items.Insert(0, "==请选择项目类型==");
    }
    
    protected void addPaper_Click(object sender, EventArgs e)
    {
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        projectPaperEntity.Name = this.Name.Text.Trim();
        
        if (this.PaperType.SelectedIndex <= 0)
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('必须选择项目类型');</script>");
            return;
        }
        projectPaperEntity.PTID = int.Parse(this.PaperType.SelectedValue);
       
        if (this.FCKeditor1.Value != null && this.FCKeditor1.Value != "")
        {
            projectPaperEntity.PPDesc = this.FCKeditor1.Value;
        }
        else
        {
            projectPaperEntity.PPDesc = "";
        }

        projectPaperEntity.SelfResource = "";
        projectPaperEntity.RegisterDate = DateTime.Parse(TextBox1.Text);
        projectPaperEntity.OverDate = DateTime.Parse(TextBox2.Text);

        if (projectPaperBll.Add2(projectPaperEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('项目添加成功');</script>");
            this.bindPaperType();
            
            this.FCKeditor1.Value = "";
            this.Name.Text = "";
            base.Response.Redirect("ProjectInternetion.aspx");
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加失败');</script>");
    }
    protected void PRKIDList_TextChanged(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}