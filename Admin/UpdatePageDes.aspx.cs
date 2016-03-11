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
public partial class Admin_UpdatePageDes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
        if(!IsPostBack)
        {
            PageBll pageBll = new PageBll();
            PagesEnitity pageEnitity = new PagesEnitity();
            if(Request.QueryString["id"]!=null && Request.QueryString["id"].ToString().Length>0)
            {
                pageEnitity.Id = int.Parse(Request.QueryString["id"].ToString());
                DataTable byID = pageBll.GetByID(pageEnitity);
                if (byID != null && byID.Rows.Count == 0)
                {
                    this.txtDes.Value = byID.Rows[0]["PageDes"].ToString();
                    this.lbParent.Text = byID.Rows[0]["ParentID"].ToString();
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PageBll pageBll = new PageBll();
        pageBll.Update_Des(new PagesEnitity
        {
            Id = int.Parse(base.Request.QueryString["id"].ToString()),
            PageDes = this.txtDes.Value
        });
        base.Response.Redirect("PageManager.aspx?id=" + this.lbParent.Text);
    }
}