using System;
using System.Web;
using Model;
using BLL;
using System.Data;

public partial class Contact_Contact_Contact : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {


        if (base.Session["ClientID"] == null || base.Session["ClientID"].ToString() == "")
        {
            if (this.getCookie("ClientID") != null)
            {
                base.Session["ClientID"] = this.getCookie("ClientID");
                this.delCookie("ClientID");
                return;
            }
            base.Session.Timeout = 10000;
            base.Response.Redirect("../login_1.aspx");
            bind();
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
    public void bind()
    {
        string userID = base.Session["ClientID"].ToString();
        UserEntity userEntity = new UserEntity();
        UserBll userBll = new UserBll();
        userEntity.UserID = userID;
        DataTable byID = userBll.GetByID(userEntity);
        if (byID != null && byID.Rows.Count == 1)
        {
            Label1.Text = byID.Rows[0]["ClientID"].ToString().Trim();
        }
    }
    public static string QqHTML()
    {

        System.Text.StringBuilder str = new System.Text.StringBuilder();
        str.Append("<div id='floatTools' class='float0831'>");
        str.Append("<div class='floatL'>");
        str.Append("	<a  id='aFloatTools_Show' class='btnOpen' title='查看在线客服' onclick=\"javascript:$('#divFloatToolsView').animate({width: 'show', opacity: 'show'}, 'normal',function(){ $('#divFloatToolsView').show();kf_setCookie('RightFloatShown', 0, '', '/', 'www.lanrensc.com'); });$('#aFloatTools_Show').attr('style','display:none');$('#aFloatTools_Hide').attr('style','display:block');\" href=\"javascript:void(0);\">展开</a>");
        str.Append("	<a style=\"DISPLAY: none\" id='aFloatTools_Hide' class='btnCtn' title='关闭在线客服' onclick=\"javascript:$('#divFloatToolsView').animate({width: 'hide', opacity: 'hide'}, 'normal',function(){ $('#divFloatToolsView').hide();kf_setCookie('RightFloatShown', 1, '', '/', 'www.lanrensc.com'); });$('#aFloatTools_Show').attr('style','display:block');$('#aFloatTools_Hide').attr('style','display:none');\" href=\"javascript:void(0);\">收缩</a>");
        str.Append("</div>");
        str.Append("<div id='divFloatToolsView' class='floatR'>");
        str.Append("	<div class='tp'></div>");
        str.Append("	<div class='cn'>");
        str.Append("	<ul>");
        str.Append("		<li class='top'><H3 class='titZx'>QQ咨询</H3></li>");
        str.Append("		<li><a class='icoTc' target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=363905547&site=qq&menu=yes\" title=\"项目咨询-美美\">项目咨询-美美</a></li>");
        str.Append("		<li><a class='icoTc' target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=363905547&site=qq&menu=yes\" title=\"项目咨询-洋洋\">项目咨询-洋洋</a></li>");
        str.Append("        <li><a class='icoTc' target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=363905547&site=qq&menu=yes\" title=\"项目咨询-欢欢\">项目咨询-欢欢</a></li>");
     
        str.Append("	</ul>");
        str.Append("      <ul>");
        str.Append("        <li>");
        str.Append("          <h3 class='titDh'>电话咨询</h3>");
        str.Append("        </li>");
        str.Append("        <li><span class='icoTl'>400-000-0000</span> </li>");
        str.Append("      </ul>");
        str.Append("	</div>");
        str.Append("</div>");
        str.Append("</div>");





        return str.ToString();



    }


}
