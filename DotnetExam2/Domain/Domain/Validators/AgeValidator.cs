using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class AgeValidator : IValidator<AgeDto>
    {
        public Result Validate(AgeDto dto)
        {
            var value = dto.Value;
            
            var parsingResult = int.TryParse(value, out var parsedValue);
            if (!parsingResult)
                return new Result(false, "Age was not correct");

            if (parsedValue < 21)
                return new Result(false, "Age was less than 21");

            return new Result(true);
        }
    }
}