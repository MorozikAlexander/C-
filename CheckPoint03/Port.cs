using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class Port
    {
        int PortID;
        bool Empty;

        public Port(int port)
        {
            PortID = port;
            Empty = true;
        }
    }
}
