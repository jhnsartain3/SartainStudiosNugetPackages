using Sartain_Studios_Common.Time_Calculator;
using System;
using System.Collections.Generic;

namespace Sartain_Studios_Common_Examples.Time_Calculator
{
    internal class TimeCalculatorExample
    {
        readonly DateTime startingInstance = DateTime.Now;
        readonly DateTime endingInstance = DateTime.Now.AddDays(1);
        List<(DateTime startingInstance, DateTime endingInstance)> listOfStartingAndEndingTimes;

        ITimeCalculator timeCalculator = new TimeCalculator();

        public void RunAllExamples()
        {
            listOfStartingAndEndingTimes = new List<(DateTime startingInstance, DateTime endingInstance)> { (startingInstance, endingInstance) };

            GetElapsedTimeQuantitiesSingle();

            GetElapsedTimeQuantitiesMany();

            GetElapsedHours();
        }

        public void GetElapsedTimeQuantitiesSingle()
        {
            Console.WriteLine("GetElapsedTimeQuantitiesSingle()");
            var resultGetElapsedTimeQuantitiesSingle = timeCalculator.GetElapsedTimeQuantities(startingInstance, endingInstance);
            Console.WriteLine(resultGetElapsedTimeQuantitiesSingle.TotalDays);
        }

        public void GetElapsedTimeQuantitiesMany()
        {
            Console.WriteLine("GetElapsedTimeQuantitiesMany()");
            var resultGetElapsedTimeQuantitiesMany = timeCalculator.GetElapsedTimeQuantities(listOfStartingAndEndingTimes);
            Console.WriteLine(resultGetElapsedTimeQuantitiesMany.TotalDays);
        }

        public void GetElapsedHours()
        {
            Console.WriteLine("GetElapsedHours()");
            var resultGetElapsedTimeQuantitiesMany = timeCalculator.GetElapsedHours(listOfStartingAndEndingTimes);
            Console.WriteLine(resultGetElapsedTimeQuantitiesMany);
        }
    }
}
