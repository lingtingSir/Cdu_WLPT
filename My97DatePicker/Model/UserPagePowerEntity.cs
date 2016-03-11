using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserPagePowerEntity
    {
        private int tPP_ID;
        private string userID;
        private int iD;
        public int TPP_ID
        {
            get
            {
                return this.tPP_ID;
            }
            set
            {
                this.tPP_ID = value;
            }
        }
        public string UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }
        public int ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                this.iD = value;
            }
        }
    }
}
