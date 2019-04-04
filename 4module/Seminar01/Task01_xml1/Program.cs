﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task01_xml1
{
    [Serializable]
    public class Student
    {
        public string name;
        public int year;
        public Student()
        {

        }
        public Student(string n, int y)
        {
            name = n;
            year = y;
        }
    }
    [Serializable]
    public class Group
    {
        public string ident;   // group's identifier
        public Student[] list;  // students' list
        public Group()
        {

        }
        public Group(string id, Student[] list)
        {
            ident = id;
            this.list = list;
        }
        public new string ToString()
        {
            string temp = ident + ": ";
            foreach (Student st in list)
                temp += st.name + "-" + st.year + "  ";
            return temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] list171 = {new Student("Иванов", 1),
                new Student("Петров", 1),new Student("Сидоров",1)};
            Group gr171 = new Group("ПИ-171", list171);

            FileStream bas = new FileStream("group.ser", FileMode.Create);
            XmlSerializer format = new XmlSerializer(typeof(Group), new Type[] { typeof(Student) });
            format.Serialize(bas, gr171);
            bas.Close();

            Console.WriteLine("Выполнена запись в файл group.ser");

            bas = new FileStream("group.ser", FileMode.Open);

            Group gr = (Group)format.Deserialize(bas);
            Console.WriteLine(gr.ToString());
            
            Console.ReadKey();
        }
    }
}
