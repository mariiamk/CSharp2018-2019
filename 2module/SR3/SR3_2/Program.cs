using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_2
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
            int n;
            int rnd;
            Creature[] creature;
            do
            {
                n = ReadInt("Введите количество существ: ");
                creature = new Creature[n];

                //генерация массива объектов
                for (int i = 0; i < n - 1; i++)
                {
                    rnd = random.Next(0, 101);
                    if (rnd <= 20)
                    {
                        creature[i] = new Creature(GenerateString(), random.Next(10, 18));
                    } else if (rnd >= 60)
                    {
                        creature[i] = new Dwarf(GenerateString(), random.Next(10, 18), random.Next(-50, 50));
                    } else
                    {
                        creature[i] = new Elf(GenerateString(), random.Next(10, 18));
                    }
                    Console.WriteLine(creature[i]);
                }

                //вызов для отдельных объектов метода MakeNewStaff
                for (int i = 0; i < n - 1; i++)
                {
                    if (creature[i] is Dwarf)
                        ((Dwarf)creature[i]).MakeNewStaff();
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
