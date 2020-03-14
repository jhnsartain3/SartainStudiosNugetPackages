using System.Collections.Generic;
using Sartain_Studios_Common.Validation;

namespace Sartain_Studios_Common_Examples.Validation
{
    public class AlcoholSeller
    {
        private readonly IValidationList _validationList;

        public AlcoholSeller(IValidationList validationList)
        {
            _validationList = validationList;
        }

        public bool IsValid => _validationList.IsValid;

        public IEnumerable<string> Messages => _validationList.Messages;
    }
}