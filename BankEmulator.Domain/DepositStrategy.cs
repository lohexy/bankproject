namespace BankEmulator.Domain
{
    public class DepositStrategy : IInterestStrategy
    {
        private readonly decimal _annualRate = 0.10m;

        public decimal CalculateInterest(decimal balance, int months)
    {
            return (balance * _annualRate / 12) * months;
        }
    }
}