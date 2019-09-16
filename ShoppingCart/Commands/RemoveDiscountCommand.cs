using ShoppingCart.Models;

namespace ShoppingCart.Commands
{
    public class RemoveDiscountCommand : ICommand
    {
        private DiscountModel _lastDiscount;

        public void Do(ShoppingCartModel cart)
        {
            _lastDiscount = cart.Discount;
            cart.Discount = null;
        }

        public void Undo(ShoppingCartModel cart)
        {
            cart.Discount = _lastDiscount;
        }
    }
}