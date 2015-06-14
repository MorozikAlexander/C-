using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class BillingRecordUnit
    {
        public TerminalUnit Terminal;
        public TerminalUnit toTerminal;
        public DateTime StartCall;
        public DateTime EndCall;

        public BillingRecordUnit(DateTime startcall)
        {
            StartCall = startcall;
        }
    }
}
