using System;

/*
Task05. Получить от пользователя значения длин двух катетов, вычислить и вывести на экран 
значение гипотенузы.
*/
class Program
{
    static void Main()
    {
        double a, b;
        Console.Write("Катет 1: ");
        double.TryParse(Console.ReadLine(), out a);
        Console.Write("Катет 2: ");
        double.TryParse(Console.ReadLine(), out b);

        Console.WriteLine("Гипотенуза: " + (Math.Sqrt(a*a+b*b)).ToString("F3"));

        Console.ReadKey();
    }
}
