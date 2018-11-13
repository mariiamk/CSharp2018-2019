using System;

namespace SR1
{
    internal class Program
    {
        /// <summary>
        /// Генератор случайных чисел для матриц
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Создаёт случайный зубчатый массив
        /// </summary>
        /// <param name="n">кол-во строк</param>
        /// <param name="m">кол-во столбцов</param>
        /// <param name="min">минимальное значение в матрице</param>
        /// <param name="max">максимальное значение в матрице</param>
        /// <returns>сгенерированную матрицу</returns>
        static double[][] CreateArray(int n, int m, int min, int max)
        {
            double[][] result = new double[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new double[m];

                for (int j = 0; j < m; j++)
                    result[i][j] = random.NextDouble() * (max - min) + min; 
                // так же можно random.Next(min, max) + random.NextDouble()
                // по логике у этого варианта больше рандомных значащих знаков
            }

            return result;
        }

        /// <summary>
        /// Разделяет зубчатый массив на массивы целых частей и дробных
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="integervalues">массив целых частей</param>
        /// <param name="fractionalvalues">массив дробных частей</param>
        static void SeparateArray(double[][] arr, out int[][] integervalues, out double[][] fractionalvalues)
        {
            integervalues = new int[arr.Length][];
            fractionalvalues = new double[arr.Length][];

            for (int i = 0; i < arr.Length; i++)
            {
                integervalues[i] = new int[arr[i].Length];
                fractionalvalues[i] = new double[arr[i].Length];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    integervalues[i][j] = (int) arr[i][j];
                    fractionalvalues[i][j] = arr[i][j] - integervalues[i][j];
                }
            }
        }

        /// <summary>
        /// Выводит массив double
        /// </summary>
        /// <param name="arr">массив</param>
        static void PrintJaggedArray(double[][] arr)
        {
            foreach (var smallArr in arr)
            {
                foreach (var el in smallArr)
                {
                    Console.Write("{0:F3} ", el);
                } 
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Выводит массив int
        /// </summary>
        /// <param name="arr">массив</param>
        static void PrintJaggedArray(int[][] arr)
        {
            foreach (var smallArr in arr)
            {
                foreach (var el in smallArr)
                {
                    Console.Write("{0} ", el);
                } 
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Ограничение на размер массива.
        /// Такое маленькое, потому что все массивы в консоль выводить
        /// </summary>
        private const int ArrLength = 50;

        /// <summary>
        /// Ограничение на элементы массива
        /// </summary>
        private const int NumMax = 100000;

        /// <summary>
        /// Считывает число из консоли
        /// </summary>
        /// <param name="message">приглащение для ввода</param>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <param name="minValue">минимальное значение</param>
        /// <param name="maxValue">максимальное значение</param>
        /// <returns>считанное число</returns>
        static int ReadInt(string message, string errorMessage, int minValue = -NumMax, int maxValue = NumMax)
        {
            bool isCorrect = false;
            int res;

            do
            {
                Console.Write(message);
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out res) && res >= minValue && res <= maxValue))
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);

            return res;
        }
        
        public static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("n: ", "input correct n", 1, ArrLength);
                int m = ReadInt("m: ", "input correct m", 1, ArrLength);
                int min = ReadInt("min: ", "input correct min");
                int max = ReadInt("min: ", "input correct max", min + 1);

                var arr = CreateArray(n, m, min, max);
                SeparateArray(arr, out var integervalues, out var fractionalvalues);
                Console.WriteLine("arr");
                PrintJaggedArray(arr);
                Console.WriteLine("int");
                PrintJaggedArray(integervalues);
                Console.WriteLine("frac");
                PrintJaggedArray(fractionalvalues);
                Console.WriteLine("ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}