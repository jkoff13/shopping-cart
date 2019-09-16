using System;

namespace ShoppingCart.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public DiscountModel Discount { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount => (Price * (1 - Discount?.Percents) ?? Price) * Count;
    }
}