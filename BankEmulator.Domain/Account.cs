using System;
using System.Collections.Generic;

namespace BankEmulator.Domain
{
    public abstract class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; protected set; } 
        public List<Transaction> TransactionHistory { get; private set; }
        public IInterestStrategy InterestStrategy { get; set; }

        private readonly List<IAccountObserver> _observers = new List<IAccountObserver>();

        public void Attach(IAccountObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IAccountObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(AccountNumber, Balance, message);
            }
        }

        public Account(string accountNumber, decimal initialBalance, IInterestStrategy strategy)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            TransactionHistory = new List<Transaction>();
            InterestStrategy = strategy;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма должна быть больше нуля");
            
            Balance += amount;
            TransactionHistory.Add(new Transaction(amount, TransactionType.Deposit));
            
            NotifyObservers($"Счет пополнен на {amount}");
        }

        public abstract void Withdraw(decimal amount);

        public decimal CalculateFutureInterest(int months)
        {
            if (InterestStrategy == null) return 0;
            return InterestStrategy.CalculateInterest(Balance, months);
        }
    }
}