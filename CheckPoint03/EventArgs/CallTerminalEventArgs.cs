using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class CallTerminalEventArgs : EventArgs
    {
        public int CallNumber;

        public string ResultOperationMessage;

        public DateTime StartCallTime;

        public CallTerminalEventArgs(int call_number, DateTime start_call_time)
        {
            CallNumber = call_number;
            StartCallTime = start_call_time;

        }
    }
}
