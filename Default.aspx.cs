using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Dal;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            bind();

        }
    }
    private void bind()
    {
        DataTable dt = new DataTable();
        ManagerEnitity en = new ManagerEnitity();
        ManagerBll enBLL = new ManagerBll();

        en.ManagerID = this.Session["ManagerID"].ToString();
        dt = enBLL.select(en);

        lbName.Text = dt.Rows[0]["ManagerName"].ToString();
    }
    public string GetMenuString()
    {
        if (this.Session["AdminID"] != null)
        {
            return MenuDAL.Current.CreateHTML(this.Session["AdminID"].ToString());
        }
        if (this.Session["ManagerID"] != null)
        {
            return MenuDAL.Current.CreateHTML(this.Session["ManagerID"].ToString());
        }
        base.Response.Redirect("login_1.aspx");
        return null;
    }
    public string GetTreeJSON()
    {
        return ExtTree.Current.CreateExtTreeJSON();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        this.Session.RemoveAll();
        base.Response.Redirect("login_1.aspx");
    }
}