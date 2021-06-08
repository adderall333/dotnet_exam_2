using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class OtherCreditsValidator : IValidator<OtherCreditsDto>
    {
        public Result Validate(OtherCreditsDto dto)
        {
            if (string.IsNullOrEmpty(dto.Has))
                return new Result(false, "Other credits info was empty");
            
            return dto.Has switch
            {
                "y" or "n" => new Result(true),
                _ => new Result(false, "Other credits info was not correct")
            };
        }
    }
}