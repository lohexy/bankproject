namespace BankEmulator.Domain
{
    public class CreditStrategy : IInterestStrategy
    {
        private readonly decimal _annualRate = 0.25m;

        public decimal CalculateInterest(decimal balance, int months)
        {
            return (balance * _annualRate / 12) * months;
        }
    }
}