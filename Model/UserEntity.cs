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
        private string userPwd;
        private string userName;
        private string userImage;
        
        private string userDes;
        private DateTime registerDate;
        private int reamainDay;
        private int userIntegral;
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
        public DateTime RegisterDate
        {
            get
            {
                return this.registerDate;
            }
            set
            {
                this.registerDate = value;
            }
        }
        public int ReamainDay
        {
            get
            {
                return this.reamainDay;
            }
            set
            {
                this.reamainDay = value;
            }
        }
        public int UserIntegral
        {
            get
            {
                return this.userIntegral;
            }
            set
            {
                this.userIntegral = value;
            }
        }
    }
}
