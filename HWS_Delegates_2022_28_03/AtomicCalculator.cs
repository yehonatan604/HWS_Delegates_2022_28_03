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
        public Func<int>? GetNumberFromUser { get; set; }
        public Action<int>? MenuPrinter { get; set; }
        public Func<int>? GetUserChoice { get; set; }
        public Func<int, int, int, double>? Calculate { get; set; }
        public Action<int, int, int, double>? ResultPrinter { get; set; }
        public Func<string, string?, bool>? Validate { get; set; }        

        //Methods
        public void Run() // Running the Calculator
        {
            if (GetNumberFromUser != null && GetNumberFromUser != null && MenuPrinter != null && GetUserChoice != null && ResultPrinter != null && Calculate != null)
            {
                X = GetNumberFromUser();
                Y = GetNumberFromUser();
                MenuPrinter(1);
                Op = GetUserChoice();
                ResultPrinter(X, Y, Op, Calculate(X, Y, Op));
            }
            End();
        }
        public void End() // choose if Calculate again or Exit
        {
            if (Validate != null && MenuPrinter != null)
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
}
