using System;

// Определить массив из трех элементов – ссылок на массивы разной длины.
//    1-й элемент - массив из 3-х элементов – ссылок на массивы, 
// соответственно, из 2-х, 3-х и 4-х элементов типа char. 
//    2-й элемент - массив из 2-х элементов ссылок на массивы, 
// соответственно, из 2-х и 3-х элементов типа char. 
//    3-й элемент - массив из ОДНОГО элемента – ссылки на массив из 4-х 
// элементов типа char. 
// Используя свойства и методы класса Array вывести ранг массива,
// общее число его элементов, число элементов по разным 
// измерениям, предельные значения всех индексов. 
// Вывести элементы массива с помощью циклов foreach,  размещая 
// значения элементов каждого массива нижнего уровня по строкам...


namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][][] ch = { // элементы массива – массивы ссылок на массивы
       new char [][] { new char [] {'a', 'b'}, // у массива 
         new char [] {'c', 'd', 'e'},    // элемент -  ссылка на массив
         new char  [] {'f', 'g', 'h', 'i'}
       },
       new char [][] { new char [] {'j', 'k'},
                       new char [] {'l', 'm', 'n'}
       },
       new char [][] { new char [] {'o', 'p', 'q', 'r'}, }};

            Console.WriteLine("ch.Rank = " + ch.Rank);
            Console.WriteLine("ch[0].Rank = " + ch[0].Rank);
            Console.WriteLine("ch[0][0].Rank = " + ch[0][0].Rank);
            Console.WriteLine("ch.GetType() = " + ch.GetType());
            Console.WriteLine("ch[1][1][2] = " + ch[1][1][2]);
            Console.WriteLine("ch.Length = " + ch.Length);
            Console.WriteLine("ch.GetLength(0) = " + ch.GetLength(0));
            Console.WriteLine("ch[1].GetLength(0) = " + ch[1].GetLength(0));
            foreach (char[][] memb1 in ch)
            {
                Console.WriteLine("Уровень 1:");
                foreach (char[] memb2 in memb1)
                {
                    Console.Write("\tУровень 2:\t");
                    foreach (char memb3 in memb2)
                        Console.Write("{0,3}", memb3);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
