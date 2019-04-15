using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class RectSet
    {
        public static Random rnd;
        // координаты левой границы
        int x1;
        // координаты правой границы
        int x2;
        // множество представлено объектом HashSet<>
        HashSet<int> set;
        public HashSet<int> GetSet { get { return set; } }
        public RectSet()
        {
            set = new HashSet<int>();
        }

        public RectSet(int min, int max, int N)
        {
            // создаём массив случайных чисел
            int[] arr = new int[N];
            for (int i = 0; i < N; i++) arr[i] = rnd.Next(min, max + 1);
            set = new HashSet<int>(arr); // конструируем множество
                                         // добавляем границы
            Array.Sort(arr);
            x1 = arr.Min();
            x2 = arr.Max();
        }
        public RectSet(HashSet<int> mySet)
        {
            set = mySet;
            // TODO1 
            x1 = mySet.Min();
            x2 = mySet.Max();
        }
        // перегружаем + для объединения множеств RectSet
        public static RectSet operator +(RectSet a, RectSet b)
        {
            // используем метод Concat() из HashSet<>
            return new RectSet(new HashSet<int>(a.GetSet.Concat(b.GetSet)));
        }
        // TODO2 
        public static RectSet operator *(RectSet a, RectSet b)
        {
            return new RectSet(new HashSet<int>(a.GetSet.Intersect(b.GetSet)));
        }
        // TODO3
        public static RectSet operator ^(RectSet a, RectSet b)
        {
            return new RectSet(new HashSet<int>((a+b).GetSet.Except((a*b).GetSet)));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            HashSet<int> hs = new HashSet<int>(arr);
            int[] arr2 = { 4, 5, 6 };
            HashSet<int> hs2 = new HashSet<int>(arr2);
            RectSet rs = new RectSet(hs);
            RectSet rs2 = new RectSet(hs2);
            RectSet rs3 = rs + rs2;
            foreach (int x in rs3.GetSet)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            RectSet rs4 = rs * rs2;
            foreach (int x in rs4.GetSet)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            RectSet rs5 = rs ^ rs2;
            foreach (int x in rs5.GetSet)
            {
                Console.Write(x + " ");
            }
            Console.ReadKey();
        }
    }
}
