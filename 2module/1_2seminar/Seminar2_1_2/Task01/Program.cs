using System;

// Определить матрицу как двумерный массив, инициализировать ее элементы.
// Используя свойства и методы класса Array вывести ранг массива,
// общее число его элементов, число элементов по разным 
// измерениям, предельные значения всех индексов, признак 
// фиксированных размеров...
// Вывести элементы массива, используя цикл foreach...
// Вывести элементы массива по строкам (в виде таблицы)...


class Program
{
    static void Main(string[] args)
    {
        int[,] matr = new int[3, 4] { { 0, 1, 3, 4 }, { 5, 6, 7, 8 }, { 9, -1, -2, -3 } };

        Console.WriteLine("matr.GetType() = " + matr.GetType());
        Console.WriteLine("matr.IsFixedSize = " + matr.IsFixedSize);
        Console.WriteLine("matr.Rank = " + matr.Rank);
        Console.WriteLine("matr.Length = " + matr.Length);
        Console.WriteLine("matr.GetLength(1) = " + matr.GetLength(1));
        Console.WriteLine("matr.GetUpperBound(1) = " + matr.GetUpperBound(1));

        foreach (int memb in matr) // все элементы матрицы подряд
            Console.Write("{0,3}", memb);

        Console.WriteLine("\n");

        // вывод по строкам!!!
        for (int i = 0; i < matr.GetLength(0); i++, Console.WriteLine())
            for (int j = 0; j < matr.GetLength(1); j++)
                Console.Write("{0,3}", matr[i, j]);

        Console.WriteLine("Для выхода из программы нажмите ENTER.");
        Console.ReadLine();
    }
}

