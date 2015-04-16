using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test00_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("         Программа вычисления значения функции Y = A*X + B");
            ConsoleKeyInfo cki;
            LinearFunction myfunction = new LinearFunction();
            do
            {
                Console.WriteLine("ESC - выход; A, B - изменение параметров; X - возврат значения функции ");
                Console.WriteLine("A = {0}; B= {1}", myfunction.ValueA, myfunction.ValueB);
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.A:
                        Console.Write("Введите значение А:");
                        myfunction.ValueA = Convert.ToDouble(Console.ReadLine());
                        break;
                    case ConsoleKey.B:
                        Console.Write("Введите значение B:");
                        myfunction.ValueB = Convert.ToDouble(Console.ReadLine());
                        break;
                    case ConsoleKey.X:
                        Console.Write("Введите значение X:");
                        Console.WriteLine("Получено значение Y:" + myfunction.y(Convert.ToDouble(Console.ReadLine())));
                        break;
                    default:
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
