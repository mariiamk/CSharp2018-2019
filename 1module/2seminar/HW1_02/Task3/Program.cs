using System;
/*
Введя значения коэффициентов А, В, С, вычислить корни квадратного уравнения.
Учесть(как хотите) возможность появления комплексных корней.Оператор if не применять.
*/
class Program
{
    public static double squareRoots(double a, double b, double c, out double x1, out double x2)
    {
        double d = b * b - 4 * a * c;

        x1 = (-b - Math.Sqrt(d)) / (2 * a);
        x2 = (-b - Math.Sqrt(d)) / (2 * a);

        return d;
    }

    static void Main(string[] args)
    {
        double a, b, c;
        double d;
        double x1, x2;
        string str;
        do
        {
            do
            {
                Console.Write("Введите a: ");
                str = Console.ReadLine();           // Читаем символьную строку 
            } while (!double.TryParse(str, out a)); // Преобразуем строку в число 

            do
            {
                Console.Write("Введите b: ");
                str = Console.ReadLine();           // Читаем символьную строку 
            } while (!double.TryParse(str, out b)); // Преобразуем строку в число 

            do
            {
                Console.Write("Введите c: ");
                str = Console.ReadLine();           // Читаем символьную строку 
            } while (!double.TryParse(str, out c)); // Преобразуем строку в число 

            d = squareRoots(a, b, c, out x1, out x2);

            if (d == 0)
            {
                Console.WriteLine("Единственный корень: {0:f3}", x1);
            } else if (d > 0)
            {
                Console.WriteLine("x1: {0:f3}", x1); 
                Console.WriteLine("x2: {0:f3}", x2);
            } else if (d < 0)
            {
                Console.WriteLine("Действительных корней нет");
            }

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}

