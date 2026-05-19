using System;

namespace BankEmulator.Domain
{
    public class LoggerObserver : IAccountObserver
    {
        public void Update(string accountNumber, decimal newBalance, string message)
        {
            Console.WriteLine($"[УВЕДОМЛЕНИЕ] Счет: {accountNumber} | {message} | Текущий баланс: {newBalance}");
        }
    }
}