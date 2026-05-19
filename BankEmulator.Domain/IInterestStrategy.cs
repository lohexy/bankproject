namespace BankEmulator.Domain
{
    public interface IInterestStrategy
    {
        decimal CalculateInterest(decimal balance, int months);
    }
}