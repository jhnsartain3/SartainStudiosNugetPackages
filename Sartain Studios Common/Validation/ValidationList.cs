using System.Collections.Generic;
using System.Linq;

namespace Sartain_Studios_Common.Validation
{
    public class ValidationList : List<IValidation>, IValidationList
    {
        public bool IsValid
        {
            get { return this.All(item => item.IsValid); }
        }

        public void Validate()
        {
            foreach (var validation in this) validation.Validate();
        }

        public IEnumerable<string> Messages
        {
            get { return this.Where(item => !item.IsValid).Select(item => item.Message); }
        }
    }
}