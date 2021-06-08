using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public class LoanAmount : ValueObject
    {
        public int Value { get; set; }

        public static Result<LoanAmount> Create(LoanAmountDto dto)
        {
            var validationResult = new LoanAmountValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<LoanAmount>(null, false, validationResult.Error);

            var loanAmount = new LoanAmount {Value = int.Parse(dto.Value)};

            return new Result<LoanAmount>(loanAmount, true);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        
        private LoanAmount() {}
    }

    public record LoanAmountDto(string Value);
}