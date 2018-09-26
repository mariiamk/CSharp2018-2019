using System;

namespace Task1
{
    /// <summary>
    /// Первый вариант
    /// </summary>
    internal class Program
    {
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

                if (int.TryParse(Console.ReadLine(), out result) && result >= 0)
                    isCorrect = true;
                else
                    Console.WriteLine("Неправильный формат числа!");
            } while (!isCorrect);

            return result;
        }
        
        /// <summary>
        /// Метод для считывания вещественного числа
        /// </summary>
        /// <param name="message">сообщение в консоль</param>
        /// <returns>считанное число</returns>
        static double ReadDouble(string message)
        {
            bool isCorrect = false;
            double result;
            do
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out result) && result >= 0)
                    isCorrect = true;
                else
                    Console.WriteLine("Неправильный формат числа!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        /// Время, с которого начинается скидка.
        /// Это хороший тон, если вдруг скидка будет не с 5 минут, то придется поменять только одну строчку кода
        /// </summary>
        private const int SaleStartTime = 300;

        /// <summary>
        /// Размер после применения скидки 
        /// </summary>
        private const double SaleSize = 0.8;
        
        public static void Main(string[] args)
        {
            do
            {
                int t = ReadInt("Введите длительность разговора: ");
                double p = ReadDouble("Введите стоимость секунды разговора: ");

                double resultPrice = t > SaleStartTime ? 
                    SaleStartTime * p + (t - SaleStartTime) * p * SaleSize :
                    t * p;
                
                Console.WriteLine($"Стоимость разговора: {resultPrice:F3}");
                Console.WriteLine("Для выхода нажмите esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape); // здесь true, чтобы символ не отображался в консоле
        }
    }
}