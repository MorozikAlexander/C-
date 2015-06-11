using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class TerminalUnit
    {        
        public event EventHandler<CallEventArgs> OnCall;

        public int AbonentNumber;        

        public TerminalUnit(int number, ATSUnit ats)
        {
            AbonentNumber = number;
            OnCall += ats.SomeTerminalCall;
        }

        public void Call(int call_number)
        {
            if (OnCall != null)
            {
                CallEventArgs MYPARAM = new CallEventArgs(call_number);
                OnCall(this, MYPARAM);
                Console.WriteLine(MYPARAM.Result);
                
            }
        }
    }
}
