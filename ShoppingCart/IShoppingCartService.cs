using ShoppingCart.Models;

namespace ShoppingCart
{
    public interface IShoppingCartService
    {
        void AddProduct(ProductModel product);
        void AddProductDiscount(ProductModel product, DiscountModel discount);
        void AddDiscount(DiscountModel discount);
        void RemoveDiscount();
        void RemoveProductDiscount(ProductModel product);
        void RemoveProduct(ProductModel product);
        void ChangeProductCountCommand(ProductModel product, int count);
        void Undo();
        void Redo();
        ShoppingCartModel GetShoppingCart();
        string GetReceipt();
    }
}