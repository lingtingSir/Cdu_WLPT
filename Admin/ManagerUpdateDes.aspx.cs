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
using System.IO;
public partial class Admin_ManagerUpdateDes : System.Web.UI.Page
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
        string managerID = this.Session["ManagerID"].ToString().Trim();
        ManagerBll managerBll = new ManagerBll();
        ManagerEnitity managerEntity = new ManagerEnitity();
        managerEntity.ManagerID = managerID;
        managerEntity.ManagerName = base.Server.HtmlEncode(this.txtName.Text.Trim());
        managerEntity.ManagerDes = base.Server.HtmlEncode(this.txtDes.Text.Trim());
        managerEntity.DepartmentID = Convert.ToInt32(this.lbDepartmentID.Text.Trim());
        managerEntity.PowerID = Convert.ToInt32(this.lbPowerID.Text.Trim());
        string fileName = this.upFileUpLoad.FileName;
        if (fileName == "")
        {
            managerEntity.ManagerImage = this.lbImage.Text.Trim();
        }
        else
        {
            if (this.lbImage.Text.Trim() != "")
            {
                File.Delete(base.Server.MapPath("~/" + this.lbImage.Text.Trim()));
            }
            string str = DateTime.Now.ToString("yyyyMMddHHmmssms") + Path.GetExtension(fileName);
            this.upFileUpLoad.SaveAs(base.Server.MapPath("~/ManagerImage/" + str));
            managerEntity.ManagerImage = "ManagerImage/" + str;
        }
        if (managerBll.Update(managerEntity))
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
        string ManagerID = this.Session["ManagerID"].ToString().Trim();
        ManagerBll managerBll = new ManagerBll();
        DataTable byID = managerBll.GetByID(new ManagerEnitity
        {
            ManagerID = ManagerID
        });
        if (byID != null && byID.Rows.Count == 1)
        {
            this.lbID.Text = byID.Rows[0]["ManagerID"].ToString().Trim();
            this.txtName.Text = byID.Rows[0]["ManagerName"].ToString().Trim();
            this.lbDepartmentName.Text = byID.Rows[0]["DepartmentName"].ToString().Trim();
            this.lbDepartmentID.Text = byID.Rows[0]["DepartmentID"].ToString().Trim();
            this.lbPowerName.Text = byID.Rows[0]["PowerName"].ToString().Trim();
            this.lbPowerID.Text = byID.Rows[0]["PowerID"].ToString().Trim();
            this.upImage.ImageUrl = "~/" + byID.Rows[0]["ManagerImage"].ToString().Trim();
            this.txtDes.Text = byID.Rows[0]["ManagerDes"].ToString().Trim();
            this.lbImage.Text = byID.Rows[0]["ManagerImage"].ToString().Trim();
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