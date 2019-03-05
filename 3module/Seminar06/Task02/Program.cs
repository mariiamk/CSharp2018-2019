using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    interface A
    {
        void Do();
    }
    class B
    {
        public void Do()
        {
            Console.WriteLine("Do from B");
        }
    }
    class C : B, A
    {
        public void Do()
        {
            Console.WriteLine("Do from C");
        }
        public static void Main(string[] args)
        {
            B b = new C();
            b.Do();

            C c = new C();
            c.Do();

            Console.ReadKey();
        }
    }
}
