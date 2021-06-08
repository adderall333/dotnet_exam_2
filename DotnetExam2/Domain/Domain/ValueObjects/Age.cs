using System.Collections.Generic;
using Core.Infrastructure;
using Core.Strategies;
using Core.Validators;

namespace Core.ValueObjects
{
    public class Age : ValueObject
    {
        public int Value { get; private set; }
        public IAgePointsStrategy PointsStrategy { get; private set; }

        public static Result<Age> Create(AgeDto dto)
        {
            var validationResult = new AgeValidator().Validate(dto);
            if (validationResult.Failure)
                return new Result<Age>(null, false, validationResult.Error);

            var age = new Age {Value = int.Parse(dto.Value)};
            age.PointsStrategy = age.Value switch
            {
                >= 21 and <= 28 => new AgeFrom21To28Strategy(),
                >= 29 and <= 60 => new AgeFrom29To60Strategy(),
                >= 61 and <= 72 => new AgeFrom60To72Strategy()
            };

            return new Result<Age>(age, true);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        
        private Age() {}
    }

    public record AgeDto(string Value);
}