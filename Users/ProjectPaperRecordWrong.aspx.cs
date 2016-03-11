using BLL;
using Model;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_ProjectPaperRecordWrong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack && base.Request.QueryString["RecordID"] != null && base.Request.QueryString["RecordID"] != "")
        {
            this.bind(Convert.ToInt32(base.Request.QueryString["RecordID"]));
        }
    }
    public void bind(int RecordID)
    {

        RecordEntity recordEntity = new RecordEntity();
        RecordBll recordBll = new RecordBll();
        recordEntity.RecordID = RecordID;

        DataTable byId = recordBll.GetById(recordEntity);
        if (byId.Rows.Count >= 1)
        {
            this.TextBox1.Text = byId.Rows[0]["PresentDate"].ToString();
            this.txtDes.Value = byId.Rows[0]["Des"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        RecordEntity recordEntity = new RecordEntity();
        RecordBll recordBll = new RecordBll();
        recordEntity.RecordID = Convert.ToInt32(base.Request.QueryString["RecordID"]);
        recordEntity.PresentDate = DateTime.Parse(TextBox1.Text);
        recordEntity.Des = this.txtDes.Value;
        if (recordBll.Update(recordEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('修改成功')</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('修改失败')</script>");

        }
        base.Response.Redirect("UserRecordManage.aspx?");
    }
}