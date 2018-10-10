using System;

namespace Var3
{
    internal class Program
    {
        
        /// <summary>
        /// Ограничение сверху для количества точек, 10000, чтобы недолго работало
        /// </summary>
        private const int MaxPointCount = 10000;
        
        /// <summary>
        /// Константа для сравнения
        /// </summary>
        private const double Eps = 1e-7;

        /// <summary>
        /// Интервал, в котором могут быть точки
        /// </summary>
        private const double PointsInterval = 1e+5;
        
        /// <summary>
        /// Считывает целое число
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="minValue">Минимальное значение числа</param>
        /// <param name="maxValue">Максимальное значение числа</param>
        /// <returns>Считанное число</returns>
        static int ReadInt(string message, string errorMessage = "Ошибка ввода!", int minValue = 1,
            int maxValue = MaxPointCount)
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
        /// Считывает вещественное число
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <param name="minValue">Минимальное значение числа</param>
        /// <param name="maxValue">Максимальное значение числа</param>
        /// <returns>Считанное число</returns>
        static double ReadDouble(string message, string errorMessage = "Ошибка ввода!", double minValue = -PointsInterval,
            double maxValue = PointsInterval)
        {
            double res;
            bool isCorrect = false;

            do
            {
                Console.Write(message);
                // можно вынести isCorrect в ветку else (намек критерия на 10)
                if (!(isCorrect = double.TryParse(Console.ReadLine(), out res) && res - minValue >= Eps 
                                                                               && maxValue - res >= Eps))  // так нужно сравнивать вещественные числа
                    Console.Error.WriteLine(errorMessage); // вывод в stderr(поток ошибок)
            } while (!isCorrect);

            return res;
        }

        /// <summary>
        /// Считает значения функция
        /// </summary>
        /// <param name="x">точка</param>
        /// <param name="f1Value">значение функции 1</param>
        /// <param name="f2Value">значение функции 2</param>
        /// <param name="firstSuccess">Успешно ли посчитана первая функция</param>
        /// <param name="secondSuccess">Успешно ли посчитана вторая функция</param>
        static void CalculateFunctions(double x, out double f1Value, out double f2Value, out bool firstSuccess,
            out bool secondSuccess) // по-моему красивее всего сделать так
        {
            firstSuccess = secondSuccess = true;
            f1Value = f2Value = 0;
            
            if (-7 - x >= Eps)
                firstSuccess = false;
            else
                f1Value = Math.Log(x + 7);

            if (Math.Abs(x) < Eps)
                secondSuccess = false;
            else
                f2Value = 1.0 / (2 * x);
        }
        
        public static void Main(string[] args)
        {
            do
            {
                double x = ReadDouble("Введите x: ");
                double y = ReadDouble("Введите y: ", minValue: x + Eps);
                int n = ReadInt("Введите n: ");

                double delta = (y - x) / n;
                double current = x;
                for (int i = 0; i < n; i++, current += delta)
                {
                    double value1, value2;
                    bool success1, success2;
                    
                    CalculateFunctions(current, out value1, out value2, out success1, out success2);
                    Console.WriteLine("в точке {2:F3} значение первой фуннкции{0}, значение второй функции{1}",
                        success1 ? ": " + value1.ToString("F3") : " не удалось посчитать",
                        success2 ? ": " + value2.ToString("F3") : " не удалось посчитать",
                        current);
                }
                
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}