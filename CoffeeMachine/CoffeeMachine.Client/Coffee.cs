using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Client
{
    public enum CoffeeSize
    {
        Small,
        Medium,
        Large
    }

    public class Coffee
    {
        public CoffeeSize Size { get; set; }
        public Cream Cream { get; set; }
        public Sugar Sugar { get; set; }

        public decimal Price
        {
            get { return GetPrice(this.Size, this.Cream, this.Sugar); }
        }

        public decimal GetPrice(CoffeeSize size, Cream cream, Sugar sugar)
        {
            decimal price = 0m;

            price += GetBasePrice(size);

            if (cream != null)
            {
                price += cream.Price * cream.Quantity;
            }

            if (sugar != null)
            {
                price += sugar.Price * sugar.Quantity;
            }

            return price;
        }

        public decimal GetBasePrice(CoffeeSize size)
        {
            switch (size)
            {
                case CoffeeSize.Small:
                    return 1.75m;
                case CoffeeSize.Medium:
                    return 2.00m;
                case CoffeeSize.Large:
                    return 2.25m;
                default:
                    throw new Exception("New size has been added to system without a price in mind.");
            }
        }

        public CoffeeSize? GetSize(string sizeText)
        {
            if (!String.IsNullOrWhiteSpace(sizeText))
            {
                switch (sizeText?.ToLower().Trim())
                {
                    case "small":
                        return CoffeeSize.Small;
                    case "medium":
                        return CoffeeSize.Medium;
                    case "large":
                        return CoffeeSize.Large;
                    default:
                        return null;
                }
            }

            return null;
        }

        public bool IsValidSize(string sizeText)
        {
            if (!String.IsNullOrWhiteSpace(sizeText))
            {
                switch (sizeText?.ToLower().Trim())
                {
                    case "small":
                        return true;
                    case "medium":
                        return true;
                    case "large":
                        return true;
                    default:
                        return false;
                }
            }
            return false;
        }
    }
}
