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


        public void SomeTerminalCall(object sender, CallEventArgs e)
        {
            if (sender is Terminal)
            {
                Console.WriteLine("Терминал с номером:{0} хочет позвонить по номеру:{1}", (sender as Terminal).AbonentNumber, e.CallNumber);
                //Searching port with cuurent number
                if (ATS_Ports.Count > 0)
                {


                    if ((ATS_Ports.First<Port>(x => x.TerminalAbonentNumber == e.CallNumber)).TerminalAbonentNumber == e.CallNumber)
                    {
                        Console.WriteLine("Найден порт с таким номером:");



                    }
                }
                else
                {
                    Console.WriteLine("Нету включенных телефонов!");
                }
            }
        }
    }
}
