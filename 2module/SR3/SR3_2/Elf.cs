using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_2
{
    class Elf : Creature
    {
        int age;
        static int increment = 77;
        static Random random = new Random();

        /// <summary>
        /// Конструктор класса Dwarf
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="speed">Скорость</param>
        public Elf(string name, int speed) : base(name, speed)
        {
            age = random.Next(100, 201);
        }

        /// <summary>
        /// Метод имитирующий бег
        /// </summary>
        /// <returns>Возвращаемая строка со скоростью</returns>
        public override string Run()
        {
            speed = speed + age / increment;
            return base.Run() + "";
        }
    }
}
