using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class Terminal
    {        
        public event EventHandler<CallEventArgs> OnCall;

        public int AbonentNumber;        

        public Terminal(int number, ATS ats)
        {
            AbonentNumber = number;
            OnCall += ats.SomeTerminalCall;
        }

        public void Call(int call_number)
        {
            if (OnCall != null)
            {
                OnCall(this, new CallEventArgs(call_number));                
            }
        }
    }
}
