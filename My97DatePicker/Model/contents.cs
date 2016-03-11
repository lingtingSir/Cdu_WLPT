using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class contents
    {
        private int iid;

        public int Iid
        {
            get { return iid; }
            set { iid = value; }
        }
        private int p_iid;

        public int P_iid
        {
            get { return p_iid; }
            set { p_iid = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private int flag;

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private string contens;

        public string Contens
        {
            get { return contens; }
            set { contens = value; }
        }
        private DateTime pubdate;

        public DateTime Pubdate
        {
            get { return pubdate; }
            set { pubdate = value; }
        }
        private int counts;

        public int Counts
        {
            get { return counts; }
            set { counts = value; }
        }
        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

    }
}
