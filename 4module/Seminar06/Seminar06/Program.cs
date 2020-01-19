using System;
using System.Collections;

namespace Task01
{
    class ArithmeticProgression
    {
        int a0;
        int d;
        int n;

        public ArithmeticProgression(int a0, int d, int n)
        {
            this.a0 = a0;
            this.d = d;
            this.n = n;
        }

        public IEnumerator GetEnumerator()
        {
            return new ArithmeticProgressionEnumerator(a0, d, n);
        }

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

            object IEnumerator.Current
            {
                get
                {
                    if (position == -1 || position > n)
                        throw new InvalidOperationException();
                    return a0 + d * position;
                }
            }
            bool IEnumerator.MoveNext()
            {
                if (position < n)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }

            void IEnumerator.Reset()
            {
                position = -1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticProgression p = new ArithmeticProgression
            ( 5,  5, 10 );

            foreach (var a in p)
                Console.WriteLine(a);

            Console.ReadKey();

        }
    }
}