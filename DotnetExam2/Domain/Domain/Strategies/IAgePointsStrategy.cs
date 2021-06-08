using Core.Entities;

namespace Core.Strategies
{
    public interface IAgePointsStrategy
    {
        public int Calculate(LoanApplication loanApplication);
    }
}