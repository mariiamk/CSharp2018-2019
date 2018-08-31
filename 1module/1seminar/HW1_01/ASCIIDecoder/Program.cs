using System;

/*
Добавьте в решение новый проект с именем ASCIIDecoder. Получать от пользователя целое число
Code из диапазона от 32 до 127 (считать входные данные корректными). Выводить на экран 
изображение символа, представленное в таблице кодов ASCII кодом Code. При выполнении 
задания использовать методы преобразования строк в целые типы и операцию приведения типа.
*/

class Program
{
    static void Main()
    {
        int number;
        Console.WriteLine("Введите число: ");
        int.TryParse(Console.ReadLine(), out number);
        Console.WriteLine((char)number);
        Console.ReadKey();
    }
}

