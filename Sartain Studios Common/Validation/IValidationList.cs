using System.Collections.Generic;

namespace Sartain_Studios_Common.Validation
{
    public interface IValidationList
    {
        bool IsValid { get; }
        void Validate();
        IEnumerable<string> Messages { get; }
    }
}