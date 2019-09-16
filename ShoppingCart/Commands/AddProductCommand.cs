using System.Linq;
using ShoppingCart.Models;

namespace ShoppingCart.Commands
{
    public class AddProductCommand : ICommand
    {
        private readonly ProductModel _product;

        public AddProductCommand(ProductModel product)
        {
            _product = product;
        }

        public void Do(ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                existingProduct.Count++;
                return;
            }

            _product.Count = 1;
            cart.Products.Add(_product);
        }

        public void Undo(ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                if (existingProduct.Count > 1)
                {
                    existingProduct.Count--;
                    return;
                }

                cart.Products.Remove(existingProduct);
            }
        }
    }
}