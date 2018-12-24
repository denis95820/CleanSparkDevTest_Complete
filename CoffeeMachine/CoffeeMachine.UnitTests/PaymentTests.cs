using CoffeeMachine.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.UnitTests
{
    [TestFixture]
    public class PaymentTests
    {
        Payment _payment;

        [SetUp]
        public void TestSetup()
        {
            _payment = new Payment();
        }

        [TestCase("10", ExpectedResult = 10)]
        [TestCase(" 10", ExpectedResult = 10)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(" ", ExpectedResult = 0)]
        [TestCase("5", ExpectedResult = 5)]
        [TestCase("10000", ExpectedResult = 10000)]
        public decimal GetAmount(string amountText)
        {
            // Arrange

            // Act
            var result = _payment.GetAmount(amountText);

            // Assert
            return result;
        }

        [TestCase(" ", ExpectedResult = false)]
        [TestCase(" .05", ExpectedResult = true)]
        [TestCase("0.05", ExpectedResult = true)]
        [TestCase("0.10", ExpectedResult = true)]
        [TestCase("1", ExpectedResult = true)]
        [TestCase("2", ExpectedResult = true)]
        [TestCase("5", ExpectedResult = true)]
        [TestCase("20", ExpectedResult = true)]
        [TestCase("21", ExpectedResult = false)]
        [TestCase(".005", ExpectedResult = false)]
        [TestCase("0.51", ExpectedResult = false)]
        [TestCase("1.11", ExpectedResult = false)]
        [TestCase("10", ExpectedResult = true)]
        public bool ValidateAmount(string text)
        {
            // Arrange

            // Act
            var result = _payment.IsValidAmount(text);

            // Assert
            return result;
        }
    }
}
