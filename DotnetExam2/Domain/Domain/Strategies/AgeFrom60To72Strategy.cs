using Core.Entities;
using Core.ValueObjects;

namespace Core.Strategies
{
    public class AgeFrom60To72Strategy : IAgePointsStrategy
    {
        public int Calculate(LoanApplication loanApplication)
        {
            return loanApplication.Deposit.Type == DepositType.None ? 0 : 8;
        }
    }
}