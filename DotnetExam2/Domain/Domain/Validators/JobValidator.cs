using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class JobValidator : IValidator<JobDto>
    {
        public Result Validate(JobDto dto)
        {
            if (string.IsNullOrEmpty(dto.Type))
                return new Result(false, "Job type was empty");

            var parsingResult = int.TryParse(dto.Type, out var parsedType);
            if (!parsingResult)
                return new Result(false, "Job type was not correct");

            if (parsedType is < 0 or > 4)
                return new Result(false, "There is no such job type");

            return new Result(true);
        }
    }
}