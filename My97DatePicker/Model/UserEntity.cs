using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UserEntity
    {
        private string userID;
        private int departmentID;
        private int powerID;
        private string userName;
        private string userPwd;
        private string userImage;
        private string userDes;
        private string x;
        private string y;
        private string z;
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
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }
        public string UserPwd
        {
            get
            {
                return this.userPwd;
            }
            set
            {
                this.userPwd = value;
            }
        }
        public string UserImage
        {
            get
            {
                return this.userImage;
            }
            set
            {
                this.userImage = value;
            }
        }
        public string UserDes
        {
            get
            {
                return this.userDes;
            }
            set
            {
                this.userDes = value;
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
