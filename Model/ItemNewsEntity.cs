using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ItemNewsEntity
    {
        private int newsID;

        public int NewsID
        {
            get { return newsID; }
            set { newsID = value; }
        }
        private int itemID;

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        private string teacherID;

        public string TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }

        private string newsName;

        public string NewsName
        {
            get { return newsName; }
            set { newsName = value; }
        }
        private DateTime newsDate;

        public DateTime NewsDate
        {
            get { return newsDate; }
            set { newsDate = value; }
        }
        private string newsSource;

        public string NewsSource
        {
            get { return newsSource; }
            set { newsSource = value; }
        }
        private DateTime topDate;

        public DateTime TopDate
        {
            get { return topDate; }
            set { topDate = value; }
        }
        private string linkUrl;

        public string LinkUrl
        {
            get { return linkUrl; }
            set { linkUrl = value; }
        }
        private string newsStyle;

        public string NewsStyle
        {
            get { return newsStyle; }
            set { newsStyle = value; }
        }
        private int newsSort;

        public int NewsSort
        {
            get { return newsSort; }
            set { newsSort = value; }
        }
        private int newsHit;

        public int NewsHit
        {
            get { return newsHit; }
            set { newsHit = value; }
        }
        private string newsContent;

        public string NewsContent
        {
            get { return newsContent; }
            set { newsContent = value; }
        }

        private int isTop;

        public int IsTop
        {
            get { return isTop; }
            set { isTop = value; }
        }

        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
