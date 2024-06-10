using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Validation failure.")
        {
            ErrorMessages = new List<string>();
        }
        public List<string> ErrorMessages { get; }
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                ErrorMessages.Add(failure.ErrorMessage);
            }
        }
        
    }
}
