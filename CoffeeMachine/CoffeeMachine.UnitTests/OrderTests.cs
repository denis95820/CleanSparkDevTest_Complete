using System;
using NUnit.Framework;
using CoffeeMachine.Client;
using System.Collections.Generic;
using System.Collections;

namespace CoffeeMachine.UnitTests
{
    [TestFixture]
    public class OrderTests
    {
        Order _order;

       [SetUp]
        public void TestSetup()
        {
            _order = new Order();
        }

        [TestCase(CoffeeSize.Small, ExpectedResult = 1.75)]
        [TestCase(CoffeeSize.Medium, ExpectedResult = 2.0)]
        [TestCase(CoffeeSize.Large, ExpectedResult = 2.25)]
        public decimal CalculateTotal_SingleCoffee(CoffeeSize size)
        {
            // Arrange
            Coffee coffee = new Coffee() { Size = size };
            List<Coffee> list = new List<Coffee>();
            list.Add(coffee);

            // Act
            var result = _order.CalculateTotal(list);

            // Assert
            return result;
        }

        [Test, TestCaseSource(typeof(MultipleCoffeeData), "MultipleCoffees")]
        public decimal CalculateTotal_MultipleCoffee(List<Coffee> coffees)
        {
            // Arrange

            // Act
            var result = _order.CalculateTotal(coffees);

            // Assert
            return result;
        }

        [Test, TestCaseSource(typeof(MultiplePaymentData), "MultiplePayments")]
        public decimal CalculateSumOfPayments(List<Payment> payments)
        {
            // Arrange

            // Act
            var result = _order.CalculateSumOfPayments(payments);

            // Assert
            return result;
        }


        [TearDown]
        public void TestTearDown()
        {
            _order = null;
        }

        public class MultipleCoffeeData
        {
            public static IEnumerable MultipleCoffees
            {
                get
                {
                    yield return new TestCaseData(new List<Coffee>() ).Returns(0);

                    yield return new TestCaseData(new List<Coffee>() { new Coffee() { Size = CoffeeSize.Large }
                                                                     }).Returns(2.25);

                    yield return new TestCaseData(new List<Coffee>() { new Coffee() { Size = CoffeeSize.Small },
                                                                       new Coffee() { Size = CoffeeSize.Small }
                                                                     }).Returns(3.5);

                    yield return new TestCaseData(new List<Coffee>() { new Coffee() { Size = CoffeeSize.Small },
                                                                       new Coffee() { Size = CoffeeSize.Medium },
                                                                       new Coffee() { Size = CoffeeSize.Large }
                                                                     }).Returns(6);

                    yield return new TestCaseData(new List<Coffee>() { new Coffee() { Size = CoffeeSize.Small, Cream = new Cream() { Quantity = 1 } }
                                                                     }).Returns(2.25);

                    yield return new TestCaseData(new List<Coffee>() { new Coffee() { Size = CoffeeSize.Medium, Cream = new Cream() { Quantity = 1 }, Sugar = new Sugar() { Quantity = 1 } }
                                                                     }).Returns(2.75);

                    yield return new TestCaseData(new List<Coffee>() { new Coffee() { Size = CoffeeSize.Large, Cream = new Cream() { Quantity = 2 }, Sugar = new Sugar() { Quantity = 3 } }
                                                                     }).Returns(4);

                }
            }
        }

        public class MultiplePaymentData
        {
            static List<Payment> localList1 = new List<Payment>();
            static List<Payment> localList2 = new List<Payment>();
            static List<Payment> localList3 = new List<Payment>();

            static Payment small = new Payment() { Amount = .75m };
            static Payment medium = new Payment() { Amount = 5m };
            static Payment large = new Payment() { Amount = 20m };

            public static IEnumerable MultiplePayments
            {
                get
                {
                    localList1.Add(small);
                    localList1.Add(small);

                    yield return new TestCaseData(localList1).Returns(1.5m);

                    localList2.Add(medium);
                    localList2.Add(medium);

                    yield return new TestCaseData(localList2).Returns(10m);



                    yield return new TestCaseData(new List<Payment> { new Payment() { Amount = 1 } }).Returns(1);
                    yield return new TestCaseData(new List<Payment> { new Payment() { Amount = 1 }, new Payment() { Amount = 2 } }).Returns(3);
                    yield return new TestCaseData(new List<Payment> { new Payment() { Amount = 1 }, new Payment() { Amount = 2 }, new Payment() { Amount = 3 } }).Returns(6);

                }
            }
        }

    }
}
