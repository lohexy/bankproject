using System;
using BankEmulator.Domain;

namespace BankEmulator.App.DTO
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
    }
}