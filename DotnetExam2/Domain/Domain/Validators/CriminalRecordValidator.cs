using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class CriminalRecordValidator : IValidator<CriminalRecordDto>
    {
        public Result Validate(CriminalRecordDto dto)
        {
            if (string.IsNullOrEmpty(dto.HasNote))
                return new Result(false, "Criminal record info was empty");

            return dto.HasNote switch
            {
                "y" or "n" => new Result(true),
                _ => new Result(false, "Criminal record info was not correct")
            };
        }
    }
}