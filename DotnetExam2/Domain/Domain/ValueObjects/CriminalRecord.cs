using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public class CriminalRecord : ValueObject
    {
        public bool HasNote { get; private set; }

        public static Result<CriminalRecord> Create(CriminalRecordDto dto)
        {
            var validationResult = new CriminalRecordValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<CriminalRecord>(null, false, validationResult.Error);

            var criminalRecord = new CriminalRecord {HasNote = dto.HasNote == "y"};

            return new Result<CriminalRecord>(criminalRecord, true);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return HasNote;
        }
        
        private CriminalRecord() {}
    }

    public record CriminalRecordDto(string HasNote);
}