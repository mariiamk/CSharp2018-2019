using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_1
{
    /// <summary>
    /// Класс Интерна, наследника Доктора
    /// </summary>
    class Intern : Doctor
    {
        /// <summary>
        /// Переопределенное свойство (опыт работы)
        /// </summary>
        public override int Exp {
            get
            {
                return exp;
            }

            set
            {
                if (value >= 1 && value <= 4)
                    exp = value;
                else
                    exp = random.Next(1, 4);
            }
        }

        /// <summary>
        /// Конструткор класса Интерна
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="exp">Опыт работы</param>
        public Intern(string name, int age, int exp) : base(name, age, exp) { }

        /// <summary>
        /// Возвращает базовую информацию об объекте
        /// </summary>
        /// <returns>Строка, что нужно вернуть</returns>
        public override string Say()
        {
            return $"I am an intern, I've studied for {exp} years";
        }
    }
}
