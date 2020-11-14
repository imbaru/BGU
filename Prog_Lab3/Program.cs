using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int a, b, i, n, sum;
                Console.Write("Введите A = ");
                a = int.Parse(Console.ReadLine());
                Console.Write("Введите B = ");
                b = int.Parse(Console.ReadLine());

                if (a < b)
                {
                    i = 1;
                    n = a;
                    sum = 0;

                    while (i < b)
                    {
                        i++;
                        sum += n++;
                    }

                    Console.WriteLine($"Сумма всех целых чисел равна от {a} до {b} = {sum} ");
                }

                else
                {
                    Console.WriteLine("Число А должно быть меньше числа B");
                }
            }
        }
    }
}
