using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class EndCallTerminalEventArgs : EventArgs
    {
        public DateTime EndCallTime;
        public string ResultOperationMessage;        

        public EndCallTerminalEventArgs(DateTime end_call_time)
        {            
            EndCallTime = end_call_time;
        }
    }
}
