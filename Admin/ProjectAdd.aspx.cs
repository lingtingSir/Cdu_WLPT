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

public partial class Admin_ProjectAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.bindPRKIDList();
            this.bindPaperType();
        }
    }
    public void bindPaperType()
    {
        PaperTypeEntity en = new PaperTypeEntity();
        PaperTypeBll paperTypeBll = new PaperTypeBll();
        DataTable all = paperTypeBll.GetAll(en);
        this.PaperType.DataTextField = "Name";
        this.PaperType.DataValueField = "PTID";
        this.PaperType.DataSource = all.DefaultView;
        this.PaperType.DataBind();
        this.PaperType.Items.Insert(0, "==请选择试卷类型==");
    }
    public void bindPRKIDList()
    {
        ProblemResourceKindBll problemResourceKindBll = new ProblemResourceKindBll();
        this.PRKIDList.DataTextField = "Name";
        this.PRKIDList.DataValueField = "PRKID";
        this.PRKIDList.DataSource = problemResourceKindBll.getDropDownListDataTableBind().DefaultView;
        this.PRKIDList.DataBind();
        this.PRKIDList.Items.Insert(0, "===请选择试卷来源类别===");
        ListItem listItem = new ListItem();
        listItem.Value = "0";
        listItem.Text = "===请选择试卷来源类别===";
        this.PRKIDList.Items.Contains(listItem);
    }
    protected void addPaper_Click(object sender, EventArgs e)
    {
        ProjectPaperBll problemPaperBll = new ProjectPaperBll();
        ProjectPaperEntity problemPaperEntity = new ProjectPaperEntity();
        problemPaperEntity.Name = this.Name.Text.Trim();
        if (this.PRKIDList.SelectedIndex <= 0)
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('必须选择试卷类型');</script>");
            return;
        }
        
        if (this.PaperType.SelectedIndex <= 0)
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('必须选择试卷来源类型');</script>");
            return;
        }
        problemPaperEntity.PTID = Convert.ToInt32(this.PaperType.SelectedValue);
       
        if (this.FCKeditor1.Value != null && this.FCKeditor1.Value != "")
        {
            problemPaperEntity.PPDesc = this.FCKeditor1.Value;
        }
        else
        {
            problemPaperEntity.PPDesc = "";
        }
        
        problemPaperEntity.SelfResource = "";
        problemPaperEntity.FhdateTime = DateTime.Now;
        if (problemPaperBll.Add(problemPaperEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('项目添加成功');</script>");
            this.bindPaperType();
            this.bindPRKIDList();
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
}