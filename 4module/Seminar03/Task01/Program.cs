using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class myComplex
    {
        public double re, im;
        public myComplex(double xre, double xim)
        {
            re = xre;
            im = xim;
        }

        // почему так делать не стоит?
        public static myComplex operator --(myComplex mc)
        {
            mc.re--;
            mc.im--;
            return mc;
        }

        public double Mod()
        {
            return Math.Abs(re * re + im * im);
        }
        static public bool operator true(myComplex f)
        {
            if (f.Mod() > 1.0) return true;
            else return false;
        }
        static public bool operator false(myComplex f)
        {
            if (f.Mod() <= 1.0) return true;
            else return false;
        }
    }

    class Program
    {
        static void display(myComplex cs)
        {
            Console.WriteLine("real=" + cs.re + ", image=" + cs.im);
        }
        static void Main()
        {
            myComplex c1 = new myComplex(4, 3.3);
            Console.WriteLine("Модуль исходного комплексного числа = " +
                                                                c1.Mod());
            while (c1)
            {
                Console.Write("c1 => "); display(c1);
                c1--;
            }
            Console.WriteLine("Модуль полученного числа = " +
                                                             c1.Mod());
            Console.WriteLine("Число принадлежит кругу с радиусом 1.");
            Console.ReadKey();
        }        
    }
}
