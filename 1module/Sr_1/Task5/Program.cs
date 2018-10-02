using System;

namespace Task5
{
    /// <summary>
    /// 5й вариант
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Ограничим оценку, чтобы не выводить какую-то дичь
        /// </summary>
        private const double MaxMark = 1e+5;
        
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

                if (double.TryParse(Console.ReadLine(), out result) && result > 0 && result < MaxMark)
                    isCorrect = true;
                else
                    Console.WriteLine("Неправильный формат числа!");
            } while (!isCorrect);

            return result;
        }

        /// <summary>
        /// Коэффициенты в формуле
        /// </summary>
        private const double MinHwCoef = 0.62, MaxHwCoef = 0.38, HwCoef = 0.4, ExamCoef = 0.6;
        
        /// <summary>
        /// Рассчитывает оценку за дисциплину
        /// </summary>
        /// <param name="hwMark1">оценка за первое дз</param>
        /// <param name="hwMark2">оценка за второе дз</param>
        /// <param name="examMark">оценка за кр</param>
        /// <returns>итоговая оценка</returns>
        public static int ResultMark(double hwMark1, double hwMark2, double examMark)
        {
            int hwMark = (int) (hwMark1 < hwMark2
                ? MinHwCoef * hwMark1 + MaxHwCoef * hwMark2
                : MaxHwCoef * hwMark1 + MinHwCoef * hwMark2);
            return (int) (hwMark * HwCoef + examMark * ExamCoef);
        }
        
        public static void Main(string[] args)
        {
            do
            {
                double hwMark1 = ReadDouble("Введите оценку за первое дз: ");
                double hwMark2 = ReadDouble("Введите оценку за второе дз: ");
                double examMark = ReadDouble("Введите оценку за контрольную: ");
                
                Console.WriteLine($"Оценка за дисциплину: {ResultMark(hwMark1, hwMark2, examMark)}");
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape); // в этой задаче он не обязателен(по условию)
        }
    }
}