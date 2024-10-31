using FluentValidation;
using ProviderMS.Application.Exceptions;

namespace ProviderMS.Application.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        public virtual async Task<bool> ValidateRequest(T request)
        {
            var result = await ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidatorException(string.Join(" ", result.Errors.Select(e => e.ErrorMessage)));
            }

            return result.IsValid;
        }
    }
}