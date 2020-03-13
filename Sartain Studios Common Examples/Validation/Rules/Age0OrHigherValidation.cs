using Sartain_Studios_Common.Validation;
using Sartain_Studios_Common_Examples.Validation.Models;

namespace Sartain_Studios_Common_Examples.Validation.Rules
{
    public class Age0OrHigherValidation : ValidationBase<Person>
    {
        public Age0OrHigherValidation(Person context)
            : base(context)
        {
        }

        public override bool IsValid
        {
            get { return Context.Age >= 0; }
        }

        public override string Message
        {
            get
            {
                return string.Format("The Age {1} of {0} is not 0 or higher.",
                    Context.Name, Context.Age);
            }
        }
    }
}