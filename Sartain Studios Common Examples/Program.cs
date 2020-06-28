using Sartain_Studios_Common_Examples.Validation;
using System;

namespace Sartain_Studios_Common_Examples.Time_Calculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("1 for Validation");
            Console.WriteLine("2 for Time Calculator");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ValidationExample validationExample = new ValidationExample();
                    validationExample.Example1();
                    break;
                case 2:
                    TimeCalculatorExample timeCalculatorExample = new TimeCalculatorExample();
                    timeCalculatorExample.RunAllExamples();
                    break;
            }
        }
    }
}