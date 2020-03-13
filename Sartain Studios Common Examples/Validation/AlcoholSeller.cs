using Sartain_Studios_Common.Validation;
using System.Collections.Generic;

namespace Sartain_Studios_Common_Examples.Validation
{
    public class AlcoholSeller
    {
        private readonly IValidationList _validationList;

        public AlcoholSeller(IValidationList validationList)
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