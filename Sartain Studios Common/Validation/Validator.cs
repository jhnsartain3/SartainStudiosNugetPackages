using System.Collections.Generic;

namespace Sartain_Studios_Common.Validation
{
    public class Validator
    {
        private readonly IValidationList _validationList;

        public Validator(IValidationList validationList)
        {
            _validationList = validationList;
        }

        public bool IsValid
        {
            get
            {
                return _validationList.IsValid;
            }
        }

        public IEnumerable<string> Messages
        {
            get
            {
                return _validationList.Messages;
            }
        }
    }
}