using System;

namespace SR2
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
        static int[][] CreateArray(int n, int m, int min, int max)
        {
            int[][] result = new int[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new int[m];

                for (int j = 0; j < m; j++)
                    result[i][j] = random.Next(min, max + 1); 
            }

            return result;
        }

        /// <summary>
        /// Разделяет массив на чётные и нечетные
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="evenvalues">массив четных</param>
        /// <param name="oddvalues">массив нечетных</param>
        static void SeparateArray(int[][] arr, out int[][] evenvalues, out int[][] oddvalues)
        {
            evenvalues = new int[arr.Length][];
            oddvalues = new int[arr.Length][];

            for (int i = 0; i < arr.Length; i++)
            {
                evenvalues[i] = new int[arr[i].Length];
                oddvalues[i] = new int[arr[i].Length];

                int evenCount = 0;
                int oddCount = 0;

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] % 2 == 0)
                        evenvalues[i][evenCount++] = arr[i][j];
                    else
                        oddvalues[i][oddCount++] = arr[i][j];
                }
                
                Array.Resize(ref oddvalues[i], oddCount);
                Array.Resize(ref evenvalues[i], evenCount);
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
                SeparateArray(arr, out var evenvalues, out var oddvalues);
                Console.WriteLine("arr");
                PrintJaggedArray(arr);
                Console.WriteLine("even");
                PrintJaggedArray(evenvalues);
                Console.WriteLine("odd");
                PrintJaggedArray(oddvalues);
                Console.WriteLine("ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}