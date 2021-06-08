using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public enum DepositType
    {
        None,
        Realty,
        Car,
        Surety
    }
    
    public class Deposit : ValueObject
    {
        public DepositType Type { get; private set; }

        public static Result<Deposit> Create(DepositDto dto)
        {
            var validationResult = new DepositValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<Deposit>(null, false, validationResult.Error);

            var deposit = new Deposit {Type = (DepositType) int.Parse(dto.Type)};

            return new Result<Deposit>(deposit, true);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
        }
        
        private Deposit() {}
    }

    public record DepositDto(string Type);
}