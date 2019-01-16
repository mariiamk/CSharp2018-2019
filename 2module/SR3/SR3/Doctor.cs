using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_1
{
    /// <summary>
    /// Класс Doctor, наследник Person
    /// </summary>
    class Doctor : Person
    {
        /// <summary>
        /// Количество лет опыта
        /// </summary>
        protected int exp;

        /// <summary>
        /// Для генерации случайного числа при вводе недопустимых чисел
        /// </summary>
        protected static Random random = new Random();

        /// <summary>
        /// Свойство для соответствующего поля exp
        /// </summary>
        public virtual int Exp
        {
            get
            {
                return exp;
            }

            set
            {
                if (value >= 5 && value <= 20)
                    exp = value;
                else
                    exp = random.Next(5, 21);
            }
        }

        /// <summary>
        /// Конструктор класса Doctor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="exp">Количество лет опыта</param>
        public Doctor(string name, int age, int exp) : base(name, age)
        {
            Exp = exp;
        }

        /// <summary>
        /// Метод лечения пациента
        /// </summary>
        /// <param name="person">Пациент</param>
        public void Heal(Person person)
        {
            Console.WriteLine("I'm gonna heal: " + person.ToString());
        }

        /// <summary>
        /// Метод, выводящий информацию о докторе
        /// </summary>
        /// <returns></returns>
        public override string Say()
        {
            return $"I am a doctor, I've studied for {exp} years";
        }

    }
}
