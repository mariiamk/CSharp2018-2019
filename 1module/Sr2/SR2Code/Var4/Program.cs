using System;

namespace Var4
{
    internal class Program
    {
        /// <summary>
        /// Ограничение сверху для коэффициенты прогрессии, 10000, чтобы недолго работало
        /// </summary>
        private const int MaxNumberValue = 10000;

        /// <summary>
        /// Количество выводов
        /// </summary>
        private const int OutputCount = 20;

        /// <summary>
        /// Считывает целое число
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="minValue">Минимальное значение числа</param>
        /// <param name="maxValue">Максимальное значение числа</param>
        /// <returns>Считанное число</returns>
        static int ReadInt(string message, string errorMessage = "Ошибка ввода!", int minValue = -MaxNumberValue,
            int maxValue = MaxNumberValue)
        {
            int res;
            bool isCorrect = false;

            do
            {
                Console.Write(message);
                // можно вынести isCorrect в ветку else (намек критерия на 10)
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out res) && res >= minValue && res <= maxValue))  
                    Console.Error.WriteLine(errorMessage); // вывод в stderr(поток ошибок)
            } while (!isCorrect);

            return res;
        }

        /// <summary>
        /// Считает сумму прогрессии и последний член прогрессии до какого-то момента
        /// </summary>
        /// <param name="a">начальное значение</param>
        /// <param name="d">коэффициент</param>
        /// <param name="n">количество членов</param>
        /// <param name="sum">сумма</param>
        /// <param name="last">последний</param>
        static void CalculateSumAndLast(int a, int d, int n, out int sum, out int last)
        {
            sum = a + d * (n - 1);
            last = a * n + d * (n * (n - 1)) / 2; // вообще, это можно было делать циклом, но очень нежелательно 
        }
        
        public static void Main(string[] args)
        {
            do
            {
                int a = ReadInt("Введите a: ");
                int d = ReadInt("Введите d: ");
                
                for (int current = 1; current <= OutputCount; current++)
                {
                    int sum, last;
                    
                    CalculateSumAndLast(a, d, current, out sum, out last);
                    
                    Console.WriteLine($"номер члена:{current, 5}, сумма прогрессии:{sum, 9}, последний член: " +
                                      $"{last, 6}, соотношение: {(double)sum / last, 8:F3}");
                }
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}