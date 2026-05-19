using System;
using System.Collections.Generic;

namespace BankEmulator.Domain
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        
        public List<Account> Accounts { get; private set; } 

        public Client(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
        
        public Client(Guid id, string name)
        {
            Id = id;
            Name = name;
            Accounts = new List<Account>();
        }

        
    }
}