using System.Collections.Generic;
using AutoWrapper.Wrappers;

namespace Sartain_Studios_Common.SharedModels
{
    public class AutoWrapperResponseModel<TEntity>
    {
        public string Message { get; set; }
        public TEntity Result { get; set; }
        public bool IsError { get; set; }
        public ErrorDetails Errors { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public class ErrorDetails
        {
            public string Message { get; set; }
            public string Type { get; set; }
            public string Source { get; set; }
            public string Raw { get; set; }
        }
    }
}