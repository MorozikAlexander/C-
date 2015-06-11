using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class CallEventArgs : EventArgs
    {
        public int CallNumber;

        public string Result;

        public CallEventArgs(int call_number)
        {
            CallNumber = call_number;
        }
    }
}
