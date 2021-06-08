using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class LoanAmountValidator : IValidator<LoanAmountDto>
    {
        public Result Validate(LoanAmountDto dto)
        {
            var value = dto.Value;
            var parsingResult = int.TryParse(value, out var parsedValue);

            if (!parsingResult)
                return new Result(false, "Loan amount was incorrect");

            if (parsedValue <= 0)
                return new Result(false, "Loan amount was non-positive");

            return new Result(true);
        }
    }
}