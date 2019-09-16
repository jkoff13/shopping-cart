using ShoppingCart.Commands;
using ShoppingCart.Helpers;
using ShoppingCart.Models;

namespace ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly UndoRedoStack _undoRedoStack;
        
        public ShoppingCartService()
        {
            _undoRedoStack = new UndoRedoStack();
        }

        public void AddProduct(ProductModel product)
        {
            _undoRedoStack.Do(new AddProductCommand(product));
        }

        public void AddProductDiscount(ProductModel product, DiscountModel discount)
        {
            _undoRedoStack.Do(new AddProductDiscountCommand(product, discount));
        }

        public void AddDiscount(DiscountModel discount)
        {
            _undoRedoStack.Do(new AddDiscountCommand(discount));
        }

        public void RemoveDiscount()
        {
            _undoRedoStack.Do(new RemoveDiscountCommand());
        }

        public void RemoveProductDiscount(ProductModel product)
        {
            _undoRedoStack.Do(new RemoveProductDiscountCommand(product));
        }

        public void RemoveProduct(ProductModel product)
        {
            _undoRedoStack.Do(new RemoveProductCommand(product));
        }

        public void ChangeProductCountCommand(ProductModel product, int count)
        {
            _undoRedoStack.Do(new ChangeProductCountCommand(product, count));
        }

        public void Undo()
        {
            _undoRedoStack.Undo();
        }

        public void Redo()
        {
            _undoRedoStack.Redo();
        }

        public ShoppingCartModel GetShoppingCart()
        {
            return _undoRedoStack.GetCart();
        }

        public string GetReceipt()
        {
            var shoppingCart = _undoRedoStack.GetCart();
            return ReceiptHelper.Generate(shoppingCart);
        }
    }
}