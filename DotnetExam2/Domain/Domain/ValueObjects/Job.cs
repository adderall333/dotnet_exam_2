using System.Collections.Generic;
using Core.Infrastructure;
using Core.Validators;

namespace Core.ValueObjects
{
    public enum JobType
    {
        None,
        Contract,
        SelfEmployed,
        Freelance,
        Retiree
    }
    
    public class Job : ValueObject
    {
        public JobType Type { get; private set; }

        public static Result<Job> Create(JobDto dto)
        {
            var validationResult = new JobValidator().Validate(dto);

            if (validationResult.Failure)
                return new Result<Job>(null, false, validationResult.Error);

            var job = new Job {Type = (JobType) int.Parse(dto.Type)};

            return new Result<Job>(job, true);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
        }
        
        private Job() {}
    }

    public record JobDto(string Type);
}