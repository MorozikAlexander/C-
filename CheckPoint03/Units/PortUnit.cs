using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public enum PortStatusEnum { ON, OFF, BUSY, CALL, WAIT_FOR_ANSWER };

    public class PortUnit
    {        
        public TerminalUnit Terminal;
        public TerminalUnit whoCall;
        public PortStatusEnum PortStatus;
        public BillingRecordUnit BillingRecord;

        public PortUnit(TerminalUnit terminal)
        {
            Terminal = terminal;            
            PortStatus = PortStatusEnum.OFF;
        }
    }
}
