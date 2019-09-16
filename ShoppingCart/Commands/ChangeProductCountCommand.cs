using System.Linq;
using ShoppingCart.Models;

namespace ShoppingCart.Commands
{
    public class ChangeProductCountCommand : ICommand
    {
        private readonly int _count;
        private readonly ProductModel _product;
        private int _lastCount;

        public ChangeProductCountCommand(ProductModel product, int count)
        {
            _product = product;
            _lastCount = product.Count;
            _count = count;
        }

        public void Do(ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                _lastCount = existingProduct.Count;
                existingProduct.Count = _count;
            }
        }

        public void Undo(ShoppingCartModel cart)
        {
            var existingProduct = cart.Products.FirstOrDefault(p => p.Id == _product.Id);
            if (existingProduct != null)
            {
                existingProduct.Count = _lastCount;
            }
        }
    }
}