using System;
namespace Model
{
    public class ProblemEntity
    {
        private int problemID;
        private int typeID;
        private int courseID;
        private int gradeID;
        private string problemName;
        private string problemAnswer;
        private string problemDes;
        private string flag;
        private int isUse;
        private string x;
        private string y;
        private string z;
        private int isBasic;
        public int ProblemID
        {
            get
            {
                return this.problemID;
            }
            set
            {
                this.problemID = value;
            }
        }
        public int TypeID
        {
            get
            {
                return this.typeID;
            }
            set
            {
                this.typeID = value;
            }
        }
        public int CourseID
        {
            get
            {
                return this.courseID;
            }
            set
            {
                this.courseID = value;
            }
        }
        public int GradeID
        {
            get
            {
                return this.gradeID;
            }
            set
            {
                this.gradeID = value;
            }
        }
        public string ProblemName
        {
            get
            {
                return this.problemName;
            }
            set
            {
                this.problemName = value;
            }
        }
        public string ProblemAnswer
        {
            get
            {
                return this.problemAnswer;
            }
            set
            {
                this.problemAnswer = value;
            }
        }
        public string ProblemDes
        {
            get
            {
                return this.problemDes;
            }
            set
            {
                this.problemDes = value;
            }
        }
        public string Flag
        {
            get
            {
                return this.flag;
            }
            set
            {
                this.flag = value;
            }
        }
        public int IsUse
        {
            get
            {
                return this.isUse;
            }
            set
            {
                this.isUse = value;
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
        public int IsBasic
        {
            get
            {
                return this.isBasic;
            }
            set
            {
                this.isBasic = value;
            }
        }
    }
}
