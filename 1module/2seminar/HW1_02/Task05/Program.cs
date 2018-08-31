using System;
/*
Получить от пользователя три вещественных числа и проверить для них неравенство треугольника.
Оператор if не применять. Точность вывода три знака после запятой.
*/

class Program
{
    public static bool rectangleInequality(double a, double b, double c)
    {
        if ((a > b + c) ||(b > a + c) || (c > a + b)) return false;
        return true;
    }
    static void Main(string[] args)
    {
        double a, b, c;
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

            if (rectangleInequality(a, b, c))
            {
                Console.WriteLine("Выполняется неравенство треугольника.");
            } else
            {
                Console.WriteLine("Не выполняется неравенство треугольника.");
            }

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}

