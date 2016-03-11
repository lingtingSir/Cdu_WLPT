using System;
namespace Model
{
    public class ProjectPaperEntity
    {
        private int pPID;
       
        private int pTID;
        private string name;
        
        private string selfResource;
        private DateTime registerDate;
        private int departmentId;
        private string clientID;

        public string ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }


        public int DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }
        private string projectHead;

        public string ProjectHead
        {
            get { return projectHead; }
            set { projectHead = value; }
        }
        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }
        public DateTime RegisterDate
        {
            get { return registerDate; }
            set { registerDate = value; }
        }
        private DateTime overDate;

        public DateTime OverDate
        {
            get { return overDate; }
            set { overDate = value; }
        }
        private string pPDesc;
        private DateTime fhdateTime;

       
        private float x;
        public int PPID
        {
            get
            {
                return this.pPID;
            }
            set
            {
                this.pPID = value;
            }
        }
       
        public int PTID
        {
            get
            {
                return this.pTID;
            }
            set
            {
                this.pTID = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
       
        public string SelfResource
        {
            get
            {
                return this.selfResource;
            }
            set
            {
                this.selfResource = value;
            }
        }
       
        public string PPDesc
        {
            get
            {
                return this.pPDesc;
            }
            set
            {
                this.pPDesc = value;
            }
        }

        public DateTime FhdateTime
        {
            get { return fhdateTime; }
            set { fhdateTime = value; }
        }
        public float X
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
    }
}
