using Xunit;
using BankEmulator.Domain;

namespace BankEmulator.Tests
{
    public class InterestStrategiesTests
    {
        [Theory]
        [InlineData(10000, 12, 1000)]
        [InlineData(5000, 6, 250)]
        [InlineData(0, 12, 0)]
        [InlineData(120000, 1, 1000)]
        [InlineData(1000, 24, 200)]
        [InlineData(50000, 3, 1250)]
        public void DepositStrategy_CalculateInterest_ReturnsCorrectAmount(decimal amount, int months, decimal expectedInterest)
        {
            IInterestStrategy strategy = new DepositStrategy();

            decimal actualInterest = strategy.CalculateInterest(amount, months);

            Assert.Equal(expectedInterest, actualInterest);
        }

        [Theory]
        [InlineData(20000, 12, 5000)]
        [InlineData(10000, 6, 1250)]
        [InlineData(0, 12, 0)]
        [InlineData(40000, 24, 20000)]
        [InlineData(12000, 1, 250)]
        [InlineData(80000, 3, 5000)]
        public void CreditStrategy_CalculateInterest_ReturnsCorrectAmount(decimal amount, int months, decimal expectedInterest)
        {
            IInterestStrategy strategy = new CreditStrategy();

            decimal actualInterest = strategy.CalculateInterest(amount, months);

            Assert.Equal(expectedInterest, actualInterest);
        }
    }
}   