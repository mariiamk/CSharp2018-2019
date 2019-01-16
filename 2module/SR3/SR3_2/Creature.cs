using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_2
{
    class Creature
    {
        string name;
        protected int speed;

        /// <summary>
        /// Свойство имитирующее бег
        /// </summary>
        /// <returns></returns>
        public virtual string Run()
        {
            return $"I am running with a speed of {speed}.";
        }

        /// <summary>
        /// Переопределенный метод ToString()
        /// </summary>
        /// <returns>Возвращаемая строка с информацией об объекте</returns>
        public override string ToString()
        {
            return Run() + $" My name is {name}.";
        }

        /// <summary>
        /// Конструктор класса Creature
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="speed">Скорость</param>
        public Creature(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }
    }
}
