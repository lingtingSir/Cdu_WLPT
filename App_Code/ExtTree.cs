using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Hosting;

/// <summary>
/// ExtTree 的摘要说明
/// </summary>
public class ExtTree
{
    private string _XMLpath;
    private static ExtTree extTree;
    public static ExtTree Current
    {
        get
        {
            if (ExtTree.extTree == null)
            {
                ExtTree.extTree = new ExtTree();
            }
            return ExtTree.extTree;
        }
    }
    private ExtTree()
    {
        this.InitXMLpath();
    }
    private void InitXMLpath()
    {
        string virtualPath = "~/app_data/tree.xml";
        this._XMLpath = HostingEnvironment.MapPath(virtualPath);
        FileIOPermission fileIOPermission = new FileIOPermission(FileIOPermissionAccess.Write, this._XMLpath);
        fileIOPermission.Demand();
    }
    private DataTable GetAllNodes()
    {
        DataSet dataSet = new DataSet();
        dataSet.ReadXml(this._XMLpath);
        return dataSet.Tables[0];
    }
    private DataTable GetAllNodes(string parentid)
    {
        DataTable allNodes = this.GetAllNodes();
        DataTable dataTable = allNodes.Clone();
        foreach (DataRow dataRow in allNodes.Rows)
        {
            if (dataRow["parentid"].ToString() == parentid.ToString())
            {
                dataTable.Rows.Add(dataRow.ItemArray);
            }
        }
        return dataTable;
    }
    public string CreateExtTreeJSON()
    {
        StringBuilder stringBuilder = new StringBuilder();
        this.CreateExtTreeNode(stringBuilder);
        string text = stringBuilder.ToString();
        return text.Replace("}{", "},{");
    }
    private void CreateExtTreeNode(StringBuilder sb)
    {
        DataTable allNodes = this.GetAllNodes("0");
        if (allNodes.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow dataRow in allNodes.Rows)
            {
                sb.Append("{");
                sb.Append("text:'" + dataRow["title"].ToString() + "',");
                sb.Append("id:'node" + dataRow["id"].ToString() + "'");
                this.AddChildrenNode(this.GetAllNodes(dataRow["id"].ToString()), sb);
                sb.Append("}");
            }
        }
        sb.Append("]");
    }
    private void AddChildrenNode(DataTable dt, StringBuilder sb)
    {
        if (dt.Rows.Count > 0)
        {
            sb.Append(",leaf:false,children:[");
            foreach (DataRow dataRow in dt.Rows)
            {
                sb.Append("{");
                sb.Append("text:'" + dataRow["title"].ToString() + "',");
                sb.Append("id:'node" + dataRow["id"].ToString() + "',");
                sb.Append("href:'" + dataRow["url"].ToString() + "',");
                sb.Append("hrefTarget:'main'");
                this.AddChildrenNode(this.GetAllNodes(dataRow["id"].ToString()), sb);
                sb.Append("}");
            }
            sb.Append("]");
            return;
        }
        sb.Append(",leaf:true");
    }
}