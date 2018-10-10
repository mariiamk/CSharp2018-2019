using System;

namespace Var2
{
    internal class Program
    {
        /// <summary>
        /// Ограничение сверху для стороны, 10000, чтобы недолго работало
        /// </summary>
        private const int MaxSideValue = 10000;

        /// <summary>
        /// Считывает целое число
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="minValue">Минимальное значение числа</param>
        /// <param name="maxValue">Максимальное значение числа</param>
        /// <returns>Считанное число</returns>
        static int ReadInt(string message, string errorMessage = "Ошибка ввода!", int minValue = 1,
            int maxValue = MaxSideValue)
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
        /// Считает периметр и площадь треугольника
        /// </summary>
        /// <param name="side">сторона треугольника</param>
        /// <param name="area">площадь треугольника</param>
        /// <param name="perimeter">периметр треугольника</param>
        static void CalculateTrinagleAreaAndPerimeter(int side, out double area, out double perimeter)
        {
            area = Math.Sqrt(3) / 4 * Math.Pow(side, 2);  // можно считать через герона(намек критерия на 10)
            perimeter = 3.0 * side;
        }
        
        public static void Main(string[] args)
        {
            do
            {
                int a = ReadInt("Введите a: ");
                int A = ReadInt("Введите A: ", minValue: a + 1);
                
                for (int side = a; side <= A; side++)
                {
                    double area, length;
                    CalculateTrinagleAreaAndPerimeter(side, out area, out length);
                    
                    Console.WriteLine($"сторона:{side, 5}, площадь треугольника:{area, 13:F3}, длина треугольника: " +
                                      $"{length, 8:F3}, соотношение: {area / length, 8:F3}");
                }
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}