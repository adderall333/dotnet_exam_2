using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class DepositValidator : IValidator<DepositDto>
    {
        public Result Validate(DepositDto dto)
        {
            if (string.IsNullOrEmpty(dto.Type))
                return new Result(false, "Deposit type was empty");

            var parsingResult = int.TryParse(dto.Type, out var parsedType);
            if (!parsingResult)
                return new Result(false, "Deposit type was not correct");

            if (parsedType is < 0 or > 3)
                return new Result(false, "There is no such deposit type");

            return new Result(true);
        }
    }
}