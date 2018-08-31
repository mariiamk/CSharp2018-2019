using System;

/*
Ввести значение x и вывести значение полинома: F(x) = 12x4 + 9x3 - 3x2 + 2x – 4. 
Не применять возведение в степень. Использовать минимальное количество операций умножения.
*/
class Program
{
    public static double polynom(double x)
    {
        return (x * (x * (x * (12 * x + 9) - 3) + 2) - 4);
    }
    static void Main(string[] args)
    {
        double x;
        string str;
        do
        {
            do
            {
                Console.Write("Введите x: ");
                str = Console.ReadLine();           // Читаем символьную строку 
            } while (!double.TryParse(str, out x)); // Преобразуем строку в число 
            Console.WriteLine(polynom(x));
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}

