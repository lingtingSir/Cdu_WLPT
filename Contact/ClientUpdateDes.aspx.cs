using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Dal;
using BLL;
using System.IO;


public partial class Contact_ClientUpdateDes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    protected void btOK_Click1(object sender, EventArgs e)
    {
        string ClientID = this.Session["ClientID"].ToString().Trim();
        ClientBll ClientBll = new ClientBll();
        ClientEntity ClientEntity = new ClientEntity();
        ClientEntity.ClientID = ClientID;
        ClientEntity.ClientName = base.Server.HtmlEncode(this.txtName.Text.Trim());
        ClientEntity.ClientDes = base.Server.HtmlEncode(this.txtDes.Text.Trim());
      
        string fileName = this.upFileUpLoad.FileName;
        if (fileName == "")
        {
            ClientEntity.ClientImage = this.lbImage.Text.Trim();
        }
        else
        {
            if (this.lbImage.Text.Trim() != "")
            {
                File.Delete(base.Server.MapPath("~/" + this.lbImage.Text.Trim()));
            }
            string str = DateTime.Now.ToString("yyyyMMddHHmmssms") + Path.GetExtension(fileName);
            this.upFileUpLoad.SaveAs(base.Server.MapPath("~/ClientImage/" + str));
            ClientEntity.ClientImage = "ClientImage/" + str;
        }
        if (ClientBll.Update(ClientEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('成功');</script>");
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('失败');</script>");
        }
        this.LoadData();
        this.RegularExpressionValidator1.Visible = false;
        this.upFileUpLoad.Visible = false;
    }
    public void LoadData()
    {
        string ClientID = this.Session["ClientID"].ToString().Trim();
        ClientBll ClientBll = new ClientBll();
        DataTable byID = ClientBll.GetByID(new ClientEntity
        {
            ClientID = ClientID
        });
        if (byID != null && byID.Rows.Count == 1)
        {
            this.lbID.Text = byID.Rows[0]["ClientID"].ToString().Trim();
            this.txtName.Text = byID.Rows[0]["ClientName"].ToString().Trim();
            
            this.upImage.ImageUrl = "~/" + byID.Rows[0]["ClientImage"].ToString().Trim();
            this.txtDes.Text = byID.Rows[0]["ClientDes"].ToString().Trim();
            this.lbImage.Text = byID.Rows[0]["ClientImage"].ToString().Trim();
        }
    }
    protected void IsOK_Click(object sender, EventArgs e)
    {
        this.upFileUpLoad.Visible = true;
        this.RegularExpressionValidator1.Visible = true;
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        this.RegularExpressionValidator1.Visible = false;
        this.LoadData();
        this.upFileUpLoad.Visible = false;
    }
}