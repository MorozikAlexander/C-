using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class Terminal
    {
        public delegate void OnConnectToPortHandler(object sender, ConnectToPortEventArgs e);

        public event OnConnectToPortHandler OnConnectToPort;
        
        private event EventHandler<CallEventArgs> OnCall;        

        public int Number;
        public Port Terminal_Port;

        public Terminal(int number, ATS ats)
        {
            Number = number;
            OnCall += ats.SomeTerminalCall;
            OnConnectToPort += ats.SomeTerminalConnectToPort;
        }

        public void ConnectToPort()
        {
            if (OnConnectToPort != null)
            {                
                OnConnectToPort(this, new ConnectToPortEventArgs());                    
            }            
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
