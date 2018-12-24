using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Client
{
    public class Order
    {
        public Order()
        {
            if (Coffees == null)
            {
                Coffees = new List<Coffee>();
            }

            if (Payments == null)
            {
                Payments = new List<Payment>();
            }
        }

        public List<Coffee> Coffees { get; set; }
        public List<Payment> Payments { get; set; }

        public decimal Total
        {
            get { return CalculateTotal(this.Coffees); }
        }

        public decimal SumOfPayments
        {
            get { return CalculateSumOfPayments(this.Payments); }
        }

        public decimal CalculateTotal(List<Coffee> coffees)
        {
            decimal runningTotal = 0m;

            foreach (var coffee in coffees)
            {
                runningTotal += coffee.Price;
            }

            return runningTotal;
        }

        public decimal CalculateSumOfPayments(List<Payment> payments)
        {
            decimal sum = 0m;

            foreach (var payment in payments)
            {
                sum += payment.Amount;
            }

            return sum;
        }
    }
}
