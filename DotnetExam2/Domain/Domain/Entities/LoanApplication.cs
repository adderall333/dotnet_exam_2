using Core.Infrastructure;
using Core.ValueObjects;

namespace Core.Entities
{
    public class LoanApplication
    {
        public int Id { get; private set; }
        public FullName FullName { get; private set; }
        
        public Passport Passport { get; private set; }
        
        public Age Age { get; private set; }
        
        public LoanAmount LoanAmount { get; private set; }
        
        public Purpose Purpose { get; private set; }
        
        public Job Job { get; private set; }
        
        public Deposit Deposit { get; private set; }
        
        public CriminalRecord CriminalRecord { get; private set; }
        
        public OtherCredits OtherCredits { get; private set; }

        public static Result<LoanApplication> Create(
            FullNameDto fullNameDto,
            PassportDto passportDto,
            AgeDto ageDto,
            LoanAmountDto loanAmountDto,
            PurposeDto purposeDto,
            JobDto jobDto,
            DepositDto depositDto,
            CriminalRecordDto criminalRecordDto,
            OtherCreditsDto otherCreditsDto)
        {
            var fullNameResult = FullName.Create(fullNameDto);
            if (fullNameResult.Failure)
                return new Result<LoanApplication>(null, false, fullNameResult.Error);

            var passportResult = Passport.Create(passportDto);
            if (passportResult.Failure)
                return new Result<LoanApplication>(null, false, passportResult.Error);

            var ageResult = Age.Create(ageDto);
            if (ageResult.Failure)
                return new Result<LoanApplication>(null, false, ageResult.Error);

            var loanAmountResult = LoanAmount.Create(loanAmountDto);
            if (loanAmountResult.Failure)
                return new Result<LoanApplication>(null, false, loanAmountResult.Error);
            
            var purposeResult = Purpose.Create(purposeDto);
            if (purposeResult.Failure)
                return new Result<LoanApplication>(null, false, purposeResult.Error);
            
            var jobResult = Job.Create(jobDto);
            if (jobResult.Failure)
                return new Result<LoanApplication>(null, false, jobResult.Error);
            
            var depositResult = Deposit.Create(depositDto);
            if (depositResult.Failure)
                return new Result<LoanApplication>(null, false, depositResult.Error);
            
            var criminalRecordResult = CriminalRecord.Create(criminalRecordDto);
            if (criminalRecordResult.Failure)
                return new Result<LoanApplication>(null, false, criminalRecordResult.Error);
            
            var otherCreditsResult = OtherCredits.Create(otherCreditsDto);
            if (otherCreditsResult.Failure)
                return new Result<LoanApplication>(null, false, otherCreditsResult.Error);

            var loanApplication = new LoanApplication
            {
                FullName = fullNameResult.Value,
                Passport = passportResult.Value,
                Age = ageResult.Value,
                LoanAmount = loanAmountResult.Value,
                Purpose = purposeResult.Value,
                Job = jobResult.Value,
                Deposit = depositResult.Value,
                CriminalRecord = criminalRecordResult.Value,
                OtherCredits = otherCreditsResult.Value
            };

            return new Result<LoanApplication>(loanApplication, true);
        }
        
        public Answer Answer { get; private set; }
        public int AnswerId { get; private set; }
        
        private LoanApplication(){}
    }
}