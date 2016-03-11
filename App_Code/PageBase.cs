using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using WebSystem.WebControls.ExtendControl;
/// <summary>
/// PageBase 的摘要说明
/// </summary>
 public class PageBase
{
    public class PageBase2 : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                if (PageManager.Instance != null)
                {
                    HttpCookie themeCookie = Request.Cookies["Theme"];
                    if (themeCookie != null)
                    {
                        string themeValue = themeCookie.Value;
                        PageManager.Instance.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }

                    HttpCookie langCookie = Request.Cookies["Language"];
                    if (langCookie != null)
                    {
                        string langValue = langCookie.Value;
                        PageManager.Instance.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                    }
                }
            }


            //#if DEBUG
            //            if (!(this is _default) && !(this is source))
            //            {
            //                WebSystem.WebControls.ExtendControl.LinkButton btnPostback = new WebSystem.WebControls.ExtendControl.LinkButton();
            //                btnPostback.Text = "<span title=\"Postback this page without AJAX - only for DEBUG usage.\">&nbsp;&nbsp;&nbsp;&nbsp;</span>";
            //                btnPostback.EnableAjax = false;
            //                btnPostback.CssStyle = "position: absolute; left: 0px; bottom: 0px; background-color: #EFF6FF;";
            //                Page.Form.Controls.Add(btnPostback);
            //            }

            //#endif

        }

        #region Grid related section

        protected string HowManyRowsAreSelected(Grid grid)
        {
            StringBuilder sb = new StringBuilder();
            int selectedCount = grid.SelectedRowIndexArray.Length;
            if (selectedCount > 0)
            {
                sb.AppendFormat("Selected rows ({0}): ", selectedCount);
                sb.Append("<table class=\"result\"><tbody>");

                // Table header
                sb.Append("<tr><th>index</th>");
                foreach (string datakey in grid.DataKeyNames)
                {
                    sb.AppendFormat("<th>{0}</th>", datakey);
                }
                sb.Append("</tr>");

                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = grid.SelectedRowIndexArray[i];
                    sb.AppendFormat("<tr><td>{0}</td>", rowIndex);

                    // If allow paging, not database paging.
                    if (grid.AllowPaging && !grid.IsDatabasePaging)
                    {
                        rowIndex = grid.PageIndex * grid.PageSize + rowIndex;
                    }

                    foreach (object key in grid.DataKeys[rowIndex])
                    {
                        sb.AppendFormat("<td>{0}</td>", key);
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
            }
            else
            {
                sb.Append("No row was selected.");
            }

            return sb.ToString();
        }

        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("MyText", typeof(String)));
            table.Columns.Add(new DataColumn("MyValue", typeof(String)));
            table.Columns.Add(new DataColumn("Year", typeof(String)));
            table.Columns.Add(new DataColumn("MyCheckBox", typeof(bool)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "Nancy";
            row[2] = "1";
            row[3] = "2008";
            row[4] = true;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "Andrew";
            row[2] = "2";
            row[3] = "2007";
            row[4] = true;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "Janet";
            row[2] = "3";
            row[3] = "2006";
            row[4] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 104;
            row[1] = "Margaret";
            row[2] = "4";
            row[3] = "2005";
            row[4] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 105;
            row[1] = "Steven";
            row[2] = "5";
            row[3] = "2004";
            row[4] = true;
            table.Rows.Add(row);

            return table;
        }

        protected DataTable GetEmptyDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("MyText", typeof(String)));
            table.Columns.Add(new DataColumn("MyValue", typeof(String)));
            table.Columns.Add(new DataColumn("Year", typeof(String)));
            table.Columns.Add(new DataColumn("MyCheckBox", typeof(bool)));


            return table;
        }


        #region old code
        //private List<MyClass> GetCustomList()
        //{
        //    List<MyClass> list = new List<MyClass>();

        //    list.Add(new MyClass(101, 1, "Nancy", "2008", true));
        //    list.Add(new MyClass(102, 2, "Andrew", "2007", false));
        //    list.Add(new MyClass(103, 3, "Janet", "2006", false));
        //    list.Add(new MyClass(104, 4, "Margaret", "2005", true));
        //    list.Add(new MyClass(105, 5, "Steven", "2004", true));

        //    return list;
        //}

        //public class MyClass
        //{
        //    private int _myValue;

        //    public int MyValue
        //    {
        //        get { return _myValue; }
        //        set { _myValue = value; }
        //    }
        //    private string _myText;

        //    public string MyText
        //    {
        //        get { return _myText; }
        //        set { _myText = value; }
        //    }

        //    private string _year;

        //    public string Year
        //    {
        //        get { return _year; }
        //        set { _year = value; }
        //    }

        //    private int _id;

        //    public int Id
        //    {
        //        get { return _id; }
        //        set { _id = value; }
        //    }

        //    private bool _myCheckBox;

        //    public bool MyCheckBox
        //    {
        //        get { return _myCheckBox; }
        //        set { _myCheckBox = value; }
        //    }

        //    public MyClass(int id, int myValue, string myText, string year, bool myCheckBox)
        //    {
        //        _id = id;
        //        _myValue = myValue;
        //        _myText = myText;
        //        _year = year;
        //        _myCheckBox = myCheckBox;
        //    }
        //} 
        #endregion

        #endregion
    }

}
