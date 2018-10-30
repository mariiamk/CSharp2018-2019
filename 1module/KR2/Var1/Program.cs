using System;
using System.Collections.Specialized;

namespace Var1
{
    internal class Program
    {
        /// <summary>
        /// Считает сумму цифр в переданной системе счесления
        /// </summary>
        /// <param name="n">число</param>
        /// <param name="mod">система</param>
        /// <returns>Сумма цифр</returns>
        public static int CountDigitSum(int n, int mod)
        {
            int res = 0;
            while (n != 0)
            {
                res += n % mod;
                n /= mod;
            }

            return res;
        }

        /// <summary>
        /// Считает сумму цифр всех чисел от 1 до n в переданной системе счисления, а так же количество чисел,
        /// заканчивающихся на 0 в этой системе
        /// </summary>
        /// <param name="n">Последнее число в дипазоне</param>
        /// <param name="mod">Система счисления</param>
        /// <param name="count">Количество чисел с 0 в конце</param>
        /// <returns>Сумма всех цифр</returns>
        public static int CountDigitSumOfAllAndCountAllEndsWithZero(int n, int mod, out int count)
        {
            checked // 1ый способ проверять переполнение
            {
                int res = 0;
                count = 0;
                for (int i = 1; i <= n; i++)
                {
                    res += CountDigitSum(i, mod);
                    if (i % mod == 0)
                        count++;
                }

                return res;
            }
        }

        /// <summary>
        /// Максимальное значение для границы диапазона
        /// </summary>
        private const int MaxValue = 100000; // второй способ контролировать переполнение

        /// <summary>
        /// Считывает число из консоли и выводит сообщение об ошибке, если что-то не так
        /// </summary>
        /// <param name="message">Приглашение к вводу</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <returns></returns>
        public static int ReadInt(string message, string errorMessage, int maxValue = MaxValue)
        {
            int res = 0;
            bool isCorrect = false;

            do
            {
                Console.Write(message);
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out res) && res <= maxValue))
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);

            return res;
        }

        /// <summary>
        /// Считывает число, в конкретном отрезке
        /// </summary>
        /// <param name="message">Приглашение для ввода</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <returns>Считанное число</returns>
        private static int ReadIntWithMinValue(string message, string errorMessage, int maxValue = MaxValue,
            int minValue = 0)
        {
            bool isCorrect = false;
            int res;
            do
            {
                res = ReadInt(message, errorMessage, maxValue);
                if (!(isCorrect = res >= minValue))
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);

            return res;
        }
        
        public static void Main(string[] args)
        {
            do
            {
                int n = ReadIntWithMinValue("Введите n: ", $"n от 1 до {MaxValue}!", minValue: 1);
                int mod = ReadIntWithMinValue("Введите mod: ", "mod от 2 до 16!", minValue: 2, maxValue: 16);

                try
                {
                    int sum = CountDigitSumOfAllAndCountAllEndsWithZero(n, mod, out int count);
                    Console.WriteLine("сумма = {0}, количество = {1}", sum, count);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Произошло переполнение... Введите n поменьше");
                } 
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}