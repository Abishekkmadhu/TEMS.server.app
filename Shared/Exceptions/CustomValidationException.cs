using FluentValidation.Results;

namespace Shared.Exceptions;

public class CustomValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public CustomValidationException(IEnumerable<ValidationFailure> failures)
        : base("One or more validation errors occurred.")
    {
        Errors = failures
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray()
            );
    }
}
