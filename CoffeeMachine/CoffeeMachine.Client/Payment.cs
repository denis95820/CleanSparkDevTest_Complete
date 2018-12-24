using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Client
{
    public class Payment
    {
        public decimal Amount { get; set; }

        public decimal GetAmount(string amountText)
        {
            decimal amount = 0;

            decimal.TryParse(amountText, out amount);

            return amount;
        }

        public bool IsValidAmount(string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                decimal amount = 0;

                decimal.TryParse(text, out amount);

                if (amount >= 0.05m && amount <= 20m)
                {
                    if (amount % 5 == 0 || amount % .05m == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
