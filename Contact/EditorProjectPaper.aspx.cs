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

        if (this.txtDes.Value != null && this.txtDes.Value != "")
        {
            projectPaperEntity.PPDesc = this.txtDes.Value;
        }
        else
        {
            projectPaperEntity.PPDesc = "";
        }
        projectPaperEntity.ClientID = base.Session["ClientID"].ToString();
        projectPaperEntity.SelfResource = "";
        projectPaperEntity.RegisterDate = DateTime.Parse(TextBox1.Text);
        projectPaperEntity.OverDate = DateTime.Parse(TextBox2.Text);

        if (projectPaperBll.Add(projectPaperEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('项目添加成功');</script>");
            this.bindPaperType();

            this.txtDes.Value = "";
            this.Name.Text = "";
            base.Response.Redirect("ProjectInternection.aspx");
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('添加失败');</script>");
    }
    /*
    public void bind()
    {
        string userID = base.Session["ClientID"].ToString();
        UserEntity userEntity = new UserEntity();
        UserBll userBll = new UserBll();
        userEntity.UserID = userID;
        DataTable byID = userBll.GetByID(userEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            Label2.Text = byID.Rows[0]["ClientID"].ToString().Trim();
        }
    } */
    protected void Button1_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Default.aspx");
    }
}