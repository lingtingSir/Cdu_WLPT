using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RewardProblemEntity
    {
        private int rewardProblemID;
  
        private string userID;
        private string des;
        private string managerBack;
        private DateTime dateUp;
        private int recordState;
        public int RewardProblemID
        {
            get
            {
                return this.rewardProblemID;
            }
            set
            {
                this.rewardProblemID = value;
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
        public string Des
        {
            get
            {
                return this.des;
            }
            set
            {
                this.des = value;
            }
        }
        public string ManagerBack
        {
            get
            {
                return this.managerBack;
            }
            set
            {
                this.managerBack = value;
            }
        }
        public DateTime DateUp
        {
            get
            {
                return this.dateUp;
            }
            set
            {
                this.dateUp = value;
            }
        }
        public int RecordState
        {
            get
            {
                return this.recordState;
            }
            set
            {
                this.recordState = value;
            }
        }
    }
}
