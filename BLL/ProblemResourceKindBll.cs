using Dal;
using Model;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
namespace BLL
{
    public class ProblemResourceKindBll
    {
        public DataTable GetCourseByParentID(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.GetCourseByParentID(en);
        }
        public bool Add(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.Add(en);
        }
        public bool Delete(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.Delete(en);
        }
        public bool Update(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.Update(en);
        }
        public DataTable GetAll()
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.GetAll();
        }
        public DataTable getDropDownListDataTableBind()
        {
            DataTable result = new DataTable();
            this.getDropDownListPRKDataTableBind(this.getPRKTreeTable(null), result, 0, 0);
            return result;
        }
        private void getDropDownListPRKDataTableBind(DataTable ddt, DataTable result, int pid, int level)
        {
            if (level == 0)
            {
                if (result != null)
                {
                    result.Clear();
                }
                result.Columns.Add("PRKID", Type.GetType("System.Int16"));
                result.Columns.Add("Name", Type.GetType("System.String"));
            }
            foreach (DataRowView drv in new DataView(ddt)
            {
                RowFilter = "ParentID=" + pid
            })
            {
                DataRow dr = result.NewRow();
                dr["PRKID"] = drv["PRKID"].ToString();
                string ss = "";
                for (int i = 0; i < level; i++)
                {
                    ss += "=";
                }
                dr["Name"] = ss + drv["Name"].ToString();
                result.Rows.Add(dr);
                this.getDropDownListPRKDataTableBind(ddt, result, (int)Convert.ToInt16(drv["PRKID"].ToString()), level + 2);
            }
        }
        public DataTable getPRKTreeTable(string iid)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.getPRKTreeTableDal(iid);
        }
        public DataTable GetById(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.GetById(en);
        }
        public void Asp(AspNetPager pager, GridView gv, ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            dal.Asp(pager, gv, en);
        }
        public string GetPathById(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            DataTable dt = dal.GetPathById(en);
            string title = null;
            if (dt != null)
            {
                DataTable dt2 = dal.GetAll();
                string path = dt.Rows[0]["Path"].ToString();
                string[] a = path.Split(new char[]
				{
					'/'
				});
                for (int i = 1; i < a.Length; i++)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        if (dt2.Rows[j]["PRKID"].ToString() == a[i])
                        {
                            title = string.Concat(new string[]
							{
								title,
								"【<a href='YAS_ProblemResourceKindContent.aspx?prkid=",
								a[i],
								"'> ",
								dt2.Rows[j]["Name"].ToString(),
								"</a>】>>> "
							});
                        }
                    }
                }
                title = title.Substring(0, title.Length - 5) + "</a>】";
            }
            else
            {
                title = " ";
            }
            return title;
        }
        public DataTable GetLeafNode(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.GetLeafNode(en);
        }
        public string isLeafNode(ProblemResourceKindEntity en)
        {
            ProblemResourceKindDal dal = new ProblemResourceKindDal();
            return dal.isLeafNode(en);
        }
    }
}
