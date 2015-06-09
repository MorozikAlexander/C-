using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public enum PortStatusEnum { ON, OFF, BUSY };

    public class Port
    {        
        public int TerminalAbonentNumber;
        public PortStatusEnum PortStatus; 

        public Port(int number)
        {
            TerminalAbonentNumber = number;            
            PortStatus = PortStatusEnum.OFF;
        }
    }
}
