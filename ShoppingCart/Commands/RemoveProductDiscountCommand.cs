using System.Linq;
using ShoppingCart.Models;

namespace ShoppingCart.Commands
{
    public class RemoveProductDiscountCommand : ICommand
    {
        private readonly ProductModel _product;
        private DiscountModel _lastDiscount;

        public RemoveProductDiscountCommand(ProductModel product)
        {
            _product = product;
        }
        
        public void Do(ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                _lastDiscount = existingProduct.Discount;
                existingProduct.Discount = null;
            }
        }

        public void Undo(ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                existingProduct.Discount = _lastDiscount;
            }
        }
    }
}