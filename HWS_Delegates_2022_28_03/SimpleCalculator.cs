using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWS_Delegates_2022_28_03
{
    public class SimpleCalculator
    {
        //static Methods
        public static bool Validate(string? sender, string? s) // Validates if user entered relevant input
        {
            switch (sender)
            {
                case "NumberGetter":
                    {
                        try
                        {
                            int number = Convert.ToInt32(s);
                            if (number < 0)
                            {
                                Console.WriteLine("enter positive number only.");
                                return false;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return false;
                        }
                        return true;
                    }
                case "GetUserChoice":
                    {
                        try
                        {
                            int op = Convert.ToInt32(s);
                            if (op < 0 || op > 4)
                            {
                                Console.WriteLine("enter numbers between 1-4.");
                                return false;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return false;
                        }
                        return true;
                    }
                case "End":
                    {
                        try
                        {
                            int number = Convert.ToInt32(s);
                            if (number < 1 || number > 2)
                            {
                                Console.WriteLine("enter 1-2 only.");
                                return false;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return false;
                        }
                        return true;
                    }
            }
            return false;
        } 
        public static void PrintMenu(int menu) // Prints menues
        {
            switch (menu)
            {
                case 1: Console.WriteLine("please choose an option:\n\n1-Add 2-Substruct 3-Divide 4-Multiply"); break;
                case 2: Console.WriteLine("please choose an option:\n\n1-Again 2-Exit"); break;
            }

        }
        //Methods
        public int NumberGetter() // Gets a number from user
        {
            Console.WriteLine("Enter a number:");
            string? number = Console.ReadLine();
            if (!Validate("NumberGetter", number))
            {
                NumberGetter();
            }
            return Convert.ToInt32(number);
        }
        public int GetUserChoice() //Gets user's choice for the operator menu
        {
            string? number = Console.ReadLine();
            if (!Validate("GetUserChoice", number))
            {
                GetUserChoice();
            }
            return Convert.ToInt32(number);
        }
        public double Calculate(int num1, int num2, int operation) // Calculates two numbers with standart operator
        {
            double result = operation switch
            {
                1 => num1 + num2,
                2 => num1 - num2,
                3 => num1 / num2,
                4 => num1 * num2,
                _ => throw new Exception(),
            };
            return result;
        }
        public void PrintResualtNicely(int num1, int num2, int op, double result) // Converts operator to string & prints everything nicely
        {
            string stringOp = op switch
            {
                1 => "+",
                2 => "-",
                3 => "/",
                4 => "*",
                _ => "",
            };
            Console.WriteLine($"\n*********** {num1} {stringOp} {num2} = {result} *****************");
        }
    }
}
