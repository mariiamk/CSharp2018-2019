using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class StringEnumerable : IEnumerable<string[]>
    {
        public string[] words; // плохо
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public IEnumerator<string[]> GetEnumerator()
        {
            string[] w = new string[0];
            int cur = 0;
            for (int j = 0; j < alphabet.Length; j++)
            {
                w = new string[0];
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i][0].Equals(alphabet[cur]))
                    {
                        Array.Resize(ref w, w.Length + 1);
                        w[w.Length - 1] = words[i];
                    }
                }
                cur++;
                if (w.Length == 0) continue; 
                yield return w;
                if (cur >= alphabet.Length) yield break;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringEnumerable vs = new StringEnumerable();
            vs.words = new string[] { "apple", "mommy", "cat", "dog", "dummy", "alphabet", "code",
                                        "love", "spring", "month", "year", "book", "grade", "article"};

            foreach(string[] strs in vs)
            {
                foreach(string s in strs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
