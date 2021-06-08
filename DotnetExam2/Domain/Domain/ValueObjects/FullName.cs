using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public class FullName : ValueObject
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }

        public static Result<FullName> Create(FullNameDto dto)
        {
            var validationResult = new FullNameValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<FullName>(null, false, validationResult.Error);
            
            var fullName = new FullName
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
            };

            return new Result<FullName>(fullName, true);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            
            if (!string.IsNullOrEmpty(MiddleName))
                yield return MiddleName;
        }
        
        private FullName() {}
    }

    public record FullNameDto(string FirstName, string MiddleName, string LastName);
}