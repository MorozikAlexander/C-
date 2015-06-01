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
                //text = System.IO.File.ReadAllText("../../Text.txt");
                //Task1 T1 = new Task1(text);
                ConcordanceUnit Concordance = new ConcordanceUnit("../../Text1.txt", "../../Concordance.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка:" + e.Message);
            }
            Console.ReadKey();
        }
    }
}
