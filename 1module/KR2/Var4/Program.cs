using System;

namespace Var4
{
    internal class Program
    {

        /// <summary>
        /// Формирует 2 числа, состоящее из чётных и нечетных цифр
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="even">число из четных цирф</param>
        /// <param name="odd">число из нечетных цифр</param>
        public static void FormNumber(int number, out int even, out int odd)
        {
            int digitCnt = CountDigits(number);

            even = odd = 0;
            bool evenCalculated, oddCalculated;
            evenCalculated = oddCalculated = false;
            for (int i = 0; i < digitCnt; i++, number /= 10)
            {
                int mod = number % 10;

                if (mod % 2 == 0)
                {
                    even = even * 10 + mod;
                    evenCalculated = true;
                }
                else
                {
                    odd = odd * 10 + mod;
                    oddCalculated = true;
                }
            }

            odd = NormalizeAnswer(odd, oddCalculated);
            even = NormalizeAnswer(even, evenCalculated);
        }

        /// <summary>
        /// Нормализует ответ, то есть если он есть, то разворачивает число, иначе возвращает -1
        /// </summary>
        /// <param name="answer">"сырой" ответ</param>
        /// <param name="isCalculated">считался ли ответ</param>
        /// <returns>перевернутый ответ или -1</returns>
        private static int NormalizeAnswer(int answer, bool isCalculated)
        {
            if (isCalculated)
                return ReverseNumber(answer);
            return -1;
        }

        /// <summary>
        /// Переворачивает число
        /// </summary>
        /// <param name="number">число</param>
        /// <returns>перевернутое число</returns>
        private static int ReverseNumber(int number)
        {
            int reversed = 0;
            while (number != 0)
            {
                reversed = reversed * 10 + number % 10;
                number /= 10;
            }

            return reversed;
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
            
            int count = 0;
            while (number != 0)
            {
                count++;
                number /= 10;
            }

            return count;
        }

        /// <summary>
        /// Выводит числа из четных и нечетных цифр для всех чисел из [n, maxValue]
        /// </summary>
        /// <param name="minValue">левая граница</param>
        /// <param name="maxValue">правая граница</param>
        private static void ForAllPrintEvenAndOddDigitsNumbers(int minValue, int maxValue = MaxValue)
        {
            for (int i = minValue; i <= maxValue; i++)
            {
                FormNumber(i, out int even, out int odd);
                Console.WriteLine("{0}: {1} {2}", i, even, odd);
            }
        }
        
        
        /// <summary>
        /// Максимальное значение для границы диапазона
        /// </summary>
        private const int MaxValue = 1000; // второй способ контролировать переполнение
        

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
                int n = ReadNumberWithMinAndMaxValue("Введите n: ", $"n от 10 до {MaxValue}!", minValue: 10);
                ForAllPrintEvenAndOddDigitsNumbers(n);
                
                Console.WriteLine("Для выхода Esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}