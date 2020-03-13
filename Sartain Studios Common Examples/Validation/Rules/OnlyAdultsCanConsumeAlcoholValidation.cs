using Sartain_Studios_Common.Validation;
using Sartain_Studios_Common_Examples.Validation.Models;

namespace Sartain_Studios_Common_Examples.Validation.Rules
{
    public class OnlyAdultsCanConsumeAlcoholValidation : ValidationBase<Person>
    {
        private const int MinimumAge = 18;

        public OnlyAdultsCanConsumeAlcoholValidation(Person context)
        : base(context)
        {
        }

        public override bool IsValid
        {
            get { return !Context.ConsumesAlcohol || Context.Age >= 18; }
        }

        public override string Message
        {
            get
            {
                return string.Format(
                "{0} is not allowed to consume alcohol because his or her age ({1}) is not {2} or higher.",
                Context.Name, Context.Age, MinimumAge);
            }
        }
    }
}