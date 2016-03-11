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

public partial class Contact_EditorProjectPaper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            
            this.bindPaperType();
            this.bind();
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
        projectPaperEntity.PPID = Convert.ToInt32(base.Request.QueryString["PPID"]);
        projectPaperEntity.SelfResource = "";
        projectPaperEntity.RegisterDate = DateTime.Parse(TextBox1.Text);
        projectPaperEntity.OverDate = DateTime.Parse(TextBox2.Text);

        if (projectPaperBll.Update6(projectPaperEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('项目添加成功');</script>");
            this.bindPaperType();

            this.FCKeditor1.Value = "";
            this.Name.Text = "";
            base.Response.Redirect("ProjectInternection.aspx");
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加失败');</script>");
    }
    
    public void bind()
    {
       
        ProjectPaperEntity projectPaperEntity = new ProjectPaperEntity();
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        projectPaperEntity.PPID = Convert.ToInt32(base.Request.QueryString["PPID"]);
        DataTable byID = projectPaperBll.GetById(projectPaperEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            this.Name.Text = byID.Rows[0]["Name"].ToString();
         

            this.TextBox1.Text = byID.Rows[0]["RegisterDate"].ToString();
            this.TextBox2.Text = byID.Rows[0]["OverDate"].ToString();
            this.PaperType.Items.Insert(0, byID.Rows[0]["PTName"].ToString());
            this.FCKeditor1.Value = byID.Rows[0]["PPDesc"].ToString();
        }
    } 
    protected void Button1_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Default.aspx");
    }
}