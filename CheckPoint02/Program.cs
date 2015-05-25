using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CheckPoint02
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";            

            try
            {
                text = System.IO.File.ReadAllText("../../Text1.txt");                
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка открытия файла:" + e.Message);
            }
            
            Task1 T1 = new Task1(text);            
            
            Console.ReadKey();
        }
    }
}
