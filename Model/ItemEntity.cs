using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ItemEntity
    {
        private int itemID;

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        private int parentID;

        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        private string itemContent;

        public string ItemContent
        {
            get { return itemContent; }
            set { itemContent = value; }
        }
        private int itemSort;

        public int ItemSort
        {
            get { return itemSort; }
            set { itemSort = value; }
        }
        private int itemKind;

        public int ItemKind
        {
            get { return itemKind; }
            set { itemKind = value; }
        }
        private string itemUrl;

        public string ItemUrl
        {
            get { return itemUrl; }
            set { itemUrl = value; }
        }

        private int isTop;

        public int IsTop
        {
            get { return isTop; }
            set { isTop = value; }
        }
        private int isHome;

        public int IsHome
        {
            get { return isHome; }
            set { isHome = value; }
        }
        private int newsSort;

        public int NewsSort
        {
            get { return newsSort; }
            set { newsSort = value; }
        }
        private int displayNum;

        public int DisplayNum
        {
            get { return displayNum; }
            set { displayNum = value; }
        }
        private int departID;

        public int DepartID
        {
            get { return departID; }
            set { departID = value; }
        }
    }
}
