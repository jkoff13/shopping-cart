using ShoppingCart.Models;

namespace ShoppingCart.Commands
{
    public interface ICommand
    {
        void Do(ShoppingCartModel cart);
        void Undo(ShoppingCartModel cart);
    }
}