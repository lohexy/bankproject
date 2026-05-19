using System.Collections.Generic;

namespace BankEmulator.App.DTO
{
    public class AccountDto
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
    }
}