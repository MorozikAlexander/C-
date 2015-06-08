using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class ATS
    {
        public List<Port> ATS_Ports = new List<Port>();

        public ATS(int number_of_ports)
        {
            if (number_of_ports > 0)
                for (int i = 1; i < number_of_ports; i++)
                    ATS_Ports.Add(new Port(i));
        }

        public void SomeTerminalConnectToPort(object sender, ConnectToPortEventArgs e)
        {
            if (sender is Terminal)
            {                
                Console.WriteLine("Терминал с номером:{0} хочет подключиться к порту.", (sender as Terminal).Number);                
            }
        }

        public void SomeTerminalCall(object sender, CallEventArgs e)
        {
            if (sender is Terminal)
            {
                Console.WriteLine("Терминал с номером:{0} хочет позвонить по номеру:{1}", (sender as Terminal).Number, e.CallNumber);                
            }
        }
    }
}
