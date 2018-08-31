using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        public static void ValuesSort(ref int x, ref int y, ref int z)
        {
            // Вспомогательные переменные
            int a1 = 0, a2 = 0, a3 = 0;
            a1 = x < y ? (z < x ? z : x) : (y < z ? y : z);
            a3 = x > y ? (z > x ? z : x) : (y > z ? y : z);
            a2 = x + y + z - a1 - a3;
            x = a1; y = a2; z = a3;
        }

        static void Numerals(int number, out int f1, out int f2, out int f3)
        {
            f1 = number / 100;            // первая цифра
            int temp = number - f1 * 100;
            f2 = temp / 10;             // вторая цифра
            f3 = temp - f2 * 10;        // третья цифра
        }

        static void Main(string[] args)
        {
            int numb = 759;
            do
            {
                do Console.Write("Введите целое от 100 до 999: ");
                while (!int.TryParse(Console.ReadLine(), out numb) ||
                           numb < 100 ||
                                 numb > 999);
                int a, b, c;
                Numerals(numb, out a, out b, out c);
                ValuesSort(ref a, ref b, ref c);
                Console.WriteLine(100 * c + 10 * b + a);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
