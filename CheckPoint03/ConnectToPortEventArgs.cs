using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class ConnectToPortEventArgs : EventArgs
    {
        public Port ConnectionPort;

        public ConnectToPortEventArgs()
        {
        }
    }
}
