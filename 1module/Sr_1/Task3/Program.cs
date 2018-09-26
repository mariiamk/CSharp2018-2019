using System;

namespace Task3
{
    /// <summary>
    /// 3й вариант
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

                if (int.TryParse(Console.ReadLine(), out result) && result != 0)
                    isCorrect = true;
                else
                    Console.WriteLine("Неправильный формат числа!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        /// Константа почти 0
        /// </summary>
        private const double Eps = 1e-10;
        
        /// <summary>
        /// Проверяет, что знаменатель не 0.
        /// </summary>
        /// <param name="a">1 число</param>
        /// <param name="b">2 число</param>
        /// <param name="c">3 число</param>
        /// <returns>истина, если знаменатель не 0</returns>
        static bool IsDenominatorNonZero(double a, double b, double c)
        {
            return Math.Abs(1 / a + 1 / b + 1 / c) > Eps; // тут уже лучше точно сравнивать так, потому что есть какие-то действия
        }

        /// <summary>
        /// Рассчитывает среднее гармоническое
        /// </summary>
        /// <param name="a">1 число</param>
        /// <param name="b">2 число</param>
        /// <param name="c">3 число</param>
        /// <returns>среднее гармоническое</returns>
        static double CalculateAverage(double a, double b, double c)
        {
            return 3d / (1 / a + 1 / b + 1 / c);
        }
        
        public static void Main(string[] args)
        {
            do
            {
                double a = ReadInt("Введите первое число: ");
                double b = ReadInt("Введите второе число: ");
                double c = ReadInt("Введите третье число: ");
                
                if (IsDenominatorNonZero(a, b, c))
                {
                    Console.WriteLine($"Среднее гармоническое: {CalculateAverage(a, b, c):F3}");
                }
                else
                {
                    Console.WriteLine($"Среднего не существует, так как знаменатель 0");
                }
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}