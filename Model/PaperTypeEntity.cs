using System;
namespace Model
{
    public class PaperTypeEntity
    {
        private int pTID;
        private string typeName;
        private string typeDes;
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
        public string TypeName
        {
            get
            {
                return this.typeName;
            }
            set
            {
                this.typeName = value;
            }
        }
        public string TypeDes
        {
            get
            {
                return this.typeDes;
            }
            set
            {
                this.typeDes = value;
            }
        }
    }
}
