using CoffeeMachine.Client;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.UnitTests
{
    [TestFixture]
    public class CoffeeTests
    {
        Coffee _coffee;

        [SetUp]
        public void TestSetup()
        {
            _coffee = new Coffee();
        }

        [Test, TestCaseSource(typeof(CoffeeTestDatas), "Pricing")]
        public decimal GetPrice(CoffeeSize size, Cream cream, Sugar sugar)
        {
            // Arrange

            // Act
            var result = _coffee.GetPrice(size, cream, sugar);

            // Assert
            return result;
        }

        [TestCase(CoffeeSize.Small, ExpectedResult = 1.75)]
        [TestCase(CoffeeSize.Medium, ExpectedResult = 2.00)]
        [TestCase(CoffeeSize.Large, ExpectedResult = 2.25)]
        public decimal GetBasePrice(CoffeeSize size)
        {
            // Arrange

            // Act
            var result = _coffee.GetBasePrice(size);

            // Assert
            return result;
        }

        [Test, TestCaseSource(typeof(CoffeeTestDatas), "SizeTexts")]
        public CoffeeSize? GetSize(string sizeText)
        {
            // Arrange

            // Act
            var result = _coffee.GetSize(sizeText);

            // Assert
            return result;
        }

        [Test, TestCaseSource(typeof(CoffeeTestDatas), "SizeTexts2")]
        public bool IsValidSize(string sizeText)
        {
            // Arrange

            // Act
            var result = _coffee.IsValidSize(sizeText);

            // Assert
            return result;
        }
    }
    public class CoffeeTestDatas
    {
        public static IEnumerable Pricing
        {
            get
            {
                yield return new TestCaseData(CoffeeSize.Small, null, null).Returns(1.75);
                yield return new TestCaseData(CoffeeSize.Small, new Cream() { Quantity = 1 }, null).Returns(2.25);
                yield return new TestCaseData(CoffeeSize.Small, new Cream() { Quantity = 2 }, null).Returns(2.75);
                yield return new TestCaseData(CoffeeSize.Small, new Cream() { Quantity = 3 }, null).Returns(3.25);
                yield return new TestCaseData(CoffeeSize.Small, null, new Sugar() { Quantity = 1 }).Returns(2);
                yield return new TestCaseData(CoffeeSize.Small, null, new Sugar() { Quantity = 2 }).Returns(2.25);
                yield return new TestCaseData(CoffeeSize.Small, null, new Sugar() { Quantity = 3 }).Returns(2.50);
                yield return new TestCaseData(CoffeeSize.Small, new Cream() { Quantity = 1 }, new Sugar() { Quantity = 1 }).Returns(2.50);
                yield return new TestCaseData(CoffeeSize.Small, new Cream() { Quantity = 2 }, new Sugar() { Quantity = 2 }).Returns(3.25);
                yield return new TestCaseData(CoffeeSize.Small, new Cream() { Quantity = 3 }, new Sugar() { Quantity = 3 }).Returns(4);

                yield return new TestCaseData(CoffeeSize.Medium, null, null).Returns(2);
                yield return new TestCaseData(CoffeeSize.Medium, new Cream() { Quantity = 1 }, null).Returns(2.50);
                yield return new TestCaseData(CoffeeSize.Medium, new Cream() { Quantity = 2 }, null).Returns(3);
                yield return new TestCaseData(CoffeeSize.Medium, new Cream() { Quantity = 3 }, null).Returns(3.50);
                yield return new TestCaseData(CoffeeSize.Medium, null, new Sugar() { Quantity = 1 }).Returns(2.25);
                yield return new TestCaseData(CoffeeSize.Medium, null, new Sugar() { Quantity = 2 }).Returns(2.50);
                yield return new TestCaseData(CoffeeSize.Medium, null, new Sugar() { Quantity = 3 }).Returns(2.75);
                yield return new TestCaseData(CoffeeSize.Medium, new Cream() { Quantity = 1 }, new Sugar() { Quantity = 1 }).Returns(2.75);
                yield return new TestCaseData(CoffeeSize.Medium, new Cream() { Quantity = 2 }, new Sugar() { Quantity = 2 }).Returns(3.50);
                yield return new TestCaseData(CoffeeSize.Medium, new Cream() { Quantity = 3 }, new Sugar() { Quantity = 3 }).Returns(4.25);

                yield return new TestCaseData(CoffeeSize.Large, null, null).Returns(2.25);
                yield return new TestCaseData(CoffeeSize.Large, new Cream() { Quantity = 1 }, null).Returns(2.75);
                yield return new TestCaseData(CoffeeSize.Large, new Cream() { Quantity = 2 }, null).Returns(3.25);
                yield return new TestCaseData(CoffeeSize.Large, new Cream() { Quantity = 3 }, null).Returns(3.75);
                yield return new TestCaseData(CoffeeSize.Large, null, new Sugar() { Quantity = 1 }).Returns(2.50);
                yield return new TestCaseData(CoffeeSize.Large, null, new Sugar() { Quantity = 2 }).Returns(2.75);
                yield return new TestCaseData(CoffeeSize.Large, null, new Sugar() { Quantity = 3 }).Returns(3);
                yield return new TestCaseData(CoffeeSize.Large, new Cream() { Quantity = 1 }, new Sugar() { Quantity = 1 }).Returns(3);
                yield return new TestCaseData(CoffeeSize.Large, new Cream() { Quantity = 2 }, new Sugar() { Quantity = 2 }).Returns(3.75);
                yield return new TestCaseData(CoffeeSize.Large, new Cream() { Quantity = 3 }, new Sugar() { Quantity = 3 }).Returns(4.5);

            }
        }

        public static IEnumerable SizeTexts
        {
            get
            {
                yield return new TestCaseData("Small").Returns(CoffeeSize.Small);
                yield return new TestCaseData("small").Returns(CoffeeSize.Small);
                yield return new TestCaseData(" small").Returns(CoffeeSize.Small);
                yield return new TestCaseData("smalls").Returns(null);
                yield return new TestCaseData("sm").Returns(null);

                yield return new TestCaseData("Medium").Returns(CoffeeSize.Medium);
                yield return new TestCaseData("medium").Returns(CoffeeSize.Medium);
                yield return new TestCaseData("medium ").Returns(CoffeeSize.Medium);
                yield return new TestCaseData("med").Returns(null);

                yield return new TestCaseData("Large").Returns(CoffeeSize.Large);
                yield return new TestCaseData("large").Returns(CoffeeSize.Large);
                yield return new TestCaseData(" large ").Returns(CoffeeSize.Large);
                yield return new TestCaseData("lg").Returns(null);

                yield return new TestCaseData("").Returns(null);
                yield return new TestCaseData(" ").Returns(null);
                yield return new TestCaseData(string.Empty).Returns(null);
                yield return new TestCaseData(null).Returns(null);

            }
        }

        public static IEnumerable SizeTexts2
        {
            get
            {
                yield return new TestCaseData("Small").Returns(true);
                yield return new TestCaseData("small").Returns(true);
                yield return new TestCaseData(" small").Returns(true);
                yield return new TestCaseData("smalls").Returns(false);
                yield return new TestCaseData("sm").Returns(false);

                yield return new TestCaseData("Medium").Returns(true);
                yield return new TestCaseData("medium").Returns(true);
                yield return new TestCaseData("medium ").Returns(true);
                yield return new TestCaseData("med").Returns(false);

                yield return new TestCaseData("Large").Returns(true);
                yield return new TestCaseData("large").Returns(true);
                yield return new TestCaseData(" large ").Returns(true);
                yield return new TestCaseData("lg").Returns(false);

                yield return new TestCaseData("").Returns(false);
                yield return new TestCaseData(" ").Returns(false);
                yield return new TestCaseData(string.Empty).Returns(false);
                yield return new TestCaseData(null).Returns(false);

            }
        }
    }
}
