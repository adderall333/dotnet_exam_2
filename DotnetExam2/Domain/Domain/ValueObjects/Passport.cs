using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public class Passport : ValueObject
    {
        public string Number { get; private set; }
        public string Series { get; private set; }
        public string IssuedBy { get; private set; }
        public string Residence { get; private set; }

        public static Result<Passport> Create(PassportDto dto)
        {
            var validationResult = new PassportValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<Passport>(null, false, validationResult.Error);

            var passport = new Passport
            {
                Number = dto.Number,
                Series = dto.Series,
                IssuedBy = dto.IssuedBy,
                Residence = dto.Residence
            };

            return new Result<Passport>(passport, true);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return Series;
        }
        
        private Passport() {}
    }

    public record PassportDto(
        string Number,
        string Series,
        string IssuedBy,
        string Residence);
}