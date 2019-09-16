using ShoppingCart.Models;

namespace ShoppingCart.Commands
{
    public class AddDiscountCommand : ICommand
    {
        private readonly DiscountModel _discount;
        private DiscountModel _lastDiscount;

        public AddDiscountCommand(DiscountModel discount)
        {
            _discount = discount;
        }

        public void Do(ShoppingCartModel cart)
        {
            _lastDiscount = cart.Discount;
            cart.Discount = _discount;
        }

        public void Undo(ShoppingCartModel cart)
        {
            cart.Discount = _lastDiscount;
        }
    }
}