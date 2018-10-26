using System;

namespace Var2
{
    internal class Program
    {

        /// <summary>
        /// Переворачивает число
        /// </summary>
        /// <param name="n">Число</param>
        /// <returns>Перевернутое число</returns>
        public static int ReverseNumber(int n)
        {
            int reversed = 0;
            while (n != 0)
            {
                reversed = reversed * 10 + n % 10;
                n /= 10;
            }

            return reversed;
        }

        /// <summary>
        /// Считает сумму(какую-то) и количество палиндромов в диапазоне от 1 до n
        /// </summary>
        /// <param name="n">конец диапазона</param>
        /// <param name="type">тип суммы</param>
        /// <param name="count">число палиндромов</param>
        /// <returns>сумма(какая-то)</returns>
        public static int CalculateAllNumbersAndCountAllPalindromes(int n, int type, out int count)
        {
            checked // первый способ отлавливать переполнение
            {
                int sum = 0;
                count = 0;

                for (int i = 1; i <= n; i++)
                {
                    int reversed = ReverseNumber(i);
                    switch (type)
                    {
                        case 0:
                            sum += reversed;
                            break;
                        case 1:
                            sum ^= reversed;
                            break;
                        case 2:
                            sum += ~reversed;
                            break;
                        default:
                            Console.Error.WriteLine("Type должен быть 0, 1 или 2!");
                            break;
                    }

                    if (i == reversed)
                        count++;
                }

                return sum;
            }
        }
        
        /// <summary>
        /// Максимальное значение для границы диапазона
        /// </summary>
        private const int MaxValue = 10000; // второй способ контролировать переполнение

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
                try
                {
                    int n = ReadIntWithMinValue("Введите n: ", $"n от 1 до {MaxValue}!", minValue: 1);
                    int type = ReadIntWithMinValue("Введите type: ", "type от 0 до 2!", minValue: 0, maxValue: 2);

                    int sum = CalculateAllNumbersAndCountAllPalindromes(n, type, out int count);
                    
                    Console.WriteLine("Сумма = {0}, количество = {1}", sum, count);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Произошло переполнение... Введите n поменьше.");
                }
                
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}