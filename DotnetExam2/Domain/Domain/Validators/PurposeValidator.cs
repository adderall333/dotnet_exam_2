using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class PurposeValidator : IValidator<PurposeDto>
    {
        public Result Validate(PurposeDto dto)
        {
            if (string.IsNullOrEmpty(dto.Type))
                return new Result(false, "Purpose type was empty");
            
            var parsingResult = int.TryParse(dto.Type, out var parsedType);
            if (!parsingResult)
                return new Result(false, "Purpose type was not correct");

            if (parsedType is < 0 or > 2)
                return new Result(false, "There is no such purpose type");

            return new Result(true);
        }
    }
}