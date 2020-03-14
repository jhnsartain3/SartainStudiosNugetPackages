namespace Sartain_Studios_Common.Validation
{
    public interface IValidation
    {
        bool IsValid { get; } // True when valid
        string Message { get; } // The message when object is not valid
        void Validate(); // Throws an exception when not valid
    }
}