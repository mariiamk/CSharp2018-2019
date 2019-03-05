using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar06
{

    
    interface ITransform
    {   // интерфейс преобразование
        void transform(double coef);    // преобразовать 
    }
    class Circle : ITransform
    {   // круг
        double rad = 1;     // радиус круга
        public void transform(double coef) { rad *= coef; }
        public override string ToString()
        {
            return String.Format("Площадь круга: {0:G4}",
                              Math.PI * rad * rad);
        }
    }
    class Cube : ITransform
    {   // куб
        double rib = 1;     // ребро куба
        public void transform(double coef) { rib *= coef; }
        public override string ToString()
        {
            return String.Format("Объем куба: {0:G4}",
                             rib * rib * rib);
        }
    }

    class Program
    {
        public static void report(ITransform g)
        {
            Console.WriteLine("Данные объекта класса {0}:",
                                               g.GetType());
            Console.WriteLine(g);
        }

        public static void Main()
        {
            Circle cir = new Circle();
            report(cir);
            Cube cub = new Cube();
            report(cub);
            ITransform ira = cir;
            report(ira);
            Console.ReadKey();
        }
    }
}
