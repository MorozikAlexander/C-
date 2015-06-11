using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public enum PortStatusEnum { ON, OFF, BUSY };

    public class PortUnit
    {        
        public int TerminalAbonentNumber;
        public PortStatusEnum PortStatus; 

        public PortUnit(int number)
        {
            TerminalAbonentNumber = number;            
            PortStatus = PortStatusEnum.OFF;
        }
    }
}
