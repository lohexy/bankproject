namespace BankEmulator.Domain
{
    public interface IAccountObserver
    {
        void Update(string accountNumber, decimal newBalance, string message);
    }
}