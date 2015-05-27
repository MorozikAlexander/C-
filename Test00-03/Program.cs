using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test00_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("         Программа работы с треугольниками:");
            ConsoleKeyInfo cki;
            Triangle mt = new Triangle();
                do
                {
                    Console.WriteLine("ESC - выход; A, B, C - изменение сторон; X - возврат значения функции ");
                    Console.WriteLine("A = {0}; B = {1}; С = {2}; Тип = {3}.", mt.A, mt.B, mt.C, mt.PrintTriangleType());
                    cki = Console.ReadKey();
                    try
                    {
                        switch (cki.Key)
                        {
                            case ConsoleKey.A:
                                Console.Write("Введите значение А:");
                                mt.A = Convert.ToInt32(Console.ReadLine());
                                break;
                            case ConsoleKey.B:
                                Console.Write("Введите значение B:");
                                mt.B = Convert.ToInt32(Console.ReadLine());
                                break;
                            case ConsoleKey.C:
                                Console.Write("Введите значение C:");
                                mt.C = Convert.ToInt32(Console.ReadLine());
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("!Ошибка:{0}:вводите целые числа!", e.Message);
                    }
                } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
