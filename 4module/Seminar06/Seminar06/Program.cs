using System;
using System.Collections;

namespace Task01
{
    class ArithmeticProgressionEnumerator : IEnumerator
    {
        int a0;
        int d;
        int n;
        int position = -1;
        public ArithmeticProgressionEnumerator(int a0, int d, int n)
        {
            this.a0 = a0;
            this.d = d;
            this.n = n;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position > n)
                    throw new InvalidOperationException();
                return a0 + d * (position);
            }
        }

        public bool MoveNext()
        {
            if (position < n)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class ArithmeticProgression
    {
        public int a0;
        public int d;
        public int n;
        public IEnumerator GetEnumerator()
        {
            return new ArithmeticProgressionEnumerator(a0, d, n);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticProgression p = new ArithmeticProgression { a0 = 5, d = 5, n = 10 };
            foreach (var a in p)
            {
                Console.WriteLine(a);
            }
            Console.Read();
        }
    }
}