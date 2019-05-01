using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class ArithmeticProgression
    {
        public int a0, d; // публичные поля - нарушение инкапсуляции

        public IEnumerable GetN(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return a0 + d * (i - 1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticProgression arithmeticProgression = new ArithmeticProgression { a0 = 10, d = 5 };

            foreach (int an in arithmeticProgression.GetN(10))
                Console.WriteLine(an);

            Console.ReadKey();
        }
    }
}
