using System;

namespace BankEmulator.Domain
{
    public class PremiumAccount : Account
    {
        public PremiumAccount(string accountNumber, decimal initialBalance, IInterestStrategy strategy) 
            : base(accountNumber, initialBalance, strategy) { }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0) 
                throw new ArgumentException("Сума має буть більше нуля.");
            
            Balance -= amount;
            TransactionHistory.Add(new Transaction(amount, TransactionType.Withdrawal));
            
            NotifyObservers($"Снятие {amount} виконано (Преміум).");
        }
    }
}