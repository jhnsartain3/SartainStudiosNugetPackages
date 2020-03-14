using System;

namespace Sartain_Studios_Common.Validation
{
    public abstract class ValidationBase<T> : IValidation where T : class
    {
        protected ValidationBase(T context)
        {
            Context = context ?? throw new ArgumentNullException("context");
        }

        protected T Context { get; }

        public void Validate()
        {
            if (!IsValid) throw new ValidationException(Message);
        }

        public abstract bool IsValid { get; }
        public abstract string Message { get; }
    }
}