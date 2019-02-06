using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar04
{
    class Publisher
    {
        public delegate void Notify(string message);
        public event Notify BeginOutput;
        public event Notify EndOutput;
        public void Display(string message)
        {
            OnBeginOutput();
            Console.WriteLine(message);
            OnEndOutput();
        }
        private void OnBeginOutput()
        {
            if (BeginOutput != null)
                BeginOutput("Starting output");
        }
        private void OnEndOutput()
        {
            if (EndOutput != null)
                EndOutput("Ending output");
        }
    }   // class Publisher

    class Program
    {
        static void StartOutputCallBack(string message)
        {
            Console.WriteLine("StartOutputCallBack - " + message);
        }
        static void EndOutputCallBack(string message)
        {
            Console.WriteLine("EndOutputCallBack - " + message);
        }
        static void Main()
        {
            Publisher publisher = new Publisher();
            publisher.BeginOutput += StartOutputCallBack;
            publisher.EndOutput += EndOutputCallBack;
            publisher.Display("I am a subscriber!");
            publisher.BeginOutput -= StartOutputCallBack;
            publisher.EndOutput -= EndOutputCallBack;
            publisher.Display("\nI am not a subscriber!");
            Console.ReadKey();
        }
    }

}
