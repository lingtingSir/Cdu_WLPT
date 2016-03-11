using BLL;
using Model;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_ProjectPaperView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack && base.Request.QueryString["PPID"] != null && base.Request.QueryString["PPID"] != "")
        {
            this.bind(Convert.ToInt32(base.Request.QueryString["PPID"]));
        }
    }
    public void bind(int PPID)
    {

        ProjectPaperEntity en = new ProjectPaperEntity();
        ProjectPaperBll projectPaperBll = new ProjectPaperBll();
        en.PPID = PPID;
        DataTable byId = projectPaperBll.GetById(en);
        if (byId.Rows.Count >= 1)
        {

            this.Name.Text = byId.Rows[0]["Name"].ToString();
            this.PaperType.Items.Insert(0, byId.Rows[0]["PTName"].ToString());

            this.TextBox1.Text = byId.Rows[0]["RegisterDate"].ToString();
            this.TextBox2.Text = byId.Rows[0]["OverDate"].ToString();
            this.TextBox3.Text = byId.Rows[0]["FhdateTime"].ToString();
            this.FCKeditor1.Value = byId.Rows[0]["PPDesc"].ToString();
        }
    }
}