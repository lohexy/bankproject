using System;
using System.Linq;
using Xunit;
using BankEmulator.Domain;

namespace BankEmulator.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Deposit_ValidAmount_IncreasesBalanceAndAddsTransaction()
        {
            var account = new StandardAccount("UA123", 1000, new DepositStrategy());
            decimal depositAmount = 500;

            account.Deposit(depositAmount);

            Assert.Equal(1500, account.Balance);
            Assert.Single(account.TransactionHistory);
            Assert.Equal(TransactionType.Deposit, account.TransactionHistory.First().Type);
        }

        [Fact]
        public void Deposit_AmountLessThanZero_ThrowsArgumentException()
        {
            var account = new StandardAccount("UA123", 1000, new DepositStrategy());

            var exception = Assert.Throws<ArgumentException>(() => account.Deposit(-50));
            Assert.Contains("Сумма должна быть больше нуля", exception.Message);
        }

        [Fact]
        public void Withdraw_ValidAmount_DecreasesBalanceAndAddsTransaction()
        {
            var account = new StandardAccount("UA123", 1000, new DepositStrategy());

            account.Withdraw(400);

            Assert.Equal(600, account.Balance);
            Assert.Equal(TransactionType.Withdrawal, account.TransactionHistory.First().Type);
        }
        [Fact]
        public void Withdraw_ExactBalanceAmount_ReducesBalanceToZero()
        {
            var account = new StandardAccount("UA123", 1000, new DepositStrategy());

            account.Withdraw(1000);

            Assert.Equal(0, account.Balance);
        }

        [Fact]
        public void Withdraw_InsufficientFunds_ThrowsInvalidOperationException()
        {
            var account = new StandardAccount("UA123", 1000, new DepositStrategy());

            Assert.Throws<InvalidOperationException>(() => account.Withdraw(1500));
        }

        [Fact]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            var account = new StandardAccount("UA123", 1000, new DepositStrategy());

            Assert.Throws<ArgumentException>(() => account.Withdraw(-100));
        }
    }
}