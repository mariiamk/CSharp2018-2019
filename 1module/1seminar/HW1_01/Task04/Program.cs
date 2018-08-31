using System;

/*
Task04. Получить от пользователя значения напряжения U и сопротивления R, вычислить силу 
тока  I = U/R и потребляемую мощность  P = U2/R электрической цепи.
*/

class Program
{
    static void Main()
    {
        double U, R;
        Console.Write("Введите напряжение: ");
        double.TryParse(Console.ReadLine(), out U);
        Console.Write("Введите сопротивление: ");
        double.TryParse(Console.ReadLine(), out R);

        Console.WriteLine("Сила тока: " + (U / R).ToString("F3"));
        Console.WriteLine("Мощность: " + (U * U / R).ToString("F3"));
        Console.ReadKey();
    }
}
