using System.Linq;
using System.Runtime.InteropServices;
using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Validators
{
    public class PassportValidator : IValidator<PassportDto>
    {
        public Result Validate(PassportDto dto)
        {
            var (number, series, issuedBy, residence) = dto;

            var validateNumberResult = ValidateNumber(number);
            if (validateNumberResult.Failure)
                return validateNumberResult;

            var validateSeriesResult = ValidateSeries(series);
            if (validateSeriesResult.Failure)
                return validateSeriesResult;

            if (string.IsNullOrEmpty(issuedBy))
                return new Result(false, "Issued by was empty");
            
            if (string.IsNullOrEmpty(residence))
                return new Result(false, "Residence was empty");

            return new Result(true);
        }

        private Result ValidateNumber(string number)
        {
            var charArrayNumber = number.ToCharArray();
            
            if (!charArrayNumber.All(char.IsDigit))
                return new Result(false, "Passport number contained non-digit symbol");

            if (charArrayNumber.Length != 6)
                return new Result(false, "Passport number length was not correct");

            return new Result(true);
        }

        private Result ValidateSeries(string number)
        {
            var charArraySeries = number.ToCharArray();
            
            if (!charArraySeries.All(char.IsDigit))
                return new Result(false, "Passport series contained non-digit symbol");

            if (charArraySeries.Length != 4)
                return new Result(false, "Passport series length was not correct");

            return new Result(true);
        }
    }
}