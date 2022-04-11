using System;

namespace HWS_Delegates_2022_28_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleCalculator calc = new();
            AtomicCalculator atomicCalc = new();
            atomicCalc.GetNumberFromUser += calc.NumberGetter;
            atomicCalc.MenuPrinter += SimpleCalculator.PrintMenu;
            atomicCalc.GetUserChoice += calc.GetUserChoice;
            atomicCalc.Calculate += calc.Calculate;
            atomicCalc.ResultPrinter += (X, Y, op, result) => Console.WriteLine($"\nresult is: {result}");
            atomicCalc.ResultPrinter += calc.PrintResualtNicely;
            atomicCalc.Validate += SimpleCalculator.Validate;
            atomicCalc.Run();
        }
    }
}