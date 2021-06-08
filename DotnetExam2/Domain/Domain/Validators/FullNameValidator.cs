using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class FullNameValidator : IValidator<FullNameDto>
    {
        public Result Validate(FullNameDto dto)
        {
            var (firstName, _, lastName) = dto;
            
            if (string.IsNullOrEmpty(firstName))
                return new Result(false, "First name was empty");

            if (string.IsNullOrEmpty(lastName))
                return new Result(false, "Last name was empty");

            return new Result(true);
        }
    }
}