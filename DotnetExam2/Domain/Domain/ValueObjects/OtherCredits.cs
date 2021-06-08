using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public class OtherCredits : ValueObject
    {
        public bool Has { get; private set; }

        public static Result<OtherCredits> Create(OtherCreditsDto dto)
        {
            var validationResult = new OtherCreditsValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<OtherCredits>(null, false, validationResult.Error);

            var otherCredits = new OtherCredits {Has = dto.Has == "y"};

            return new Result<OtherCredits>(otherCredits, true);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Has;
        }
        
        private OtherCredits() {}
    }

    public record OtherCreditsDto(string Has);
}