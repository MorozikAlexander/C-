using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint03
{
    public class ClientUnit
    {
        private int ClientID;
        public string Name;
        public string SurName;

        public ClientUnit(int clientid, string name, string surname)
        {
            ClientID = clientid;
            Name = name;
            SurName = surname;
        }
    }
}
