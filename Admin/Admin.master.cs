using System;
using System.Web;
using Model;
using BLL;
using System.Data;
public partial class Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {
       

        if (base.Session["ManagerID"] == null || base.Session["ManagerID"].ToString() == "")
        {
            if (this.getCookie("ManagerID") != null)
            {
                base.Session["ManagerID"] = this.getCookie("ManagerID");
                this.delCookie("ManagerID");
                return;
            }
            base.Session.Timeout = 10000;
            base.Response.Redirect("../login.aspx");
        }
    }
    public bool setCookie(string strName, string strValue, int strDay)
    {
        bool result;
        try
        {
            HttpCookie httpCookie = new HttpCookie(strName);
            httpCookie.Expires = DateTime.Now.AddDays((double)strDay);
            httpCookie.Value = strValue;
            HttpContext.Current.Response.Cookies.Add(httpCookie);
            result = true;
        }
        catch
        {
            result = false;
        }
        return result;
    }
    public string getCookie(string strName)
    {
        HttpCookie httpCookie = HttpContext.Current.Request.Cookies[strName];
        if (httpCookie != null)
        {
            return httpCookie.Value.ToString();
        }
        return null;
    }
    public bool delCookie(string strName)
    {
        bool result;
        try
        {
            HttpCookie httpCookie = new HttpCookie(strName);
            httpCookie.Expires = DateTime.Now.AddDays(-1.0);
            HttpContext.Current.Response.Cookies.Add(httpCookie);
            result = true;
        }
        catch
        {
            result = false;
        }
        return result;
    }
    public void CheckPagePower()
    {
    }
    protected void ContentPlaceHolder1_Init(object sender, EventArgs e)
    {
        this.CheckPagePower();
    }
    protected string GetPageDes(string url)
    {
        if (url.LastIndexOf("?") > 0)
        {
            url = url.Substring(0, url.LastIndexOf("?"));
        }
        int length = url.LastIndexOf("/");
        string text = url.Substring(0, length);
        url = url.Substring(text.LastIndexOf("/") + 1);
        PageBll pageBll = new PageBll();
        DataTable byUrl = pageBll.GetByUrl(new PagesEnitity
        {
            PageURL = url
        });
        if (byUrl != null && byUrl.Rows.Count == 1)
        {
            return byUrl.Rows[0]["PageDes"].ToString();
        }
        return "";
    }
}
