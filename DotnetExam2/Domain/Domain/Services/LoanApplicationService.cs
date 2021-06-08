using System.Runtime.CompilerServices;
using Core.Entities;
using Core.ValueObjects;

namespace Core.Services
{
    public static class LoanApplicationService
    {
        public static Answer GetAnswer(LoanApplication loanApplication)
        {
            var points = GetPoints(loanApplication);
            var percentageRate = GetPercentageRate(points);
            var answer = new Answer(points, percentageRate, loanApplication);

            return answer;
        }
        
        private static int GetPoints(LoanApplication loanApplication)
        {
            var totalPoints = 0;

            totalPoints += loanApplication.Age.PointsStrategy.Calculate(loanApplication);
            totalPoints += loanApplication.CriminalRecord.HasNote ? 15 : 0;
            totalPoints += loanApplication.Job.Type switch
            {
                JobType.None => 0,
                JobType.Contract => 14,
                JobType.SelfEmployed => 12,
                JobType.Freelance => 8,
                JobType.Retiree => loanApplication.Age.Value < 70 ? 5 : 0
            };
            totalPoints += loanApplication.Purpose.Type switch
            {
                PurposeType.ConsumerLoan => 14,
                PurposeType.Realty => 8,
                PurposeType.ReCrediting => 12
            };
            totalPoints += loanApplication.Deposit.Type switch
            {
                DepositType.None => 0,
                DepositType.Realty => 14,
                DepositType.Car => 8,
                DepositType.Surety => 12
            };
            totalPoints += !loanApplication.OtherCredits.Has && 
                loanApplication.Purpose.Type is PurposeType.ConsumerLoan or PurposeType.Realty
                ? 15
                : 0;
            totalPoints += loanApplication.LoanAmount.Value switch
            {
                <= 1000000 => 12,
                <= 5000000 => 14,
                <= 10000000 => 8
            };
            
            return totalPoints;
        }

        private static double GetPercentageRate(int points)
        {
            return points switch
            {
                < 80 => 30,
                < 84 => 26,
                < 88 => 22,
                < 92 => 19,
                < 96 => 15,
                < 100 => 12.5
            };
        }
    }
}