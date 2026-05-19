using System;
using System.Collections.Generic;

namespace BankEmulator.App.DTO
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<AccountDto> Accounts { get; set; } = new List<AccountDto>();
    }
}