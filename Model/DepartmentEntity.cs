using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DepartmentEntity
    {
        private int departmentID;
        private string departmentName;
        private string departmentDes;
        private string x;
        private string y;
        private string z;
        public int DepartmentID
        {
            get
            {
                return this.departmentID;
            }
            set
            {
                this.departmentID = value;
            }
        }
        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }
            set
            {
                this.departmentName = value;
            }
        }
        public string DepartmentDes
        {
            get
            {
                return this.departmentDes;
            }
            set
            {
                this.departmentDes = value;
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
