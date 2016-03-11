using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ClientEntity
    {
        private string clientID;

        public string ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        private string clientName;

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
        private string clientPwd;

        public string ClientPwd
        {
            get { return clientPwd; }
            set { clientPwd = value; }
        }
        private string clientImage;

        public string ClientImage
        {
            get { return clientImage; }
            set { clientImage = value; }
        }
        private string clientDes;

        public string ClientDes
        {
            get { return clientDes; }
            set { clientDes = value; }
        }
        private string x;

        public string X
        {
            get { return x; }
            set { x = value; }
        }
        private string y;

        public string Y
        {
            get { return y; }
            set { y = value; }
        }
        private string z;

        public string Z
        {
            get { return z; }
            set { z = value; }
        }
    }
}
