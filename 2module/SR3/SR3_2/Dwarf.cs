using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_2
{
    class Dwarf : Creature
    {
        int strength;

        /// <summary>
        /// Для генерации случайного числа при вводе недопустимых чисел
        /// </summary>
        protected static Random random = new Random();

        /// <summary>
        /// Конструктор класса Dwarf
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="speed">Скорость</param>
        /// <param name="strength">Сила персонажа</param>
        public Dwarf(string name, int speed, int strength) : base(name, speed)
        {
            Strength = strength;
        }

        /// <summary>
        /// Свойство с проверкой значения для поля strength (сила)
        /// </summary>
        public int Strength
        {
            get
            {
                return strength;
            }
            set
            {
                if (value >= 1 && value <= 20)
                    strength = value;
                else
                    strength = random.Next(1, 21);
            }
        }

        /// <summary>
        /// Метод имитирующий бег
        /// </summary>
        /// <returns>Возвращаемая строка со скоростью</returns>
        public override string Run()
        {
            return base.Run() + $"My strength is {strength}.";
        }

        /// <summary>
        /// Метод для создания магической вещи 
        /// </summary>
        public void MakeNewStaff()
        {
            Console.WriteLine("I've created a new staff!");
        }
    }
}
