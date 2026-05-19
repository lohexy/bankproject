using System;

namespace BankEmulator.Domain
{
    public class StandardAccount : Account
    {
        public StandardAccount(string accountNumber, decimal initialBalance, IInterestStrategy strategy) 
            : base(accountNumber, initialBalance, strategy) { }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0) 
                throw new ArgumentException("Сумма должна быть больше нуля.");
            
            if (Balance < amount) 
                throw new InvalidOperationException("Недостаточно средств на счету.");

            Balance -= amount;
            TransactionHistory.Add(new Transaction(amount, TransactionType.Withdrawal));

            NotifyObservers($"Снятие {amount} успешно выполнено.");
        }
    }
}