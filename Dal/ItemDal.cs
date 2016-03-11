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
    public class ItemDal : DataBase
    {

        public DataTable Select(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@itemid", SqlDbType.Int);
            p[0].Value = en.ItemID;
            string sql = "select (select count(*) from Item i where i.parentid=Item.itemid ) as childcount, itemid,parentid,itemname,itemcontent,itemsort,itemkind,itemurl,istop,newssort,displaynum,departid from item where itemid=@itemid";
            return GetDataTable(sql, p);
        }
        public bool Delete(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@itemid", SqlDbType.Int);
            p[0].Value = en.ItemID;
            string sql = "delete item where itemid=@itemid";
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

        public bool UpdateContent(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[1] = new SqlParameter("@itemname", SqlDbType.VarChar, 100);
            p[1].Value = en.ItemName;
            p[2] = new SqlParameter("@itemcontent", SqlDbType.VarChar, -1);
            p[2].Value = en.ItemContent;
            p[0] = new SqlParameter("@itemid", SqlDbType.Int);
            p[0].Value = en.ItemID;
            string sql = "update item set itemname=@itemname,itemcontent=@itemcontent where itemid=@itemid";
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

        public bool UpdateLink(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[1] = new SqlParameter("@itemname", SqlDbType.VarChar, 100);
            p[1].Value = en.ItemName;
            p[0] = new SqlParameter("@itemid", SqlDbType.Int);
            p[0].Value = en.ItemID;
            p[2] = new SqlParameter("@itemurl", SqlDbType.VarChar, 200);
            p[2].Value = en.ItemUrl;
            string sql = "update item set itemname=@itemname,itemurl=@itemurl where itemid=@itemid";
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

        public bool Insert(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@parentid", SqlDbType.Int);
            p[0].Value = en.ParentID;
            p[1] = new SqlParameter("@itemname", SqlDbType.VarChar, 100);
            p[1].Value = en.ItemName;
            p[2] = new SqlParameter("@itemcontent", SqlDbType.VarChar, -1);
            p[2].Value = en.ItemContent;
            p[3] = new SqlParameter("@itemsort", SqlDbType.Int);
            p[3].Value = en.ItemSort;
            p[4] = new SqlParameter("@itemkind", SqlDbType.Int);
            p[4].Value = en.ItemKind;
            p[5] = new SqlParameter("@itemurl", SqlDbType.VarChar, 200);
            p[5].Value = en.ItemUrl;
            p[6] = new SqlParameter("@istop", SqlDbType.Int);
            p[6].Value = en.IsTop;
            p[7] = new SqlParameter("@ishome", SqlDbType.Int);
            p[7].Value = en.IsHome;
            p[8] = new SqlParameter("@newssort", SqlDbType.Int);
            p[8].Value = en.ItemSort;
            p[9] = new SqlParameter("@displagnum", SqlDbType.Int);
            p[9].Value = en.DisplayNum;
            p[10] = new SqlParameter("@departid", SqlDbType.Int);
            p[10].Value = en.DepartID;
            string sql = "insert into item (parentid,itemname,itemcontent,itemsort,itemkind,itemurl,istop,ishome,newssort,displaynum,departid)values(@parentid,@itemname,@itemcontent,@itemsort,@itemkind,@itemurl,@istop,@ishome,@newssort,@displaynum,@departid)";
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

        public int GetIstopByDepartyID(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@parentid", SqlDbType.Int);
            p[0].Value = en.ParentID;
            string sql = "select istop from item where parentid=@parentid";
            return int.Parse(ExecuteValue(sql, p));
        }

        public void Asp(GridView gv, AspNetPager pager)
        {
            DataBase db = new DataBase();
            string sql = @"with OrderTable as(select ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,ItemUrl,IsTop,IsHome,(case when IsHome=1 then '以为导航' when IsHome=-1 then '点击作为导航' end) as LinkUp,NewsSort,DisplayNum,DepartID,Row_Number() over(order by ItemID,ItemSort)as row_number from Item) select * from OrderTable where row_number>{0} and row_number<{1}";
            string sql1 = "select count(*) from Item";
            sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(sql1));
            gv.DataSource = db.GetDataTable(sql);
            gv.DataBind();

        }
        public void Asp(DataList gv, AspNetPager pager)
        {
            DataBase db = new DataBase();
            string sql = @"with OrderTable as(select ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,ItemUrl,IsTop,IsHome,NewsSort,DisplayNum,DepartID,Row_Number() over(order by ItemID,ItemSort)as row_number from Item) select * from OrderTable where row_number>{0} and row_number<{1}";
            string sql1 = "select count(*) from Item";
            sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(sql1));
            gv.DataSource = db.GetDataTable(sql);
            gv.DataBind();

        }
        public void Asp(GridView gv, AspNetPager pager, ItemEntity en)
        {
            DataBase db = new DataBase();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[0].Value = en.DepartID;
            p[1] = new SqlParameter("@ItemName", SqlDbType.VarChar, 100);
            p[1].Value = en.ItemName;
            p[2] = new SqlParameter("@ItemContent", SqlDbType.VarChar, -1);
            p[2].Value = en.ItemContent;

            string sql = @"with OrderTable as(select ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,ItemUrl,IsTop,IsHome,NewsSort,DisplayNum,DepartID,Row_Number() over(order by ItemID,ItemSort)as row_number from Item where 1=1 ";
            string sql1 = "select count(*) from Item where 1=1 ";
            if (null != (object)en.DepartID)//???
            {

                sql += " and DepartID=@DepartID";
                sql1 += " and DepartID=@DepartID";
            }

            if (en.ItemName != null && en.ItemName != "")
            {
                sql += "and ItemName like '%'+@ItemName+'%' ";
                sql1 += "and ItemName like '%'+@ItemName+'%' ";

            }
            if (en.ItemContent != "" && en.ItemContent != null)
            {
                sql += "and ItemContent like '%'+@ItemContent+'%' ";
                sql1 += "and ItemContent like '%'+@ItemContent+'%' ";

            }


            sql += ") select * from OrderTable where row_number>{0} and row_number<{1}";

            sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(sql1, p));
            gv.DataSource = db.GetDataTable(sql, p);
            gv.DataBind();

        }

        public void Asp(DataList gv, AspNetPager pager, ItemEntity en)
        {
            DataBase db = new DataBase();
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[0].Value = en.DepartID;
            p[1] = new SqlParameter("@ItemName", SqlDbType.VarChar, 100);
            p[1].Value = en.ItemName;
            p[2] = new SqlParameter("@ItemContent", SqlDbType.VarChar, -1);
            p[2].Value = en.ItemContent;

            string sql = @"with OrderTable as(select ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,ItemUrl,IsTop,IsHome,NewsSort,DisplayNum,DepartID,Row_Number() over(order by ItemID,ItemSort)as row_number from Item where 1=1 ";
            string sql1 = "select count(*) from Item where 1=1 ";
            if (null != (object)en.DepartID)//???
            {

                sql += " and DepartID=@DepartID";
                sql1 += " and DepartID=@DepartID";
            }

            if (en.ItemName != null && en.ItemName != "")
            {
                sql += "and ItemName like '%'+@ItemName+'%' ";
                sql1 += "and ItemName like '%'+@ItemName+'%' ";

            }
            if (en.ItemContent != "" && en.ItemContent != null)
            {
                sql += "and ItemContent like '%'+@ItemContent+'%' ";
                sql1 += "and ItemContent like '%'+@ItemContent+'%' ";

            }


            sql += ") select * from OrderTable where row_number>{0} and row_number<{1}";

            sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
            pager.RecordCount = Convert.ToInt32(db.ExecuteValue(sql1, p));
            gv.DataSource = db.GetDataTable(sql, p);
            gv.DataBind();
        }

        public object SelectItemID(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@departid", SqlDbType.Int);
            p[0].Value = en.DepartID;
            string sql = "select itemid from item where departid=@departid";
            return ExecuteValue(sql, p);
        }

        //根据一个节点得出所有子节点
        public DataTable SelectAllByParent(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            p[0].Value = en.ParentID;
            string sql = "select * from Item where ItemID in(select i.ItemID from Item i where i.ParentID=@ParentID) order by ItemID desc";
            return GetDataTable(sql, p);
        }

        /// <summary>
        /// 获取导航初节点
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public DataTable SelectHomeNavByDepart(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[0].Value = en.DepartID;
            string sql;
            if (en.DepartID != 0)
            {
                sql = "select * from Item where istop=1 and parentid=0 and departid=@DepartID  order by ItemSort asc";
            }
            else
            {
                sql = "select * from Item where istop=1 and parentid=0 and departid is null  order by ItemSort asc";
            }

            return GetDataTable(sql, p);
        }


        public DataTable GetByParentID(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            p[0].Value = en.ParentID;
            p[1] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[1].Value = en.DepartID;

            string sql;
            if (en.DepartID != 0)
            {
                sql = "select (case when istop=1 then '取消导航' else '点击作为导航' end) as TopName,(case when IsHome=1 then '取消首页显示' else '点击首页显示' end) as HomeName,(case when ItemKind=3 then '取消图片新闻'  when ItemKind=1 then '点击设为图片新闻' else ' ' end) as ImageName,ItemUrl,IsTop,IsHome,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind from Item where ParentID=@ParentID and DepartID=@DepartID  order by ItemSort asc";
            }
            else
            {
                sql = "select (case when istop=1 then '取消导航' else '点击作为导航' end) as TopName,(case when IsHome=1 then '取消首页显示' else '点击首页显示' end) as HomeName,(case when ItemKind=3 then '取消图片新闻'  when ItemKind=1 then '点击设为图片新闻' else ' ' end) as ImageName,ItemUrl,IsTop,IsHome,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind from Item where ParentID=@ParentID and DepartID is null  order by ItemSort asc";
            }
            return GetDataTable(sql, p);
        }

        public string GetParent(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;
            string sql = "select ParentID from item where ItemID=@ItemID";
            return ExecuteValue(sql, p);
        }

        public bool Update_Top(ItemEntity en)
        {
            string comstr = "Update Item set IsTop=@IsTop where ItemID=@ItemID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int, 4);
            param[0].Value = en.ItemID;
            param[1] = new SqlParameter("@IsTop", SqlDbType.Int, 4);
            param[1].Value = en.IsTop;
            int flag = 0;
            flag = ExecuteSql(comstr, param);
            if (flag > 0)
                return true;
            else
                return false;
        }

        public bool Update_Home(ItemEntity en)
        {
            string comstr = "Update Item set IsHome=@IsHome where ItemID=@ItemID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int, 4);
            param[0].Value = en.ItemID;
            param[1] = new SqlParameter("@IsHome", SqlDbType.Int, 4);
            param[1].Value = en.IsHome;
            int flag = 0;
            flag = ExecuteSql(comstr, param);
            if (flag > 0)
                return true;
            else
                return false;
        }

        public bool Update_Kind(ItemEntity en)
        {
            string comstr = "Update Item set ItemKind=@ItemKind where ItemID=@ItemID";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int, 4);
            param[0].Value = en.ItemID;
            param[1] = new SqlParameter("@ItemKind", SqlDbType.Int, 4);
            param[1].Value = en.ItemKind;
            int flag = 0;
            flag = ExecuteSql(comstr, param);
            if (flag > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改顺序 
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public bool UpdateSort(ItemEntity en)
        {
            string comstr = "Update Item set ItemSort=@ItemSort where ItemID=@ItemID";
            SqlParameter[] param = new SqlParameter[2];
            param[1] = new SqlParameter("@ItemSort", SqlDbType.Int);
            param[1].Value = en.ItemSort;
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            param[0].Value = en.ItemID;

            if (ExecuteSql(comstr, param) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //单纯根据父ID获得子ID
        public DataTable GetAllByParentID(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            p[0].Value = en.ParentID;
            p[1] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[1].Value = en.DepartID;

            string sql;
            if (en.DepartID != 0)
            {
                sql = "select (case when ItemKind=0 then '介绍性' when ItemKind=1 then '新闻性' when ItemKind=2 then '链接性' when ItemKind=3 then '图片性新闻' else '错误类型' end) as kind ,(case when itemkind=2 then 'UpdateLinkItem.aspx?id='+left(itemid,5)  else 'UpdateItem.aspx?id='+left(itemid,5)  end ) as ItemLink,(select count(*) from item i where i.parentid=item.itemid) as ChildCount,ItemUrl,IsTop,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,DepartID from Item where ParentID=@ParentID  and DepartID=@DepartID  order by ItemSort ASC";
            }
            else
            {
                sql = "select (case when ItemKind=0 then '介绍性' when ItemKind=1 then '新闻性' when ItemKind=2 then '链接性' when ItemKind=3 then '图片性新闻' else '错误类型' end) as kind ,(case when itemkind=2 then 'UpdateLinkItem.aspx?id='+left(itemid,5)  else 'UpdateItem.aspx?id='+left(itemid,5)  end ) as ItemLink,(select count(*) from item i where i.parentid=item.itemid) as ChildCount,ItemUrl,IsTop,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind, DepartID from Item where ParentID=@ParentID and DepartID is null  order by ItemSort ASC";
            }
            return GetDataTable(sql, p);
        }

        //单纯根据父ID获得子ID
        public DataTable GetAllByItemID(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;
            p[1] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[1].Value = en.DepartID;

            string sql;
            if (en.DepartID != 0)
            {
                sql = "select (case when ItemKind=0 then '介绍性' when ItemKind=1 then '新闻性' when ItemKind=2 then '链接性' when ItemKind=3 then '图片性新闻' else '错误类型' end) as kind ,(case when itemkind=2 then 'UpdateLinkItem.aspx?id='+left(itemid,5)  else 'UpdateItem.aspx?id='+left(itemid,5) end ) as ItemLink,(select count(*) from item i where i.parentid=item.itemid) as ChildCount,ItemUrl,IsTop,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,DepartID  from Item where ItemID=@ItemID and DepartID=@DepartID  order by ItemSort ASC";
            }
            else
            {
                sql = "select (case when ItemKind=0 then '介绍性' when ItemKind=1 then '新闻性' when ItemKind=2 then '链接性' when ItemKind=3 then '图片性新闻' else '错误类型' end) as kind ,(case when itemkind=2 then 'UpdateLinkItem.aspx?id='+left(itemid,5)  else 'UpdateItem.aspx?id='+left(itemid,5) end ) as ItemLink,(select count(*) from item i where i.parentid=item.itemid) as ChildCount,ItemUrl,IsTop,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,DepartID  from Item where ItemID=@ItemID and DepartID is null  order by ItemSort ASC";
            }
            return GetDataTable(sql, p);
        }


        //根据一个节点得出所有节点
        public DataTable GetAllItem(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;
            string sql = "select ItemUrl,IsTop,IsHome,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind,NewsSort,DisplayNum,DepartID from Item where ItemID in(select ItemID from dbo.getitems(@ItemID)) order by ItemID ASC";
            return GetDataTable(sql, p);
        }

        public DataTable GetAllItemHasNews(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            p[0].Value = en.ParentID;

            string sql = "select i.* from Item i where i.ItemID in(case when (select count(*) from item ii where ii.parentid=i.itemid and ii.itemkind=1)>0 then i.itemid  when i.itemkind=1 then i.itemid end) and i.parentid=@ParentID order by ItemID ASC ";
            return GetDataTable(sql, p);
        }

        public string AddGetValue(ItemEntity en)
        {
            string sql = "begin insert into Item (ItemUrl,IsTop,ParentID,ItemName,ItemContent,ItemSort,ItemKind)values(@ItemUrl,1,@ParentID,@ItemName,@ItemContent,@ItemSort,@ItemKind) select max(itemid) from item end ";
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            param[0].Value = en.ParentID;
            param[1] = new SqlParameter("@ItemName", SqlDbType.VarChar, 500);
            param[1].Value = en.ItemName;
            param[2] = new SqlParameter("@ItemContent", SqlDbType.VarChar, -1);
            param[2].Value = en.ItemContent;
            param[3] = new SqlParameter("@ItemSort", SqlDbType.Int);
            param[3].Value = en.ItemSort;
            param[4] = new SqlParameter("@ItemKind", SqlDbType.Int);
            param[4].Value = en.ItemKind;
            param[5] = new SqlParameter("@ItemUrl", SqlDbType.VarChar, 200);
            param[5].Value = en.ItemUrl;
            return ExecuteValue(sql, param);
        }

        public string AddGetValueDepart(ItemEntity en)
        {
            string sql = "begin insert into Item (ItemUrl,IsTop,ParentID,ItemName,ItemContent,ItemSort,ItemKind,DepartID)values(@ItemUrl,1,@ParentID,@ItemName,@ItemContent,@ItemSort,@ItemKind,@DepartID) select max(itemid) from item end ";
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            param[0].Value = en.ParentID;
            param[1] = new SqlParameter("@ItemName", SqlDbType.VarChar, 500);
            param[1].Value = en.ItemName;
            param[2] = new SqlParameter("@ItemContent", SqlDbType.VarChar, -1);
            param[2].Value = en.ItemContent;
            param[3] = new SqlParameter("@ItemSort", SqlDbType.Int);
            param[3].Value = en.ItemSort;
            param[4] = new SqlParameter("@ItemKind", SqlDbType.Int);
            param[4].Value = en.ItemKind;
            param[5] = new SqlParameter("@ItemUrl", SqlDbType.VarChar, 200);
            param[5].Value = en.ItemUrl;
            param[6] = new SqlParameter("@DepartID", SqlDbType.Int, 4);
            param[6].Value = en.DepartID;
            return ExecuteValue(sql, param);
        }


        //由一个 节点 获得所有子节点总数 函数
        public int GetTreeCount(int itemID, int count)
        {
            count += int.Parse(ExecuteValue("select count(*) from Problem where  ItemID=" + itemID + ""));
            DataTable dt = GetDataTable("select * from Item where ItemKind=0 and ParentID=" + itemID + "");
            foreach (DataRow row in dt.Rows)
            {
                count = GetTreeCount(int.Parse(row["ItemID"].ToString()), count);
            }
            return count;
        }

        //获取同一级别的Item的的ItemSort的最大值
        public int GetMaxSort(ItemEntity en)
        {
            string comstr = "Select Max(ItemSort) from Item  where ParentID=@ParentID";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ParentID", SqlDbType.Int, 4);
            param[0].Value = en.ParentID;
            object obj = ExecuteValue(comstr, param);
            if (obj == null || obj.ToString() == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        //根据一个节点得出所有节点,按条件
        public DataTable GetAllNewsItem(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ItemID", SqlDbType.Int);
            p[0].Value = en.ItemID;

            string sql = "select ItemUrl,IsTop,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind from Item where (ItemKind=1 or ItemKind=3) and ItemID in(select ItemID from dbo.getitems(@ItemID)) order by ItemID ASC";
            return GetDataTable(sql, p);
        }

        public DataTable GetItemByKindDepart(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ItemKind", SqlDbType.Int);
            p[0].Value = en.ItemKind;
            p[1] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[1].Value = en.DepartID;

            string sql;
            if (en.DepartID != 0)
            {
                sql = "select * from Item where ItemKind=@ItemKind and DepartID=@DepartID order by ItemSort ASC,NewsSort ASC";
            }
            else
            {
                sql = "select * from Item where ItemKind=@ItemKind and DepartID is null order by ItemSort ASC,NewsSort ASC";
            }
            return GetDataTable(sql, p);
        }

        //根据一个节点得出所有节点,按条件
        public DataTable GetNewsByDepartid(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[0].Value = en.DepartID;

            string sql;
            if (en.DepartID != 0)
            {
                sql = "select ItemID,ItemUrl,IsTop,IsHome,DepartID,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind from Item where (ItemKind=1 or ItemKind=3) and DepartID=@DepartID order by ItemSort ASC";
            }
            else
            {
                sql = "select ItemID,ItemUrl,IsTop,IsHome,DepartID,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind from Item where (ItemKind=1 or ItemKind=3) and DepartID is null order by ItemSort ASC";
            }
            return GetDataTable(sql, p);
        }

        public DataTable GetNewsByParentDepartid(ItemEntity en)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ParentID", SqlDbType.Int);
            p[0].Value = en.ParentID;
            p[1] = new SqlParameter("@DepartID", SqlDbType.Int);
            p[1].Value = en.DepartID;

            string sql;
            if (en.DepartID != 0)
            {
                sql = "select ItemID,ItemUrl,IsTop,IsHome,DepartID,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind from Item where (ItemKind=1 or ItemKind=3) and DepartID=@DepartID and ParentID=@ParentID order by ItemSort ASC";
            }
            else
            {
                sql = "select ItemID,ItemUrl,IsTop,IsHome,DepartID,ItemID,ParentID,ItemName,ItemContent,ItemSort,ItemKind from Item where (ItemKind=1 or ItemKind=3) and DepartID is null and ParentID=@ParentID order by ItemSort ASC";
            }
            return GetDataTable(sql, p);
        }
    }
}
