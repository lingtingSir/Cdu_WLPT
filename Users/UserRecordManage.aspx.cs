using BLL;
using Model;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

public partial class Users_UserRecordManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.IsQue();
        }
    }
    private void IsQue()
    {
        if (base.Request.QueryString["id"] == null || base.Request.QueryString["id"].ToString() == "")
        {
            base.Response.Redirect("UserIndex.aspx");
            return;
        }
        this.ViewState["id"] = base.Request.QueryString["id"].ToString();
        BindView2();
    }
    private void BindView2()
    {
        RecordEntity userIntegralDetailEntity = new RecordEntity();
        RecordBll userIntegralDetailBll = new RecordBll();

        userIntegralDetailEntity.PpID = Convert.ToInt32(this.ViewState["id"]);
        userIntegralDetailBll.Asp(this.GridView2, this.AspNetPager2, userIntegralDetailEntity);
        ProjectPaperEntity userEntity = new ProjectPaperEntity();
        ProjectPaperBll userBll = new ProjectPaperBll();
        userEntity.PPID = Convert.ToInt32(this.ViewState["id"]);
        DataTable byID = userBll.GetById(userEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            this.Label1.Text = byID.Rows[0]["Name"].ToString();

        }
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        this.BindView2();
    }
}