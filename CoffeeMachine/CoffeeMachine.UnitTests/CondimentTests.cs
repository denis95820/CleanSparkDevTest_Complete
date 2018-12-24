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
    public class CondimentTests
    {
        Condiment condiment;

        [SetUp]
        public void TestSetup()
        {
            condiment = new Condiment();
        }

        [TestCase("10", ExpectedResult = 10)]
        [TestCase(" 10", ExpectedResult = 10)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(" ", ExpectedResult = 0)]
        [TestCase("5", ExpectedResult = 5)]
        [TestCase("10000", ExpectedResult = 10000)]
        public int GetQuantity(string quantityText)
        {
            // Arrange

            // Act
            var result = condiment.GetQuantity(quantityText);

            // Assert
            return result;
        }

        [TestCase(" ", ExpectedResult = false)]
        [TestCase("0", ExpectedResult = false)]
        [TestCase("4", ExpectedResult = false)]
        [TestCase(" .05", ExpectedResult = false)]
        [TestCase("0.05", ExpectedResult = false)]
        [TestCase("0.10", ExpectedResult = false)]
        [TestCase("1", ExpectedResult = true)]
        [TestCase("2", ExpectedResult = true)]
        [TestCase("5", ExpectedResult = false)]
        [TestCase("20", ExpectedResult = false)]
        [TestCase("21", ExpectedResult = false)]
        [TestCase(".005", ExpectedResult = false)]
        [TestCase("0.51", ExpectedResult = false)]
        [TestCase("1.11", ExpectedResult = false)]
        [TestCase("10", ExpectedResult = false)]
        public bool IsValidQuantity(string text)
        {
            // Arrange

            // Act
            var result = condiment.IsValidQuantity(text);

            // Assert
            return result;
        }

    }
}
