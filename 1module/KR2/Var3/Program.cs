using System;

namespace Var3
{
    internal class Program
    {
        
        /// <summary>
        /// Считатет сумму цифр числа
        /// </summary>
        /// <param name="number">число</param>
        /// <returns>сумма цифр</returns>
        public static int CountSum(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        /// <summary>
        /// Считает количество цифр числа
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>количество цифр</returns>
        public static int CountDigits(int number)
        {
            if (number == 0)
                return 1;

            int digits = 0;

            while (number != 0)
            {
                digits++;
                number /= 10;
            }

            return digits;
        }

        /// <summary>
        /// Выводит все числа в диапазоне, у которых сумма цифр равна количеству
        /// </summary>
        /// <param name="a">левая граница</param>
        /// <param name="b">правая</param>
        /// <returns>вывелось хоть что-то</returns>
        private static bool PrintAllNumberWithEqualDigitSumAndCount(int a, int b)
        {
            bool isPrintedSmth = false;
            
            for (int i = a; i <= b; i++)
            {
                if (CountDigits(i) == CountSum(i))
                {
                    isPrintedSmth = true;
                    Console.Write(i + " ");
                }
            }

            return isPrintedSmth;
        }

        /// <summary>
        /// Выводит все числа в диапазоне, у которых сумма цифр в 2 раза больше чем их кол-во
        /// </summary>
        /// <param name="a">левая граница</param>
        /// <param name="b">правая граница</param>
        /// <returns>вывелось ли хоть что-то</returns>
        private static bool PrintAllNumbersWithDigitSumAndCountDiff2Times(int a, int b)
        {
            bool isPrintedSmth = false;

            for (int i = a; i <= b; i++)
            {
                if (CountDigits(i) * 2 == CountSum(i))
                {
                    isPrintedSmth = true;
                    Console.Write(i + " ");
                }
            }

            return isPrintedSmth;
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
        public static int ReadNumber(string message, string errorMessage)
        {
            int res = 0;
            bool isCorrect = false;

            do
            {
                Console.Write(message);
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out res)))
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
        private static int ReadNumberWithMinAndMaxValue(string message, string errorMessage, int maxValue = MaxValue,
            int minValue = 0)
        {
            bool isCorrect = false;
            int res;
            do
            {
                res = ReadNumber(message, errorMessage);
                if (!(isCorrect = res >= minValue && res <= maxValue))
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);

            return res;
        }
        
        public static void Main(string[] args)
        {
            do
            {
                int a = ReadNumberWithMinAndMaxValue("Введите левую границу: ",
                    $"левая граница должна быть от 1 до {MaxValue - 1}", minValue: 1, maxValue: MaxValue - 1);
                int b = ReadNumberWithMinAndMaxValue("Введите правую границу: ",
                    $"правая граница должна быть от {a + 1} до {MaxValue}", minValue: a + 1);

                Console.WriteLine("Числа в которых сумма цифр равна их количеству:");
                if (!PrintAllNumberWithEqualDigitSumAndCount(a, b))
                {
                    Console.WriteLine("Таких чисел нет, будет выведены числа, в которых сумма цифр больше в 2 раза" +
                                      " их количества:");
                    
                    if (!PrintAllNumbersWithDigitSumAndCountDiff2Times(a, b))
                        Console.WriteLine("Таких чисел тоже нет.");
                }
                
                Console.WriteLine("\nДля выхода нажмите ESC!");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}