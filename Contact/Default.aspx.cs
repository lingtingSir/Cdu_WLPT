using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // MenuDAL.Current.BoundTree(TreeView1.Nodes);
        }
    }

    public string GetMenuString()
    {
        return MenuDAL2.Current.CreateHTML();
    }

    public string GetTreeJSON()
    {
        return ExtTree.Current.CreateExtTreeJSON();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        this.Session.RemoveAll();
        base.Response.Redirect("../login_1.aspx");
    }
}