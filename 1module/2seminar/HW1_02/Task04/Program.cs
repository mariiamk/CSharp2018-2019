using System;


/*
Получить от пользователя четырехзначное натуральное число и напечатать его цифры в обратном порядке. 
*/
class Program
{
    static void Numerals(uint number, out uint f1, out uint f2, out uint f3, out uint f4)
    {
        f1 = number / 1000;            
        f2 = (number - 1000*f1)/100;             
        f3 = (number % 100)/10;
        f4 = number % 10;
    }
    static void Main()
    {
        uint numb = 7591;
        do
        {
            do Console.Write("Введите целое от 1000 до 9999: ");
            while (!uint.TryParse(Console.ReadLine(), out numb) ||
                           numb < 1000 ||
                                 numb > 9999);
            uint a, b, c, d;
            Numerals(numb, out a, out b, out c, out d);
            Console.WriteLine(d);
            Console.WriteLine(c);
            Console.WriteLine(b);
            Console.WriteLine(a);
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}