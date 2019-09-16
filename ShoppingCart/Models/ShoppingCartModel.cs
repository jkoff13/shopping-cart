using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class ShoppingCartModel
    {
        public ICollection<ProductModel> Products { get; set; }
        public DiscountModel Discount { get; set; }

        public ShoppingCartModel()
        {
            Products = new List<ProductModel>();
        }

        public decimal GetTotalAmount()
        {
            var totalProductAmount = Products.Sum(p => p.TotalAmount);
            if (Discount == null) 
            {
                return totalProductAmount;
            }

            return totalProductAmount * (1 - Discount.Percents);
        }
    }
}