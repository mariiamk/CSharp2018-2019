using System;

namespace Var1
{
    internal class Program
    {
        /// <summary>
        /// Ограничение сверху для радиуса, 10000, чтобы недолго работало
        /// </summary>
        private const int MaxRadiusValue = 10000;

        /// <summary>
        /// Считывает целое число
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="minValue">Минимальное значение числа</param>
        /// <param name="maxValue">Максимальное значение числа</param>
        /// <returns>Считанное число</returns>
        static int ReadInt(string message, string errorMessage = "Ошибка ввода!", int minValue = 1,
            int maxValue = MaxRadiusValue) // полезно использовать аргументы по умолчанию, чтобы сделать метод более гибким
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
        /// Считает длину окружности и площадь круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <param name="area">Площадь круга</param>
        /// <param name="length">Длина окружности</param>
        static void CalculateCircleAreaAndLength(int radius, out double area, out double length)
        {
            area = Math.PI * Math.Pow(radius, 2);
            length = 2 * Math.PI * radius;
        }
        
        public static void Main(string[] args)
        {
            do
            {
                int r = ReadInt("Введите r: ");
                int R = ReadInt("Введите R: ", minValue: r + 1);
                
                for (int radius = r; radius <= R; radius++)
                {
                    double area, length;
                    CalculateCircleAreaAndLength(radius, out area, out length);
                    
                    Console.WriteLine($"радиус:{radius, 5}, площадь круга:{area, 13:F3}, длина окружности: " +
                                      $"{length, 8:F3}, соотношение: {area / length, 8:F3}");
                }
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}