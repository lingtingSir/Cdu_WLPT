using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PowerEntity
    {
        private int powerID;
        private string powerName;
        private string powerDes;
        private string x;
        private string y;
        private string z;
        public int PowerID
        {
            get
            {
                return this.powerID;
            }
            set
            {
                this.powerID = value;
            }
        }
        public string PowerName
        {
            get
            {
                return this.powerName;
            }
            set
            {
                this.powerName = value;
            }
        }
        public string PowerDes
        {
            get
            {
                return this.powerDes;
            }
            set
            {
                this.powerDes = value;
            }
        }
        public string X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public string Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        public string Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }
    }
}
