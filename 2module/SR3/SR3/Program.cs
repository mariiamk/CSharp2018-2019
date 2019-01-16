using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_1
{
    class Program
    {
        static Random random = new Random();

        /// <summary>
        /// Метод генерации случайной строки длиной от 3 до 10 символов (кстати, можно вынести в параметры)
        /// </summary>
        /// <returns>Сгенерированная строка</returns>
        public static string GenerateString()
        {
            string str = "";
            int n = random.Next(3, 11);
            str += (char)random.Next('A', 'Z' + 1);
            for (int i = 1; i < n - 1; i++)
            {
                str += (char)random.Next('a', 'z' + 1);
            }
            return str;
        }

        /// <summary>
        /// Считывает число, выводя приглашение на консоль
        /// </summary>
        /// <param name="message">приглашение для ввода</param>
        /// <returns>считанное число</returns>
        static int ReadInt(string message)
        {
            bool isCorrect = false;
            int res;

            do
            {
                Console.Write(message);
                if (!(isCorrect = int.TryParse(Console.ReadLine(), out res) && res > 0 && res < 100))
                    Console.WriteLine("Input error!");
            } while (!isCorrect);

            return res;
        }

        static void Main(string[] args)
        {
            Doctor doctor;
            Intern intern;
            int n;
            Person[] persons;
            do
            {
                doctor = new Doctor(GenerateString(), random.Next(18, 60), random.Next(-50, 50));
                intern = new Intern(GenerateString(), random.Next(18, 60), random.Next(-50, 50));
                n = ReadInt("Введите количество пациентов: ");
                persons = new Person[n];

                //генерация массива объектов
                for (int i = 0; i < n - 1; i++)
                    persons[i] = new Person(GenerateString(), random.Next(0, 121));
                persons[n - 1] = new Doctor(GenerateString(), random.Next(18, 60), random.Next(-50, 50));

                //лечение пациентов доктором
                Console.WriteLine(doctor.ToString());
                for (int i = 0; i < n / 2; i++)
                {
                    doctor.Heal(persons[i]);
                }

                //лечение пациентов интерном
                Console.WriteLine(intern.ToString());
                for (int i = n / 2; i < n; i++)
                {
                    intern.Heal(persons[i]);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
