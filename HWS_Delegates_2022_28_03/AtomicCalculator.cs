using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWS_Delegates_2022_28_03
{
    public class AtomicCalculator
    {
        //Properties
        public int X { get; set; }
        public int Y { get; set; }
        public int Op { get; set; }

        //Anonymous Functions
        public Func<int> GetNumberFromUser { get; set; }
        public Action<int> MenuPrinter { get; set; }
        public Func<int> GetUserChoice { get; set; }
        public Func<int, int, int, double> Calculate { get; set; }
        public Action<int, int, int, double> ResultPrinter { get; set; }
        public Func<string, string?, bool> Validate { get; set; }

        //Constructor - gets functions as parameters for initializing the Anonimous Functions
        public AtomicCalculator(Func<int> getNumberFromUser, Action<int> menuPrinter, Func<int> getUserChoice, 
                                Func<int, int, int, double> calculate, Action<int, int, int, double> resultPrinter, 
                                Func<string, string, bool> validate )
        {
            GetNumberFromUser += getNumberFromUser;
            MenuPrinter += menuPrinter;
            GetUserChoice += getUserChoice;
            Calculate += calculate;
            ResultPrinter += (X, Y, op, result) => Console.WriteLine($"\nresult is: {result}");
            ResultPrinter += resultPrinter;
            Validate += validate;
        }

        //Methods
        public void Run() // Running the Calculator
        {
            X = GetNumberFromUser();
            Y = GetNumberFromUser();
            MenuPrinter(1);
            Op = GetUserChoice();
            ResultPrinter(X, Y, Op, Calculate(X, Y, Op));

            End();
        }
        public void End() // Lets the user choose if Calculate again or Exit
        {
            MenuPrinter(2);
            string? option = Console.ReadLine();
            if (!Validate("End", option))
            {
                End();
            }
            switch (option)
            {
                case "1": { Run(); break; }
                case "2": { return; }
            }
        }
    }
}
