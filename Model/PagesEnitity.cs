using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PagesEnitity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int pageSort;

        public int PageSort
        {
            get { return pageSort; }
            set { pageSort = value; }
        }
        private int parentID;

        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        private int pID;

        public int PID
        {
            get { return pID; }
            set { pID = value; }
        }
        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }
        private string pageURL;

        public string PageURL
        {
            get { return pageURL; }
            set { pageURL = value; }
        }
        private string pageDes;

        public string PageDes
        {
            get { return pageDes; }
            set { pageDes = value; }
        }

    }
}
