using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint03
{
    public class ATSUnit
    {
        public List<PortUnit> ATS_Ports = new List<PortUnit>();


        public void SomeTerminalCall(object sender, CallEventArgs e)
        {
            if (sender is TerminalUnit)
            {
                Console.WriteLine("Терминал с номером:{0} хочет позвонить по номеру:{1}", (sender as TerminalUnit).AbonentNumber, e.CallNumber);

                e.Result = "Все нормально!";
                //Searching port with cuurent number
                if (ATS_Ports.Count > 0)
                {


                    if ((ATS_Ports.First<PortUnit>(x => x.TerminalAbonentNumber == e.CallNumber)).TerminalAbonentNumber == e.CallNumber)
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
