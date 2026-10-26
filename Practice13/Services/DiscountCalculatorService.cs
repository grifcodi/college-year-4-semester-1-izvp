using System;
using System.Collections.Generic;
using System.Text;

namespace Practice13.Services
{
    internal class DiscountCalculatorService
    {
        public decimal CalculateFinalPrice(decimal amount, decimal discountPercentage)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сума покупки не може бути від’ємною.");
            }

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Знижка має бути в межах від 0% до 100%.");
            }

            return amount * (1m - (discountPercentage / 100m));
        }
    }
}
