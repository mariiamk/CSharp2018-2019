using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://www.cyberforum.ru/csharp-beginners/thread382938.html

namespace Task04
{
    class RandomCollection : IEnumerable<int>
    {
        public RandomCollection(int n)
        {
            this.n = n;
        }
        int n;
        public IEnumerator<int> GetEnumerator()
        {
            return new RandomEnumerator(n);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class RandomEnumerator : IEnumerator<int>
        {
            private Random rand = new Random();
            int position = -1;
            int n;

            public RandomEnumerator(int n)
            {
                this.n = n;
            }
            public int Current
            {
                get
                {
                    if (position == -1 || position > n)
                        throw new InvalidOperationException();
                    return rand.Next() % 100;
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (position < n)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RandomCollection p = new RandomCollection(3);
            foreach (var a in p)
            {
                Console.WriteLine(a);
            }

            foreach (var a in p)
            {
                Console.WriteLine(a);
            }

            foreach (var a in p)
            {
                Console.WriteLine(a);
            }
            Console.Read();
        }
    }
}
