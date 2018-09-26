using System;

namespace Task2
{
    /// <summary>
    /// Второй вариант
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// На всякий случай
        /// </summary>
        private const double MaxLength = 1e+20;
        
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

                // в идеале лучше сравнивать как result > eps, где eps какое-то маленькое число, потому что так могут ввести
                // 0,00000000000000001, которое в большинстве действий ведет себя как 0 
                if (double.TryParse(Console.ReadLine(), out result) && result > 0 && result < MaxLength)
                    isCorrect = true;
                else
                    Console.WriteLine("Неправильный формат числа!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        /// Проверяет, является ли данная тройка чисел треугольником
        /// </summary>
        /// <param name="a">1 строна</param>
        /// <param name="b">2 сторона</param>
        /// <param name="c">3 сторона</param>
        /// <returns>истина, если является треугольником</returns>
        static bool IsTriangle(double a, double b, double c) => a < b + c && b < a + c && c < a + b; // очень короткие методы можно(не обязательно) записывать так
        // return не нужен

        /// <summary>
        /// Рассчитывает площадь треугольника по его сторонам
        /// </summary>
        /// <param name="a">1 строна</param>
        /// <param name="b">2 сторона</param>
        /// <param name="c">3 сторона</param>
        /// <returns>площадь треугольника</returns>
        static double CalculateTrinagleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        
        public static void Main(string[] args)
        {
            do
            {
                double a = ReadDouble("Введите первую сторону: ");
                double b = ReadDouble("Введите вторую сторону: ");
                double c = ReadDouble("Введите третью сторону: ");

                if (IsTriangle(a, b, c))
                {
                    Console.WriteLine($"Площадь данного треугольника: {CalculateTrinagleArea(a, b, c):F3}");
                }
                else
                {
                    Console.WriteLine($"Данные числа не удволетворяют неравенству треугольника");
                }
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}