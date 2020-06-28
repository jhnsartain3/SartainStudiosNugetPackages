using System;
using Sartain_Studios_Common.Validation;
using Sartain_Studios_Common_Examples.Validation.Models;
using Sartain_Studios_Common_Examples.Validation.Rules;

namespace Sartain_Studios_Common_Examples.Validation
{
    internal class ValidationExample
    {
        public void RunAllExamples()
        {
            Example1();
        }

        public void Example1()
        {
            var age = 16;
            var consumesAlcohol = true;

            var person = new Person { Age = age, ConsumesAlcohol = consumesAlcohol };

            IValidationList validationList = new ValidationList
            {
                new Age0OrHigherValidation(person),
                new OnlyAdultsCanConsumeAlcoholValidation(person)
            };

            var alcoholSeller = new AlcoholSeller(validationList);

            Console.WriteLine(alcoholSeller.IsValid);

            foreach (var message in alcoholSeller.Messages)
                Console.WriteLine(message);
        }
    }
}