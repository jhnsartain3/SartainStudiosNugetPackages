using Sartain_Studios_Common.Validation;
using Sartain_Studios_Common_Examples.Validation.Models;
using Sartain_Studios_Common_Examples.Validation.Rules;
using System;

namespace Sartain_Studios_Common_Examples.Validation
{
    class ValidationExample
    {
        static void Main(string[] args)
        {
            int age = 16;
            bool consumesAlcohol = true;

            var person = new Person { Age = age, ConsumesAlcohol = consumesAlcohol };

            IValidationList validationList = new ValidationList
            {
                new Age0OrHigherValidation(person),
                new OnlyAdultsCanConsumeAlcoholValidation(person)
            };

            AlcoholSeller alcoholSeller = new AlcoholSeller(validationList);

            Console.WriteLine(alcoholSeller.IsValid);

            foreach (var message in alcoholSeller.Messages)
                Console.WriteLine(message);
        }
    }
}