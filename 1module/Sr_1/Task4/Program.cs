using System;

namespace Task4
{
    /// <summary>
    /// 4й вариант
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Ограничение для числа
        /// </summary>
        private const int MinCorrectValue = 1000, MaxCorrectValue = 9999;
        
        /// <summary>
        /// Метод для считывания целого числа
        /// </summary>
        /// <param name="message">сообщение в консоль</param>
        /// <returns>считанное число</returns>
        static int ReadInt(string message)
        {
            bool isCorrect = false;
            int result;
            do
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out result) &&
                    result <= MaxCorrectValue &&
                    result >= MinCorrectValue)
                {
                    isCorrect = true;
                }
                else
                    Console.WriteLine("Неправильный формат числа!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        /// Считает сумму и произведение цифр числа
        /// </summary>
        /// <param name="n">число</param>
        /// <param name="sum">сумма его цифр</param>
        /// <param name="product">произведение его цифр</param>
        static void CalculateDigitsSumAndProduct(int n, out int sum, out int product)
        {
            sum = 0;
            product = 1;
            while (n != 0)
            {
                sum += n % 10;
                product *= n % 10;
                n /= 10;
            }
        }
        
        public static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите число: ");
                int sum, product;
                
                CalculateDigitsSumAndProduct(n, out sum, out product);
                //CalculateDigitsSumAndProduct(n, out var sum, out var product); //в новых версия си шарпа можно делать так
                //без объявления переменных до вызова

                if (product != 0)
                {
                    Console.WriteLine($"Частное суммы и произведения цифр: {(double)sum / product:F3}");
                }
                else
                {
                    Console.WriteLine("В числе есть 0, значит такого частного не существует");
                }
                
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}