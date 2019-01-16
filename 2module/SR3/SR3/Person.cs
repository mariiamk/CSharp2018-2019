using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3_1
{
    class Person
    {
        string name;
        int age;

        /// <summary>
        /// Конструктор для инициализации Person
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        /// <summary>
        /// Возвращает базовую информацию об объекте
        /// </summary>
        /// <returns>Строка, что нужно вернуть</returns>
        public virtual string Say()
        {
            return ("I am a simple person.");
        }

        /// <summary>
        /// Переопределенный метод ToString()
        /// </summary>
        /// <returns>Возвращаемая строка с информацией об объекте</returns>
        public override string ToString()
        {
            return Say() + $" My name = {name}; age = {age}";
        }
    }
}
