using Core.Entities;

namespace Core.Strategies
{
    public class AgeFrom21To28Strategy : IAgePointsStrategy
    {
        public int Calculate(LoanApplication loanApplication)
        {
            return loanApplication.LoanAmount.Value switch
            {
                < 1000000 => 12,
                <= 3000000 => 9,
                _ => 0
            };
        }
    }
}