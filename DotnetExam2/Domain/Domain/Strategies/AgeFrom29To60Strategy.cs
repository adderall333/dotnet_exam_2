using Core.Entities;

namespace Core.Strategies
{
    public class AgeFrom29To60Strategy : IAgePointsStrategy
    {
        public int Calculate(LoanApplication loanApplication)
        {
            return 14;
        }
    }
}