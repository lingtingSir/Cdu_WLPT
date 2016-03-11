using System;
namespace Model
{
    public class UserIntegralDetailEntity
    {
        private int detailID;
        private string userID;
        private int integralChange;
        private string changeDes;
        public int DetailID
        {
            get
            {
                return this.detailID;
            }
            set
            {
                this.detailID = value;
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
        public int IntegralChange
        {
            get
            {
                return this.integralChange;
            }
            set
            {
                this.integralChange = value;
            }
        }
        public string ChangeDes
        {
            get
            {
                return this.changeDes;
            }
            set
            {
                this.changeDes = value;
            }
        }
    }
}
