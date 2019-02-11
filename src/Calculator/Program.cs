using System;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num1;
            int num2;
            string operand;
            float answer;

            Console.Write("Please enter the first integer: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter an operand (+, -, /, *): ");
            operand = Console.ReadLine();
            Console.Write("Please enter the second integer: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            switch (operand)
            {
                case "-":
                    answer = CalculaterLibrary.Calculator.Subtract(num1, num2);
                    break;
                case "+":
                    answer = CalculaterLibrary.Calculator.Add(num1, num2);
                    break;
                case "/":
                    answer = CalculaterLibrary.Calculator.Divide(num1, num2);
                    break;
                case "*":
                    answer = CalculaterLibrary.Calculator.Multiply(num1, num2);
                    break;
                default:
                    answer = CalculaterLibrary.Calculator.Subtract(num1, num2);
                    break;
            }

            Console.WriteLine(num1.ToString() + " " + operand + " " + num2.ToString() + " = " + answer.ToString());
            Console.ReadKey();
        }
    }
}

