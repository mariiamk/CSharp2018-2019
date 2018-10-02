using System;

namespace Task6
{
    /// <summary>
    /// 6й вариант
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
        private const double MinExamCoef = 0.76, MaxExamCoef = 0.24, HwCoef = 0.4, ExamCoef = 0.6;
        
        /// <summary>
        /// Рассчитывает оценку за дисциплину
        /// </summary>
        /// <param name="hwMark">оценка за дз</param>
        /// <param name="examMark1">оценка за первую кр</param>
        /// <param name="examMark2">оценка за вторую кр</param>
        /// <returns>итоговая оценка</returns>
        public static int ResultMark(double hwMark, double examMark1, double examMark2)
        {
            int examMark = (int) (examMark1 < examMark2
                ? examMark1 * MinExamCoef + examMark2 * MaxExamCoef
                : examMark1 * MaxExamCoef + examMark2 * MinExamCoef);
            return (int) (hwMark * HwCoef + examMark * ExamCoef);
        }
        
        public static void Main(string[] args)
        {
            do
            {
                double hwMark = ReadDouble("Введите оценку за дз: ");
                double examMark1 = ReadDouble("Введите оценку за первую кр: ");
                double examMark2 = ReadDouble("Введите оценку за вторую кр: ");
                
                Console.WriteLine($"Оценка за дисциплину: {ResultMark(hwMark, examMark1, examMark2)}");
                Console.WriteLine("Для выхода нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape); // в этой задаче он не обязателен(по условию)
        }
    }
}