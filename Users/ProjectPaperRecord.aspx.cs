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

public partial class Users_ProjectPaperRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!base.IsPostBack)
        {
            if (!base.IsPostBack && base.Request.QueryString["PPID"] != null && base.Request.QueryString["PPID"] != "")
            {
              Label1.Text =base.Request.QueryString["PPID"];
            }
            else
            {
                
            }
           
        }
    }
    

   
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        RecordEntity recordEntity = new RecordEntity();
        RecordBll recordBll = new RecordBll();
        recordEntity.PpID = Convert.ToInt32(Label1.Text);
        recordEntity.PresentDate = DateTime.Now;



        if (this.txtDes.Value != null && this.txtDes.Value != "")
        {
            recordEntity.Des = this.txtDes.Value;
        }
        else
        {
            recordEntity.Des = "";
        }



        if (recordBll.AddRewardProblem(recordEntity))
        {
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('会议记录添加成功');</script>");


            this.txtDes.Value = "";

            base.Response.Redirect("ProjectInternetion.aspx");
            return;
        }
        this.Page.ClientScript.RegisterStartupScript(base.GetType(), "alert", "<script>alert('会议记录添加失败');</script>");
    }
}