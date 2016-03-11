using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RecordEntity
    {
        private int recordID;

        public int RecordID
        {
            get { return recordID; }
            set { recordID = value; }
        }
        private int ppID;

        public int PpID
        {
            get { return ppID; }
            set { ppID = value; }
        }
        private DateTime presentDate;

        public DateTime PresentDate
        {
            get { return presentDate; }
            set { presentDate = value; }
        }
        private string des;

        public string Des
        {
            get { return des; }
            set { des = value; }
        }

    }
}
