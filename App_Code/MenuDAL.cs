using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Model;
using Dal;
using BLL;
/// <summary>
/// MenuDAL 的摘要说明
/// </summary>
public class MenuDAL
{
    private static MenuDAL dal=null;
    private static string managerid="";
    public static MenuDAL Current
    {
        get{
            if(MenuDAL.dal==null)
            {
                MenuDAL.dal = new MenuDAL();
            }
            return MenuDAL.dal;
        }
    }
	private MenuDAL()
	{
	}
	private DataTable GetAllMenus()
	{
        ManagerPagePowerBll teacherPagePowerBll = new ManagerPagePowerBll();
        return teacherPagePowerBll.GetByManager(new ManagerPagePowerEnitity
		{
            ManagerID = MenuDAL.managerid
		});
	}
	private DataTable GetAllMenus(int parentid)
	{
		DataTable allMenus = this.GetAllMenus();
		DataTable dataTable = allMenus.Clone();
		foreach (DataRow dataRow in allMenus.Rows)
		{
			if (dataRow["parentid"].ToString() == parentid.ToString())
			{
				dataTable.Rows.Add(dataRow.ItemArray);
			}
		}
		return dataTable;
	}
	public string CreateHTML(string tid)
	{
        MenuDAL.managerid = tid;
		StringBuilder stringBuilder = new StringBuilder();
		DataTable allMenus = this.GetAllMenus(0);
		foreach (DataRow dataRow in allMenus.Rows)
		{
			stringBuilder.Append("{title:'" + dataRow["title"].ToString() + "',autoScroll:true,border:false,iconCls:'nav',");
			DataTable allMenus2 = this.GetAllMenus(int.Parse(dataRow["id"].ToString()));
			if (allMenus2.Rows.Count > 0)
			{
				string text = "<ul class=\"LeftNav\">";
				foreach (DataRow dataRow2 in allMenus2.Rows)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"<li><a target=\"main\" href=\"",
						dataRow2["url"].ToString(),
						"\"> ",
						dataRow2["title"].ToString(),
						"</a></li>"
					});
				}
				if (text != "<ul>")
				{
					text += "</ul>";
					stringBuilder.Append("html:'" + text + "'}");
				}
				else
				{
					stringBuilder.Append("html:''}");
				}
			}
			else
			{
				stringBuilder.Append("html:''}");
			}
			stringBuilder.Append(",");
		}
		return stringBuilder.ToString().TrimEnd(new char[]
		{
			','
		});
	}
	public void BoundTree(TreeNodeCollection nodes)
	{
		DataTable allMenus = this.GetAllMenus(0);
		foreach (DataRow dataRow in allMenus.Rows)
		{
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["title"].ToString();
			treeNode.Value = dataRow["id"].ToString();
			treeNode.SelectAction = TreeNodeSelectAction.SelectExpand;
			nodes.Add(treeNode);
			DataTable allMenus2 = this.GetAllMenus(int.Parse(dataRow["id"].ToString()));
			if (allMenus2.Rows.Count > 0)
			{
				foreach (DataRow dataRow2 in allMenus2.Rows)
				{
					TreeNode treeNode2 = new TreeNode();
					treeNode2.Text = dataRow2["title"].ToString();
					treeNode2.NavigateUrl = dataRow2["url"].ToString();
					treeNode2.Target = "main";
					treeNode2.Value = dataRow2["id"].ToString();
					treeNode2.SelectAction = TreeNodeSelectAction.SelectExpand;
					treeNode.ChildNodes.Add(treeNode2);
				}
			}
		}
	}
}