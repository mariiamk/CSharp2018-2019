using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Alphabet
    {
        char s = 'A';
        int n = 26;

        public IEnumerator GetEnumerator()
        {
            return new AlphabetEnumerator(s, n);
        }
    }

    class AlphabetEnumerator : IEnumerator
    {
        char s;
        int n;
        int position = -1;
        public AlphabetEnumerator(char s, int n)
        {
            this.s = s;
            this.n = n;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position > n)
                    throw new InvalidOperationException();
                return (char)(s + position);
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
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Alphabet p = new Alphabet();
            foreach (var a in p)
            {
                Console.WriteLine(a);
            }
            Console.Read();
        }
    }
}
