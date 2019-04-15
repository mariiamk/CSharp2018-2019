using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Fraction
    {
        int num;    //.. числитель
        int den;    //.. знаменатель
        public Fraction(int n, int d)
        { //  Конструктор
            if (n >= 0 && d > 0) { num = n; den = d; return; }
            if (n >= 0 && d < 0) { num = -n; den = -d; return; }
            if (n <= 0 && d > 0) { num = n; den = d; return; }
            if (n <= 0 && d < 0) { num = -n; den = -d; return; }
            Console.WriteLine("Нулевой знаменатель: {0}/{1}", n, d);
            return;
        }
        public override string ToString()
        {
            return String.Format("{0}/{1}", num, den);
        }

        static public Fraction operator -(Fraction f)
        { // унарный минус
            return new Fraction(-f.num, f.den);
        }
        static public Fraction operator +(Fraction f1, Fraction f2)
        {
            int n = f1.num * f2.den + f1.den * f2.num;
            int d = f1.den * f2.den;
            return new Fraction(n, d);
        }
        static public bool operator <(Fraction f1, Fraction f2)
        {
            if (f1.num * f2.den < f1.den * f2.num) return true;
            else return false;
        }
        static public bool operator >(Fraction f1, Fraction f2)
        {
            if (f1.num * f2.den > f1.den * f2.num) return true;
            else return false;
        }
    }// End of class Fraction

    class Program
    {
        static void Main(string[] args)
        {
            Fraction A = new Fraction(1, 4);
            Console.WriteLine(A);
            Console.WriteLine((-A).ToString());
            Console.WriteLine(A);
            Fraction B = new Fraction(3, 5);
            Console.WriteLine((A + B).ToString());
            Fraction C;
            if (A > B) C = A;
            else C = B;
            Console.WriteLine(C.ToString());
            Console.ReadKey();
        }
    }
}
