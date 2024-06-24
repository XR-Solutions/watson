using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Watson.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("There were one or more validation errors.")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public List<string> Errors { get; set; }
    }
}
