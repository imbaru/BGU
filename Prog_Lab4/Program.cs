using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, -2, 4, 5, 7, -2, 13, 22};
            int[] arr;

            ///
            /// Задаем первый элемент массива как наименьшее число массива
            ///
            int imin = array[0];

            ///
            /// Устанавливаем перечислители
            ///
            int i = 0;
            int m;
            foreach(var item in array)
            {
                if (imin > item)
                {
                    imin = item;

                    // Номер наименьшего элемента массива
                    m = i;
                }
                i++;
            }

            int io = 0;
            int i1 = 0;
            int i2 = 0;

            for (i = 0; i < array.Count(); i++)
            {
                if (array[i] < 0 && io == 0)
                {
                    i1 = i;
                    io++;
                }
                else if (array[i] < 0 && io == 1)
                {
                    i2 = i;
                }
            }

            int Sum = 0;
            for (i = i1 + 1; i < i2; i++)
            {
                Sum += array[i];
            }
        }
    }
}
