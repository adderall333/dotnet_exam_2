namespace Core.Entities
{
    public class Answer
    {
        public Answer(int points, double percentageRate, LoanApplication loanApplication)
        {
            IsApproved = points >= 80;
            Points = points;
            PercentageRate = percentageRate;
            LoanApplication = loanApplication;
        }

        public int Id { get; private set; }
        
        public bool IsApproved { get; private set; }
        
        public int Points { get; private set; }
        
        public double PercentageRate { get; private set; }
        
        public LoanApplication LoanApplication { get; private set; }
        public int LoanApplicationId { get; private set; }
    }
}