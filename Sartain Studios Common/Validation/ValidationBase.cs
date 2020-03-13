using System;

namespace Sartain_Studios_Common.Validation
{
    public abstract class ValidationBase<T> : IValidation where T : class
    {
        protected T Context { get; private set; }

        protected ValidationBase(T context)
        {
            Context = context ?? throw new ArgumentNullException("context");
        }

        public void Validate()
        {
            if (!IsValid)
            {
                throw new ValidationException(Message);
            }
        }

        public abstract bool IsValid { get; }
        public abstract string Message { get; }
    }
}