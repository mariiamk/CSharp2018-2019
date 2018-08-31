using System;
using System.Globalization;

/*
Получить от пользователя вещественное значение – бюджет пользователя и целое число – 
процент бюджета, выделенный на компьютерные игры. Вычислить и вывести на экран сумму 
в рублях\евро или долларах, выделенную на компьютерные игры. Использовать спецификаторы 
формата для валют.
*/
class Program
{
    public static double money(double b, uint p)
    {
        return b * (p *1.0 / 100);
    }
    static void Main(string[] args)
    {
        double budget;
        uint percentge;
        string str;
        do
        {
            do
            {
                Console.Write("Введите бюджет: ");
                str = Console.ReadLine();           // Читаем символьную строку 
            } while (!double.TryParse(str, out budget) || (budget < 0)); // Преобразуем строку в число 

            do
            {
                Console.Write("Введите b: ");
                str = Console.ReadLine();           // Читаем символьную строку 
            } while (!uint.TryParse(str, out percentge) || (percentge > 100)); // Преобразуем строку в число 

            Console.WriteLine(money(budget, percentge).ToString("C", CultureInfo.CreateSpecificCulture("en-US")));

        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}

