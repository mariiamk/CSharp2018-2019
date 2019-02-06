using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task00
{
    class Input
    {
        public delegate void GetUserInputDel(string str);
        public event GetUserInputDel UserInput;

        public void GetUserInput()
        {
            while (true)
            {
                Console.WriteLine(
                    "Type any characters or 'q' to quit end press Enter.");
                string input = Console.ReadLine();
                if (input.Trim() != "q")
                {
                    UserInput(input);
                }
                else break;
            }
        }
    }
    class Program
    {
        public static void UserInputHadler(string str)
        {
            Console.WriteLine("YouTyped: " + str);
        }
        static void Main(string[] args)
        {
            Input input = new Input();
            input.UserInput += UserInputHadler;

            input.GetUserInput();

            Console.ReadKey();
        }
    }
}
