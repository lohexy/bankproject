using System;

namespace BankEmulator.Domain
{
    // Перечисление типов транзакций
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    public class Transaction
    {
        public Guid Id { get; private set; } 
        public decimal Amount { get; private set; } 
        public DateTime Date { get; private set; } 
        public TransactionType Type { get; private set; } 

        public Transaction(decimal amount, TransactionType type)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Date = DateTime.Now;
            Type = type;
        }

        public Transaction(Guid id, decimal amount, TransactionType type, DateTime date)
        {
            Id = id;
            Amount = amount;
            Type = type;
            Date = date;
        }
    }
}