using System.Linq;
using ShoppingCart.Models;

namespace ShoppingCart.Commands
{
    public class AddProductDiscountCommand : ICommand
    {
        private readonly ProductModel _product;
        private readonly DiscountModel _discount;
        private DiscountModel _lastDiscount;

        public AddProductDiscountCommand(ProductModel product, DiscountModel discount)
        {
            _product = product;
            _discount = discount;
        }
        
        public void Do(ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                _lastDiscount = existingProduct.Discount;
                existingProduct.Discount = _discount;
            }
        }

        public void Undo(Models.ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                existingProduct.Discount = _lastDiscount;
            }
        }
    }
}