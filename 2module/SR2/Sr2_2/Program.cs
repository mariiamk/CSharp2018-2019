using System;

namespace Sr2_2
{
    /// <summary>
    /// Класс для студента
    /// </summary>
    class Student
    {
        /// <summary>
        /// Идентифиактор студента
        /// </summary>
        public long Id {get; private set;}

        /// <summary>
        /// Номер варианта
        /// </summary>
        public int TestNum {get; private set;}

        /// <summary>
        /// Единственный конструктор
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="testNum">номер варианта</param>
        public Student(long id, int testNum)
        {
            Id = id;
            TestNum = testNum;
        }

        /// <summary>
        /// Метод, симулирующий работу студента
        /// </summary>
        /// <param name="length">длина работы</param>
        /// <returns>работа</returns>
        public string DoWork(int length)
        {
            string res = "";

            for (int i = 0; i < length; i++)
                res += TestNum.ToString();

            return res;
        }

        /// <summary>
        /// Переопределенный ToString
        /// </summary>
        /// <returns>идентификатор и номер варианта</returns>
        public override string ToString() 
        {
            return $"ID: {Id}, TestNum: {TestNum}";
        }
    }

    /// <summary>
    /// Класс для семинариста
    /// </summary>
    class Seminarian
    {
        /// <summary>
        /// Количество баллов на 10
        /// </summary>
        public int PointsToTen {get; private set;}

        /// <summary>
        /// Нелюбимый варинат
        /// </summary>
        public int HatefullTestNum {get; private set; }

        /// <summary>
        /// Единственный конструктор
        /// </summary>
        /// <param name="pointsToTen">кол-во баллов на 10</param>
        /// <param name="hatefullTestNum">нелюбимый вариант</param>
        public Seminarian(int pointsToTen, int hatefullTestNum)
        {
            PointsToTen = pointsToTen;
            HatefullTestNum = hatefullTestNum;
        }

        /// <summary>
        /// Проверяет работу студента
        /// </summary>
        /// <param name="work">работа студента</param>
        /// <returns>оценка за работу</returns>
        public int CheckWork(string work)
        {
            double size = work.Length;
            double mark = size / PointsToTen * 10.0f;

            if (work.Length == 0 || (work[0] - '0') == HatefullTestNum)
                return 1;
            else
                return mark < 0 ? 0 : (mark > 10 ? 10 : (int) Math.Round(mark));
        }

        /// <summary>
        /// Переопределенный ToString
        /// </summary>
        /// <returns>кол-во баллов на 10 и нелюбимый вариант</returns>
        public override string ToString()
        {
            return $"PointsToTen: {PointsToTen}, HatefullTestNum: {HatefullTestNum}";
        }
    }

    class Program
    {
        /// <summary>
        /// Максимальное число студентов. Это нужно для размера массива
        /// </summary>
        const int MaxStudentCount = 100;

        /// <summary>
        /// Выводит сообщение пользователю и считывает число
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        /// <returns>считанное число</returns>
        static int ReadInt(string message)
        {
            bool isCorrect = false;
            int res;

            do 
            {
                Console.Write(message);
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out res) && res > 0 && res < MaxStudentCount))
                    Console.WriteLine("Input error!");
            } while (!isCorrect);

            return res;
        }

        static void Main(string[] args)
        {
            do
            {
                int n = ReadInt("Введите кол-во студентов: ");
                var students = new Student[n];
                Random random = new Random();

                const int maxId = 1001;
                const int maxTestNum = 10;
                const int maxWorkLength = 101;
        
                for (int i = 0; i < n; i++)
                    students[i] = new Student(random.Next(0, maxId), random.Next(1, maxTestNum));

                Seminarian s1 = new Seminarian(random.Next(1, maxWorkLength), random.Next(1, maxTestNum));
                Seminarian s2 = new Seminarian(random.Next(1, maxWorkLength), random.Next(1, maxTestNum));

                double average = 0;
                foreach (var student in students)
                {
                    string work = student.DoWork(random.Next(0, maxWorkLength));
                    int mark = (s1.CheckWork(work) + s2.CheckWork(work)) / 2;
                    average += mark;
                    Console.WriteLine("{0}, mark: {1}", student, mark);
                }

                average /= n;
                Console.WriteLine("Average: {0:F3}", average);
                Console.WriteLine(s1);
                Console.WriteLine(s2);
                Console.WriteLine("ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
