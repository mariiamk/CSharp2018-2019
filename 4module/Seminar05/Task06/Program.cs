using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    // Функция плотности вероятности биномиального распределения
    // Для получения значений функции используется итератор.
    public class Distribution
    {
        int n;
        double p, q;
        // Конструктор:
        public Distribution(int ni, double pi)
        {
            if (ni <= 0 || pi < 0 || pi > 1) throw new Exception();
            n = ni;
            p = pi;
            q = 1 - p;
        }
        // Итератор - метод, возвращающий значение типа  IEnumerable: 
        public System.Collections.IEnumerable getMemb()
        {
            for (int k = 0; k <= n; k++)
            {
                yield return factorial(n) /
                  factorial(n - k) / factorial(k) *
                      Math.Pow(p, k) * Math.Pow(q, n - k);
            }
        }
        // Метод, возвращающий значение факториала:
        double factorial(int x)
        {
            if (x < 0) return -1;
            if (x == 0) return 1;
            return x * factorial(x - 1);
        }

    } // class Distribution 

    class Program
    {
        static void Main()
        {
            Distribution dis = new Distribution(10, 0.5);
            foreach (double pro in dis.getMemb())
            {
                Console.Write(" " + pro.ToString("g5"));
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
