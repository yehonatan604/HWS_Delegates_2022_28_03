using System;

namespace HWS_Delegates_2022_28_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleCalculator calc = new();
            AtomicCalculator atomicCalc = new(calc.NumberGetter, SimpleCalculator.PrintMenu, calc.GetUserChoice, calc.Calculate, calc.PrintResualtNicely, SimpleCalculator.Validate);
            atomicCalc.Run();
        }
    }
}