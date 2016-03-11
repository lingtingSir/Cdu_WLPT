using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
using Wuqi.Webdiyer;
using System.Web.UI.WebControls;
using Dal;

namespace Dal
{
    public class ItemNewsDal : DataBase
    {
        public DataTable Select(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@newsid", SqlDbType.Int);
            p[0].Value = en.NewsID;
            string sql = "select n.newsid,n.itemid,n.TeacherID,n.newsname,n.newsdate,n.newssource,n.topdate,n.linkurl,n.newsstyle,n.newssort,n.newshit,n.newscontent,t.TeacherName from itemnews n,Teachers t where n.TeacherID=t.TeacherID and n.newsid=@newsid";
            return GetDataTable(sql, p);
        }
        public bool Delete(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@newsid", SqlDbType.Int);
            p[0].Value = en.NewsID;
            string sql = "delete itemnews where newsid=@newsid";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@itemid", SqlDbType.Int);
            p[0].Value = en.ItemID;
            p[1] = new SqlParameter("@TeacherID", SqlDbType.VarChar, 50);
            p[1].Value = en.TeacherID;
            p[2] = new SqlParameter("@newsname", SqlDbType.VarChar, 200);
            p[2].Value = en.NewsName;
            p[3] = new SqlParameter("@newsdate", SqlDbType.DateTime);
            p[3].Value = en.NewsDate;
            p[4] = new SqlParameter("@newssource", SqlDbType.VarChar, 50);
            p[4].Value = en.NewsSource;
            p[5] = new SqlParameter("@topdate", SqlDbType.DateTime);
            p[5].Value = en.TopDate;
            p[6] = new SqlParameter("@linkurl", SqlDbType.VarChar, 200);
            p[6].Value = en.LinkUrl;
            p[7] = new SqlParameter("@newsstyle", SqlDbType.VarChar, 200);
            p[7].Value = en.NewsStyle;
            p[8] = new SqlParameter("@newssort", SqlDbType.Int);
            p[8].Value = en.NewsSort;
            p[9] = new SqlParameter("@newshit", SqlDbType.Int);
            p[9].Value = en.NewsHit;
            p[10] = new SqlParameter("@newscontent", SqlDbType.VarChar, -1);
            p[10].Value = en.NewsContent;
            p[11] = new SqlParameter("@newsid", SqlDbType.Int);
            p[11].Value = en.NewsID;
            string sql = "update itemnews set itemid=@itemid,TeacherID=@TeacherID,newsname=@newsname,newsdate=@newsdate,newssource=@newssource,topdate=@topdate,linkurl=@linkurl,newsstyle=@newsstyle,newssort=@newssort,newshit=@newshit,newscontent=@newscontent where newsid=@newsid";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Updateitemnews(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@newsname", SqlDbType.VarChar, 200);
            p[0].Value = en.NewsName;
            p[1] = new SqlParameter("@newssource", SqlDbType.VarChar, 50);
            p[1].Value = en.NewsSource;
            p[2] = new SqlParameter("@topdate", SqlDbType.DateTime);
            p[2].Value = en.TopDate;
            p[3] = new SqlParameter("@linkurl", SqlDbType.VarChar, 200);
            p[3].Value = en.LinkUrl;
            p[4] = new SqlParameter("@newsstyle", SqlDbType.VarChar, 200);
            p[4].Value = en.NewsStyle;
            p[5] = new SqlParameter("@newscontent", SqlDbType.VarChar, -1);
            p[5].Value = en.NewsContent;
            p[6] = new SqlParameter("@newsid", SqlDbType.Int);
            p[6].Value = en.NewsID;
            p[7] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[7].Value = en.ItemID;
            string sql = "update itemnews set newsname=@newsname,newssource=@newssource,topdate=@topdate,linkurl=@linkurl,newsstyle=@newsstyle,newscontent=@newscontent,ItemID=@ItemID where newsid=@newsid";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update2(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@itemid", SqlDbType.Int);
            p[0].Value = en.ItemID;
            p[1] = new SqlParameter("@newsname", SqlDbType.VarChar, 200);
            p[1].Value = en.NewsName;
            p[2] = new SqlParameter("@newssource", SqlDbType.VarChar, 50);
            p[2].Value = en.NewsSource;
            p[3] = new SqlParameter("@topdate", SqlDbType.DateTime);
            p[3].Value = en.TopDate;
            p[4] = new SqlParameter("@linkurl", SqlDbType.VarChar, 200);
            p[4].Value = en.LinkUrl;
            p[5] = new SqlParameter("@newsstyle", SqlDbType.VarChar, 200);
            p[5].Value = en.NewsStyle;
            p[6] = new SqlParameter("@newscontent", SqlDbType.VarChar, -1);
            p[6].Value = en.NewsContent;
            p[7] = new SqlParameter("@newsid", SqlDbType.Int, 4);
            p[7].Value = en.NewsID;
            p[8] = new SqlParameter("@IsTop", SqlDbType.Int, 4);
            p[8].Value = en.IsTop;
            string sql = "update itemnews set itemid=@itemid,newsname=@newsname,newssource=@newssource,topdate=@topdate,linkurl=@linkurl,newsstyle=@newsstyle,newscontent=@newscontent,IsTop=@IsTop where newsid=@newsid";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Insert(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@itemid", SqlDbType.Int);
            p[0].Value = en.ItemID;
            p[1] = new SqlParameter("@TeacherID", SqlDbType.VarChar, 50);
            p[1].Value = en.TeacherID;
            p[2] = new SqlParameter("@newsname", SqlDbType.VarChar, 200);
            p[2].Value = en.NewsName;
            p[3] = new SqlParameter("@newssource", SqlDbType.VarChar, 50);
            p[3].Value = en.NewsSource;
            p[4] = new SqlParameter("@topdate", SqlDbType.DateTime);
            p[4].Value = en.TopDate;
            p[5] = new SqlParameter("@linkurl", SqlDbType.VarChar, 200);
            p[5].Value = en.LinkUrl;
            p[6] = new SqlParameter("@newsstyle", SqlDbType.VarChar, 200);
            p[6].Value = en.NewsStyle;
            p[7] = new SqlParameter("@newssort", SqlDbType.Int);
            p[7].Value = en.NewsSort;
            p[8] = new SqlParameter("@newscontent", SqlDbType.VarChar, -1);
            p[8].Value = en.NewsContent;
            p[9] = new SqlParameter("@IsTop", SqlDbType.Int,4);
            p[9].Value = en.IsTop;
            string sql = "insert into itemnews (itemid,TeacherID,newsname,newssource,topdate,linkurl,newsstyle,newssort,newscontent,IsTop)values(@itemid,@TeacherID,@newsname,@newssource,@topdate,@linkurl,@newsstyle,@newssort,@newscontent,@IsTop)";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string AddTwo(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[9];

            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            p[3] = new SqlParameter("@TeacherID", SqlDbType.VarChar, 50);
            p[3].Value = en.TeacherID;

            p[2] = new SqlParameter("@NewsName", SqlDbType.VarChar, 100);
            p[2].Value = en.NewsName;

            p[1] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[1].Value = en.NewsContent;

            p[4] = new SqlParameter("@NewsStyle", SqlDbType.VarChar, 500);
            p[4].Value = en.NewsStyle;

            p[5] = new SqlParameter("@NewsSource", SqlDbType.VarChar, 500);
            p[5].Value = en.NewsSource;

            p[6] = new SqlParameter("@TopDate", SqlDbType.DateTime);
            p[6].Value = en.TopDate;

            p[7] = new SqlParameter("@LinkUrl", SqlDbType.VarChar, 200);
            p[7].Value = en.LinkUrl;

            p[8] = new SqlParameter("@IsTop", SqlDbType.Int, 4);
            p[8].Value = en.IsTop;
            return ExecuteValue("begin insert into ItemNews (itemid,linkUrl,TeacherID,newsname,NewsContent,NewsStyle,NewsSource,TopDate,IsTop) values (@ItemID,@linkUrl,@TeacherID,@NewsName,@NewsContent,@NewsStyle,@NewsSource,@TopDate,@IsTop)  select max(NewsID) from ItemNews end", p);

        }

        public DataTable GetItemNews()
        {
            string sql = "select itemnews.newsname,itemnews.newsdate,itemnews.newsstyle from item,itemnews where item.itemid=itemnews.itemid and (item.itemkind=1 or item.itemkind=3) and item.ishome=1";
            return GetDataTable(sql);
        }
        public void BindGV(AspNetPager asp, GridView gv, string keys, DropDownList ddl)
        {
            string sql = "";
            string sqlstr = "";
            string sqlcount = "";
            switch (ddl.SelectedValue.ToString())
            {
                case "---请选择---":
                    sqlstr = "select top {0} n.* from itemnews n,item i where i.departid is null and i.itemid=n.itemid and n.newsid not in (select top {1} n.newsid from itemnews n,item i where i.departid is null and i.itemid=n.itemid order by n.newssort asc) order by n.newssort asc";
                    sql = string.Format(sqlstr, asp.PageSize, asp.PageSize * (asp.CurrentPageIndex - 1));
                    sqlcount = "select count(*) from itemnews n,item i where i.departid is null and i.itemid=n.itemid ";
                    break;
                case "新闻标题":
                    sqlstr = "select top {0} * from itemnews n,item i where i.departid is null and i.itemid=n.itemid and n.newsid not in (select top {1} n.newsid from itemnews n,item i where i.departid is null and i.itemid=n.itemid and n.newsname like '%" + keys + "%' order by n.newssort asc ) and n.newsname like '%" + keys + "%' order by n.newssort asc";
                    sql = string.Format(sqlstr, asp.PageSize, asp.PageSize * (asp.CurrentPageIndex - 1));
                    sqlcount = "select count(*) from itemnews n,item i  where i.departid is null and i.itemid=n.itemid and n.newsname like '%" + keys + "%'";
                    break;
                case "新闻内容":
                    sqlstr = "select top {0} * from itemnews n,item i where i.departid is null and i.itemid=n.itemid and n.newsid not in (select top {1} n.newsid from itemnews n,item i where i.departid is null and i.itemid=n.itemid and n.newscontent like '%" + keys + "%' order by n.newssort asc ) and n.newscontent like '%" + keys + "%' order by n.newssort asc";
                    sql = string.Format(sqlstr, asp.PageSize, (asp.CurrentPageIndex - 1) * asp.PageSize);
                    sqlcount = "select count(*) from itemnews n,item i where i.departid is null and i.itemid=n.itemid and newscontent like '%" + keys + "%'";
                    break;
                default:
                    break;
            }
            asp.RecordCount = int.Parse(ExecuteValue(sqlcount));
            gv.DataSource = GetDataTable(sql);
            gv.DataBind();

        }
        public void bindGVbyDepartID(AspNetPager asp, GridView gv, string keys, DropDownList ddl, string teacherid)
        {
            string sql = "";
            string sqlstr = "";
            string sqlcount = "";
            switch (ddl.SelectedValue.ToString())
            {
                case "=====请选择=====":
                    sqlstr = "select top {0} n.*  from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid and n.newsid not in (select top {1} n.newsid from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid order by n.newssort asc) order by n.newssort asc";
                    sqlcount = "select count(*) from  itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid";
                    break;
                case "新闻标题":
                    sqlstr = "select top {0} n.*  from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid=" + teacherid + " and t.departid=i.departid and n.newsid not in (select top {1} n.newsid from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid order by n.newssort asc) and n.newsname like '%" + keys + "%' order by n.newssort asc";
                    sqlcount = "select count(*)  from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid and n.newsname like '%" + keys + "%'";
                    break;
                case "新闻内容":
                    sqlstr = "select top {0} n.*  from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid and n.newsid not in (select top {1} n.newsid from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid order by n.newssort asc) and n.newscontent like '%" + keys + "%' order by newssort asc";
                    sqlcount = "select count(*)  from itemnews n,item i,teachers t where n.itemid=i.itemid and t.teacherid='" + teacherid + "' and t.departid=i.departid and n.newscontent like '%" + keys + "%'";
                    break;
                default:
                    break;
            }
            sql = string.Format(sqlstr, asp.PageSize, (asp.CurrentPageIndex - 1) * asp.PageSize);
            asp.RecordCount = int.Parse(ExecuteValue(sqlcount));
            gv.DataSource = GetDataTable(sql);
            gv.DataBind();
        }


        public DataTable SelectByNewsContent(string keys)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@newscontent", SqlDbType.Int);
            p[0].Value = keys;
            string sql = "select newsname,newssource,newhit,newscontent from itemnews where newscontent like '%@newscontent%'";
            return GetDataTable(sql, p);
        }
        public string SelectNewsName(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@newsid", SqlDbType.Int);
            p[0].Value = en.NewsID;
            string sql = "select newsname from itemnews where newsid=@newsid";
            return ExecuteValue(sql, p);
        }
        public string SelectNewsContent(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@newsid", SqlDbType.Int);
            p[0].Value = en.NewsID;
            string sql = "select newscontent from itemnews where newsid=@newsid";
            return ExecuteValue(sql, p);
        }

        /// <summary>
        /// 获取党校或者分党校新闻
        /// </summary>
        /// <param name="departid"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public DataTable GetHomeNews(int departid, int x)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[0].Value = departid;
            string sql;
            if (departid == 0)
            {
                sql = "select top " + x + " (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<=getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber  from Item i,ItemNews n where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and i.ishome=1 and i.departid is null";
            }
            else
            {
                sql = "select top " + x + "  (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding  from Item i,ItemNews n where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and i.ishome=1 and i.departid=@DepartID ";
            }

            return GetDataTable(sql, p);
        }

        /// <summary>
        /// 获取党校或者分党校新闻
        /// </summary>
        /// <param name="departid"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public DataTable GetHomeNews2(int departid, int x)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[0].Value = departid;
            string sql;
            if (departid == 0)
            {
                sql = "select top " + x + " (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<=getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber  from Item i,ItemNews n where n.ItemID=i.ItemID and i.ItemID=100 ";
            }
            else
            {
                sql = "select top " + x + "  (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding  from Item i,ItemNews n where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and i.ishome=1 and i.departid=@DepartID ";
            }

            return GetDataTable(sql, p);
        }


        /// <summary>
        /// 获取分党校新闻
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public DataTable GetDepartNews(int x)
        {
            string sql = "select top " + x + " (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,ds.DepartName,ROW_NUMBER()  OVER(ORDER BY n.NewsDate desc ,n.NewsSort desc) as RowNumber,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding  from Item i,ItemNews n,DepartSchool ds where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and i.ishome=1 and ds.DepartID=i.DepartID and i.departid is not null   and n.State=1 ";

            return GetDataTable(sql);
        }

        /// <summary>
        /// 分党校新闻分页
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public void AspDepartNews(ItemNewsEntity en, GridView gv, AspNetPager Pager)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@NewsName", SqlDbType.VarChar, 200);
            p[0].Value = en.NewsName;

            p[1] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[1].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,ds.DepartName,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding  from Item i,ItemNews n,DepartSchool ds where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and i.departid=ds.departid and i.departid is not null and n.State=1 ";
            string recordcountstr = "select count(*)   from Item i,ItemNews n,DepartSchool ds  where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and i.departid=ds.departid and i.departid is not null  and n.State=1  ";

            if (en.NewsName != null && en.NewsName != "")
            {
                if (en.NewsContent != null && en.NewsContent != "")
                {
                    sql = sql + " and (n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsName like '%'+@NewsName+'%' ";

                    sql = sql + " or n.NewsContent like '%'+@NewsContent+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsContent like '%'+@NewsContent+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
                }
            }

            if (en.NewsContent != null && en.NewsContent != "")
            {
                if (en.NewsName != null && en.NewsName != "")
                {
                    sql = sql + " and (n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsContent like '%'+@NewsContent+'%' ";

                    sql = sql + " or n.NewsName like '%'+@NewsName+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsName like '%'+@NewsName+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
                }
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }

        public DataTable GetHomeByItemID(ItemNewsEntity en,int x)
        {
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            return GetDataTable("select top " + x + " (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link , n.newshit,i.itemID,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit,n.newsname,n.newscontent,n.newsdate,Row_number() over(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as row_number from Item i,ItemNews n where i.ItemID=n.ItemID and i.itemid =@ItemID order by n.NewsSort desc, n.NewsID desc", p);
        }

        /// <summary>
        /// 根据新闻类型和分党校获取新闻
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public DataTable GetHomeByKind(int kind,int departid,int x)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ItemKind", SqlDbType.Int);
            p[0].Value = kind;
            p[1] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[1].Value = departid;

            if (departid != 0)
            {
                return GetDataTable("select top " + x + " (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link , n.newshit,i.itemID,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit,n.newsname,n.newscontent,n.newsdate,Row_number() over(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as row_number from Item i,ItemNews n where i.ItemID=n.ItemID and i.itemid in (select it.ItemID from Item it where it.ItemKind=@ItemKind and it.DepartID=@DepartID) order by n.NewsSort desc, n.NewsID desc", p);
            }
            else
            {
                return GetDataTable("select  top " + x + "  (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link , n.newshit,i.itemID,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit,n.newsname,n.newscontent,n.newsdate,Row_number() over(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as row_number from Item i,ItemNews n where i.ItemID=n.ItemID and i.itemid in (select it.ItemID from Item it where it.ItemKind=@ItemKind and it.DepartID is null) order by n.NewsSort desc, n.NewsID desc", p);
            }
        }

        public void Asp(DataList gv, AspNetPager Pager, ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            p[2] = new SqlParameter("@NewsName", SqlDbType.VarChar, 200);
            p[2].Value = en.NewsName;

            p[1] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[1].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,
(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding
from Item i,ItemNews n where i.ItemID=n.ItemID ";
            string recordcountstr = "select count(*) from Item i,ItemNews n where i.ItemID=n.ItemID  ";


            if (en.ItemID != 0)//当商品小类不为0时
            {
                sql = sql + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) )";
                recordcountstr = recordcountstr + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) )";
            }
            if (en.NewsName != "" && en.NewsName != null)//当查询商品名不为空
            {
                sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
            }
            if (en.NewsContent != "" && en.NewsContent != null)//当查询商品类容不为空
            {
                sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }

        public void UpdateHit(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@NewsID", SqlDbType.Int);
            p[0].Value = en.NewsID;

            ExecuteSql("update [ItemNews] set  NewsHit=NewsHit+1 where NewsID=@NewsID", p);
        }

        public void UpdateTop(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@NewsID", SqlDbType.Int);
            p[0].Value = en.NewsID;
            p[1] = new SqlParameter("@IsTop", SqlDbType.Int);
            p[1].Value = en.IsTop;

            ExecuteSql("update [ItemNews] set  IsTop=@IsTop where NewsID=@NewsID", p);
        }

        /// <summary>
        /// 让已经不置顶的新闻改变istop状态
        /// </summary>
        /// <param name="en"></param>
        public void UpdateTop()
        {
            ExecuteSql("update [ItemNews] set IsTop=0 where TopDate<getdate() update [ItemNews] set IsTop=1 where TopDate>getdate()");
        }
        public int SelectNewssortByNewsid(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@newsid", SqlDbType.Int);
            p[0].Value = en.NewsID;
            string sql = "select newssort from itemnews where newsid=@newsid";
            return int.Parse(ExecuteValue(sql, p));

        }
        public DataTable Getup(ItemNewsEntity en)
        {
            string sql = "select top 1 * from itemnews where newssort<" + en.NewsSort + " order by newssort desc";
            return GetDataTable(sql);

        }
        public bool hasup(ItemNewsEntity en)
        {
            string sql = "select top 1 * from itemnews where newssort<" + en.NewsSort + " order by newssort desc";
            if (ExecuteValue(sql) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateUp(int newsid, int newssort, int newsidup, int newssortup)
        {
            int upnewssort = newssortup;
            int nownewssort = newssort;
            string sql = "update itemnews set newssort='" + upnewssort + "' where newsid='" + newsid + "'";
            string sqlstr = "update itemnews set newssort='" + nownewssort + "' where newsid='" + newsidup + "'";
            if (ExecuteSql(sql) == 1 && ExecuteSql(sqlstr) == 1)
            {
                return true;
            }
            else
                return false;

        }
        public int GetNewsSortByNewsIDForDown(ItemNewsEntity en)
        {
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@newssort", SqlDbType.Int);
            //p[0].Value = en.NewsSort;
            string sql = "select top 1 * from itemnews where newssort>" + en.NewsSort + " order by newssort asc";
            SqlDataReader dr = getdr(sql);
            if (dr.Read())
            {
                return int.Parse(dr["newssort"].ToString());
            }
            else
            {
                return -1;
            }
        }
        public int GetNewsIDByNewsIDForDown(ItemNewsEntity en)
        {
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@newssort", SqlDbType.Int);
            //p[0].Value = en.NewsSort;
            string sql = "select top 1 * from itemnews where newssort>" + en.NewsSort + " order by newssort asc";
            SqlDataReader dr = getdr(sql);
            if (dr.Read())
            {
                return int.Parse(dr["newsid"].ToString());
            }
            else
            {
                return -1;
            }
        }
        public bool UpdateDown(int newsid, int newssort, int newsiddown, int newssortdown)
        {
            int nownewssort = newssort;
            int downnewssort = newssortdown;
            string sql = "update itemnews set newssort ='" + downnewssort + "' where newsid='" + newsid + "'";
            string sqlstr = "update itemnews set newssort ='" + nownewssort + "' where newsid='" + newsiddown + "'";
            if (ExecuteSql(sql) == 1 && ExecuteSql(sqlstr) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateForUporDown(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@newssort", SqlDbType.Int);
            p[0].Value = en.NewsSort;
            p[1] = new SqlParameter("@newsid", SqlDbType.Int);
            p[1].Value = en.NewsID;
            string sql = "update itemnews set newssort=@newssort where newsid=@newsid";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int GetNewsIDByNewsSort(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@newssort", SqlDbType.Int);
            p[0].Value = en.NewsSort;
            string sql = "select newsid from itemnews where newssort=@newssort";
            return int.Parse(ExecuteValue(sql, p).ToString());

        }

        public DataTable GetTopXByItemID(int x, ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            return GetDataTable("select top " + x + " (case when (n.linkurl is null or n.linkurl='') then 'mainContent.aspx?id='+left(newsid,5) else linkurl end ) as link , n.newshit,i.itemID,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding,i.itemname,i.parentid,i.itemcontent,n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit,n.newsdate,t.TeacherID,t.teachername from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID and i.itemid in (select itemid from dbo.getitems(@ItemID)) order by n.newssort desc", p);
        }

        public void AspAdmin(GridView gv, AspNetPager Pager, ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            p[3] = new SqlParameter("@TeacherID", SqlDbType.VarChar, 50);
            p[3].Value = en.TeacherID;

            p[2] = new SqlParameter("@NewsName", SqlDbType.VarChar, 100);
            p[2].Value = en.NewsName;

            p[1] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[1].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.linkurl is null or n.linkurl='' then '../mainContent.aspx?id='+left(newsid,5) else linkurl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind,n.newssort, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,t.TeacherID,t.teachername,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc,n.NewsSort asc ) as RowNumber,
(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding
from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID ";
            string recordcountstr = "select count(*) from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID  ";


            if (en.ItemID != 0)//当商品小类不为0时
            {
                sql = sql + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) )";
                recordcountstr = recordcountstr + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) )";
            }
            if (en.NewsName != "" && en.NewsName != null)//当查询商品名不为空
            {
                sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
            }
            if (en.NewsContent != "" && en.NewsContent != null)//当查询商品类容不为空
            {
                sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
            }

            if (en.TeacherID != "" && en.TeacherID != null)//当查询商品类容不为空
            {
                sql = sql + " and n.TeacherID=@TeacherID ";
                recordcountstr = recordcountstr + " and n.TeacherID=@TeacherID ";
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }

        public bool update_sort(ItemNewsEntity en, string type)
        {
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@NewsID", SqlDbType.Int);
            p[0].Value = en.NewsID;
            string sql = "";
            switch (type)
            {
                case "down":
                    sql = "update ItemNews set newssort=newssort-1 where newsID=@NewsID";
                    break;
                case "up":
                    sql = "update ItemNews set newssort=newssort+1 where newsID=@NewsID";
                    break;
            }

            int b = ExecuteSql(sql, p);

            if (b == 1)
                return true;
            else
                return false;
        }
        public bool UpdateNewsNameAndContent(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@newsid", SqlDbType.Int);
            p[0].Value = en.NewsID;
            p[1] = new SqlParameter("@newscontent", SqlDbType.VarChar, 50);
            p[1].Value = en.NewsContent;
            p[2] = new SqlParameter("@newsname", SqlDbType.VarChar, 200);
            p[2].Value = en.NewsName;
            string sql = "update itemnews set newsname=@newsname,newscontent=@newscontent where newsid=@newsid";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 审核新闻
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool UpdateState(ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@newsid", SqlDbType.Int);
            p[0].Value = en.NewsID;
            p[1] = new SqlParameter("@State", SqlDbType.Int);
            p[1].Value = en.State;
            string sql = "update itemnews set State=@State where newsid=@newsid";
            int n = ExecuteSql(sql, p);
            if (n == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public object GetNewest(int p)
        //{
        //    sql = "select top " + x + " n.*,i.ItemName from ItemNews n,Item i where n.ItemID=i.ItemID and i.ishome=1 and (i.itemkind=1 or i.itemkind=3) order by i.NewsSort desc,n.NewsSort desc";

        //    return GetDataTable(sql, p);
        //}
        public int getRoles(string teacherid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@teacherid", SqlDbType.VarChar ,50);
            p[0].Value = teacherid;
            string sql = "select roles from teachers where teacherid=@teacherid";
            return  int.Parse (GetDataTable(sql, p).Rows[0][0].ToString());
        }

        /// <summary>
        /// 二级界面分页显示信息
        /// </summary>
        /// <param name="gv">数据绑定控件</param>
        /// <param name="Pager">分页控件</param>
        /// <param name="en"></param>
        /// <param name="departid">分党校id</param>
        public void AspMore(DataList gv, AspNetPager Pager, ItemNewsEntity en,int departid)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            p[1] = new SqlParameter("@DepartID", SqlDbType.Int,4);
            p[1].Value = departid;

            p[2] = new SqlParameter("@NewsName", SqlDbType.VarChar, 100);
            p[2].Value = en.NewsName;

            p[3] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[3].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.linkurl is null or n.linkurl='' then '../mainContent.aspx?id='+left(newsid,5) else linkurl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind,n.newssort, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,t.TeacherID,t.teachername,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,
(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding
from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID ";
            string recordcountstr = "select count(*) from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID  ";

            //当商品小类不为0时
            if (en.ItemID != 0)
            {
                sql = sql + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) ) ";
                recordcountstr = recordcountstr + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) )";
            }
            else if (departid != 0)//当查询商品类容不为空
            {
                sql = sql + " and i.DepartID=@DepartID ";
                recordcountstr = recordcountstr + " and i.DepartID=@DepartID ";
            }
            else
            {
                sql = sql + "  and i.DepartID is null ";
                recordcountstr = recordcountstr + "  and i.DepartID is null ";
            }

            if (en.NewsName != null && en.NewsName != "")
            {
                if (en.NewsContent != null && en.NewsContent != "")
                {
                    sql = sql + " and (n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsName like '%'+@NewsName+'%' ";

                    sql = sql + " or n.NewsContent like '%'+@NewsContent+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsContent like '%'+@NewsContent+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
                }
            }

            if (en.NewsContent != null && en.NewsContent != "") 
            {
                if ( en.NewsName != null && en.NewsName != "") 
                {
                    sql = sql + " and (n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsContent like '%'+@NewsContent+'%' ";

                    sql = sql + " or n.NewsName like '%'+@NewsName+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsName like '%'+@NewsName+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
                }
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }

        /// <summary>
        /// 二级界面分页显示信息
        /// </summary>
        /// <param name="gv">数据绑定控件</param>
        /// <param name="Pager">分页控件</param>
        /// <param name="en"></param>
        /// <param name="departid">分党校id</param>
        public void AspMore(GridView gv, AspNetPager Pager, ItemNewsEntity en, int departid)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            p[1] = new SqlParameter("@DepartID", SqlDbType.Int, 4);
            p[1].Value = departid;

            p[2] = new SqlParameter("@NewsName", SqlDbType.VarChar, 100);
            p[2].Value = en.NewsName;

            p[3] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[3].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.linkurl is null or n.linkurl='' then 'mainContent.aspx?id='+left(newsid,5) else linkurl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind,n.newssort, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,t.TeacherID,t.teachername,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,
(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding
from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID ";
            string recordcountstr = "select count(*) from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID  ";

            //当商品小类不为0时
            if (en.ItemID != 0)
            {
                sql = sql + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) ) ";
                recordcountstr = recordcountstr + " and n.ItemID in( select itemid from dbo.getitems(@ItemID) )";
            }
            else if (departid != 0)//当查询商品类容不为空
            {
                sql = sql + " and i.DepartID=@DepartID ";
                recordcountstr = recordcountstr + " and i.DepartID=@DepartID ";
            }
            else
            {
                sql = sql + "  and i.DepartID is null ";
                recordcountstr = recordcountstr + "  and i.DepartID is null ";
            }

            if (en.NewsName != null && en.NewsName != "")
            {
                if (en.NewsContent != null && en.NewsContent != "")
                {
                    sql = sql + " and (n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsName like '%'+@NewsName+'%' ";

                    sql = sql + " or n.NewsContent like '%'+@NewsContent+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsContent like '%'+@NewsContent+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
                }
            }

            if (en.NewsContent != null && en.NewsContent != "")
            {
                if (en.NewsName != null && en.NewsName != "")
                {
                    sql = sql + " and (n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsContent like '%'+@NewsContent+'%' ";

                    sql = sql + " or n.NewsName like '%'+@NewsName+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsName like '%'+@NewsName+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
                }
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }


        /// <summary>
        /// 二级界面分页显示信息
        /// </summary>
        /// <param name="gv">数据绑定控件</param>
        /// <param name="Pager">分页控件</param>
        /// <param name="en"></param>
        /// <param name="departid">分党校id</param>
        public void AspHomeMore(GridView gv, AspNetPager Pager, ItemNewsEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@NewsName", SqlDbType.VarChar, 100);
            p[0].Value = en.NewsName;

            p[1] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[1].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.linkurl is null or n.linkurl='' then 'mainContent.aspx?id='+left(newsid,5) else linkurl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind,n.newssort, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,t.TeacherID,t.teachername,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,
(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID and i.departid is null ";
            string recordcountstr = "select count(*) from Item i,itemnews n,Teachers t where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID and i.departid is null  ";


            if (en.NewsName != null && en.NewsName != "")
            {
                if (en.NewsContent != null && en.NewsContent != "")
                {
                    sql = sql + " and (n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsName like '%'+@NewsName+'%' ";

                    sql = sql + " or n.NewsContent like '%'+@NewsContent+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsContent like '%'+@NewsContent+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
                }
            }

            if (en.NewsContent != null && en.NewsContent != "")
            {
                if (en.NewsName != null && en.NewsName != "")
                {
                    sql = sql + " and (n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsContent like '%'+@NewsContent+'%' ";

                    sql = sql + " or n.NewsName like '%'+@NewsName+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsName like '%'+@NewsName+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
                }
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }


        /// <summary>
        /// 站内收索新闻分页
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public void AspAllNews(ItemNewsEntity en, GridView gv, AspNetPager Pager)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@NewsName", SqlDbType.VarChar, 200);
            p[0].Value = en.NewsName;

            p[1] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[1].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.LinkUrl is null or n.LinkUrl='' then 'mainContent.aspx?id='+left(newsid,5) else LinkUrl end ) as link ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding,(case when i.DepartID is not null then (select ds.DepartName from DepartSchool ds where ds.DepartID=i.DepartID) else '党校' end) as DepartName  from Item i,ItemNews n where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and n.state=1   ";
            string recordcountstr = "select count(*)   from Item i,ItemNews n where n.ItemID=i.ItemID and (i.itemkind=1 or i.itemkind=3) and n.state=1  ";

            if (en.NewsName != null && en.NewsName != "")
            {
                if (en.NewsContent != null && en.NewsContent != "")
                {
                    sql = sql + " and (n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsName like '%'+@NewsName+'%' ";

                    sql = sql + " or n.NewsContent like '%'+@NewsContent+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsContent like '%'+@NewsContent+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
                }
            }

            if (en.NewsContent != null && en.NewsContent != "")
            {
                if (en.NewsName != null && en.NewsName != "")
                {
                    sql = sql + " and (n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsContent like '%'+@NewsContent+'%' ";

                    sql = sql + " or n.NewsName like '%'+@NewsName+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsName like '%'+@NewsName+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
                }
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }



        /// <summary>
        /// 分页显示分党校新闻信息
        /// </summary>
        /// <param name="gv">数据绑定控件</param>
        /// <param name="Pager">分页控件</param>
        /// <param name="en"></param>
        /// <param name="departid">分党校id</param>
        public void AspDepartNewsCheck(GridView gv, AspNetPager Pager, ItemNewsEntity en, int departid)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[1] = new SqlParameter("@DepartID", SqlDbType.Int, 4);
            p[1].Value = departid;

            p[2] = new SqlParameter("@NewsName", SqlDbType.VarChar, 100);
            p[2].Value = en.NewsName;

            p[0] = new SqlParameter("@NewsContent", SqlDbType.VarChar, -1);
            p[0].Value = en.NewsContent;

            //分页核心代码       
            string sql = @"with OrdersTable as
                    (
	                  select  (case when n.linkurl is null or n.linkurl='' then '../mainContent.aspx?id='+left(newsid,5) else linkurl end ) as link ,(case when n.State is null or n.State=0 then '通过审核' when n.State=1 then '取消通过' else '未知' end ) as checks ,  i.itemID,i.itemname,i.parentid,i.itemcontent,i.itemkind,n.newssort, n.newsstyle,n.newssource, n.newsid,n.newsname,n.newshit, n.newscontent,n.newsdate,t.TeacherID,t.teachername,ds.DepartName,ROW_NUMBER()  OVER(ORDER BY n.IsTop desc,n.NewsDate desc ,n.NewsSort desc) as RowNumber,
(case when datename(year,newsdate)=datename(year,getdate()) and   datename(month,newsdate)=datename(month,getdate()) and   CONVERT(INT, datename(day,getdate())) - CONVERT(INT,datename(day,newsdate) ) <=1  then '<img src=images/new.gif  alt=/>' else '' end ) as new,(case when n.TopDate<getdate() then '' else '<img src=images/ding.gif  alt=/>' end) as ding
from Item i,itemnews n,Teachers t,DepartSchool ds where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID and i.DepartID=ds.DepartID ";
            string recordcountstr = "select count(*) from Item i,itemnews n,Teachers t,DepartSchool ds where t.TeacherID=n.TeacherID and i.ItemID=n.ItemID and i.DepartID=ds.DepartID  ";
          
            if (departid != 0)//当查询商品类容不为空
            {
                sql = sql + " and i.DepartID=@DepartID ";
                recordcountstr = recordcountstr + " and i.DepartID=@DepartID ";
            }
            else
            {
                sql = sql + "  and i.DepartID is not null ";
                recordcountstr = recordcountstr + "  and i.DepartID is not null ";
            }

            if (en.NewsName != null && en.NewsName != "")
            {
                if (en.NewsContent != null && en.NewsContent != "")
                {
                    sql = sql + " and (n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsName like '%'+@NewsName+'%' ";

                    sql = sql + " or n.NewsContent like '%'+@NewsContent+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsContent like '%'+@NewsContent+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsName like '%'+@NewsName+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsName like '%'+@NewsName+'%' ";
                }
            }

            if (en.NewsContent != null && en.NewsContent != "")
            {
                if (en.NewsName != null && en.NewsName != "")
                {
                    sql = sql + " and (n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and (n.NewsContent like '%'+@NewsContent+'%' ";

                    sql = sql + " or n.NewsName like '%'+@NewsName+'%') ";
                    recordcountstr = recordcountstr + " or n.NewsName like '%'+@NewsName+'%') ";
                }
                else
                {
                    sql = sql + " and n.NewsContent like '%'+@NewsContent+'%' ";
                    recordcountstr = recordcountstr + " and n.NewsContent like '%'+@NewsContent+'%' ";
                }
            }

            sql = sql + " )select * from OrdersTable where RowNumber > {0} and RowNumber <= {1}";

            sql = string.Format(sql, (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex - 1) * Pager.PageSize + Pager.PageSize);//, query);

            int recordcount = Convert.ToInt32(ExecuteValue(recordcountstr, p));

            //将满住条件的总的记录数给分页控件的RecordCount属性
            Pager.RecordCount = recordcount;
            gv.DataSource = GetDataTable(sql, p);
            gv.DataBind();
        }

    }
}
