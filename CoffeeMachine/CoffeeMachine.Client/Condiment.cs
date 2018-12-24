using System;

namespace CoffeeMachine.Client
{
    public class Condiment
    {
        public Condiment(decimal _price = 0)
        {
            price = _price;
        }

        public int Quantity { get; set; }

        private decimal price;
        public decimal Price
        {
            get { return price; }
        }

        public int GetQuantity(string quantityText)
        {
            int quantity = 0;

            int.TryParse(quantityText, out quantity);

            return quantity;
        }

        public bool IsValidQuantity(string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int quantity = 0;

                int.TryParse(text, out quantity);

                if (quantity > 0 && quantity < 4)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
