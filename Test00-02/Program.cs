using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Test00_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int jj = 0;
            int kk = 100000;
            long gtime;
            int i, j;

            Console.Write(" Введите количество элементов(по умолчанию 100.000):");
            kk = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Введите количество итераций(оптимально 10 итераций при 100.000 элементов):");
            jj = Convert.ToInt32(Console.ReadLine());

            
            Random rnd = new Random();
            List<Item> ArrayList = new List<Item>();
            List<ItemStruct> ArrayListStruct = new List<ItemStruct>();
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine(" -Создаем {0} объектов без конструктора:", kk);
            gtime = 0;
            for (j = 1; j <= jj; j++)
			{
                stopWatch.Start();
                for (i = 1; i <= kk; i++)
			    {
                   ArrayList.Add(new Item() {NameValue = "Item" + Convert.ToString(i), CostValue = rnd.Next(1, 1000), CountValue = rnd.Next(1, 10000)});
                }
                stopWatch.Stop(); 
                gtime += stopWatch.ElapsedMilliseconds;
                ArrayList.Clear();
            }
            gtime /= jj;
            Console.WriteLine("Время:" + gtime);

            Console.WriteLine(" -Создаем {0} объектов c конструктором:", kk);
            gtime = 0;
            for (j = 1; j <= jj; j++)
            {
                ArrayList.Clear();
                stopWatch.Start();
                for (i = 1; i <= kk; i++)
                {
                    ArrayList.Add(new Item("Item" + Convert.ToString(i), rnd.Next(1, 1000) , rnd.Next(1, 10000)));
                }
                stopWatch.Stop();
                gtime += stopWatch.ElapsedMilliseconds;
            }
            gtime /= jj;
            Console.WriteLine("Время:" + gtime);

            Console.WriteLine(" -Создаем {0} структур:", kk);
            gtime = 0;
            for (j = 1; j <= jj; j++)
            {
                ArrayListStruct.Clear();
                stopWatch.Start();
                for (i = 1; i <= kk; i++)
                {
                    ArrayListStruct.Add(new ItemStruct() { name = "Item" + Convert.ToString(i), cost = rnd.Next(1, 1000), count = rnd.Next(1, 10000) });
                }
                stopWatch.Stop();
                gtime += stopWatch.ElapsedMilliseconds;
            }
            gtime /= jj;
            Console.WriteLine("Время:" + gtime);

            int summ = 0;
            
            for (i = 1; i <= kk; i++)
            {
                summ += ArrayList[i - 1].CostValue;
            }
            Console.WriteLine("Сумма стоимостей в объектах:" + summ);

            summ = 0;

            for (i = 1; i <= kk; i++)
            {
                summ += ArrayListStruct[i - 1].cost;

            }

            Console.WriteLine("Сумма стоимостей в структурах:" + summ);
            Console.ReadKey();
        }
    }
}
