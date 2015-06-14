using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class RegisterTermianlEventArgs : EventArgs
    {
        public PortUnit ResultPort;
        public string ResultOperationMessage;
    }
}
