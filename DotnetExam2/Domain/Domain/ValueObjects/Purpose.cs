using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public enum PurposeType
    {
        ConsumerLoan,
        Realty, 
        ReCrediting
    }
    
    public class Purpose : ValueObject
    {
        public PurposeType Type { get; private set; }

        public static Result<Purpose> Create(PurposeDto dto)
        {
            var validationResult = new PurposeValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<Purpose>(null, false, validationResult.Error);

            var purpose = new Purpose {Type = (PurposeType) int.Parse(dto.Type)};

            return new Result<Purpose>(purpose, true);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
        }
        
        private Purpose() {}
    }

    public record PurposeDto(string Type);
}