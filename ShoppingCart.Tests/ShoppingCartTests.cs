using System;
using System.Linq;
using NUnit.Framework;
using ShoppingCart.Models;

namespace ShoppingCart.Tests
{
    public class ShoppingCartTests
    {
        private ShoppingCartService _shoppingCartService; 
        
        [SetUp]
        public void Setup()
        {
            _shoppingCartService = new ShoppingCartService();
        }

        [Test]
        public void AddTest()
        {
            var product1 = new ProductModel {Id = Guid.NewGuid(), Name = "product1", Price = 1m};
            var product2 = new ProductModel {Id = Guid.NewGuid(), Name = "product2", Price = 2m};

            var discount1 = new DiscountModel {Code = "discount1", Percents = 0.50m};
            var discount2 = new DiscountModel {Code = "discount2", Percents = 0.25m};

            _shoppingCartService.AddProduct(product1);
            _shoppingCartService.AddProduct(product2);

            _shoppingCartService.AddProductDiscount(product1, discount1);
            _shoppingCartService.AddProductDiscount(product2, discount2);

            var shoppingCart = _shoppingCartService.GetShoppingCart();

            Assert.AreEqual(shoppingCart.Products.ElementAt(0), product1);
            Assert.AreEqual(shoppingCart.Products.ElementAt(1), product2);

            Assert.AreEqual(shoppingCart.Products.ElementAt(0).Discount, discount1);
            Assert.AreEqual(shoppingCart.Products.ElementAt(1).Discount, discount2);
        }

        [Test]
        public void RemoveTest()
        {
            var product1 = new ProductModel {Id = Guid.NewGuid(), Name = "product1", Price = 1m};
            var product2 = new ProductModel {Id = Guid.NewGuid(), Name = "product2", Price = 2m};

            var discount1 = new DiscountModel {Code = "discount1", Percents = 0.50m};
            var discount2 = new DiscountModel {Code = "discount2", Percents = 0.25m};

            _shoppingCartService.AddProduct(product1);
            _shoppingCartService.AddProductDiscount(product1, discount1);

            var receipt1 = _shoppingCartService.GetReceipt();

            _shoppingCartService.AddProduct(product2);
            _shoppingCartService.AddProductDiscount(product2, discount2);

            _shoppingCartService.RemoveProductDiscount(product2);
            _shoppingCartService.RemoveProduct(product2);

            var receipt2 = _shoppingCartService.GetReceipt();

            Assert.AreEqual(receipt1, receipt2);
        }

        [Test]
        public void DiscountTest()
        {
            var product = new ProductModel {Id = Guid.NewGuid(), Name = "product1", Price = 1m};
            var discount = new DiscountModel {Code = "discount1", Percents = 0.75m};

            _shoppingCartService.AddProduct(product);
            _shoppingCartService.AddProductDiscount(product, discount);

            var expectedAmount = _shoppingCartService.GetShoppingCart().GetTotalAmount();
            var actualAmount = product.Price * (1 - discount.Percents);

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void UndoTest()
        {
            var product1 = new ProductModel {Id = Guid.NewGuid(), Name = "product1", Price = 1m};
            var product2 = new ProductModel {Id = Guid.NewGuid(), Name = "product2", Price = 2m};

            var discount1 = new DiscountModel {Code = "discount1", Percents = 0.50m};
            var discount2 = new DiscountModel {Code = "discount2", Percents = 0.25m};

            _shoppingCartService.AddProduct(product1);
            _shoppingCartService.AddProductDiscount(product1, discount1);

            var receipt1 = _shoppingCartService.GetReceipt();

            _shoppingCartService.AddProduct(product2);
            _shoppingCartService.AddProductDiscount(product2, discount2);

            _shoppingCartService.Undo();
            _shoppingCartService.Undo();

            var receipt2 = _shoppingCartService.GetReceipt();

            Assert.AreEqual(receipt1, receipt2);
        }

        [Test]
        public void RedoTest()
        {
            var product1 = new ProductModel {Id = Guid.NewGuid(), Name = "product1", Price = 1m};
            var product2 = new ProductModel {Id = Guid.NewGuid(), Name = "product2", Price = 2m};

            var discount1 = new DiscountModel {Code = "discount1", Percents = 0.50m};
            var discount2 = new DiscountModel {Code = "discount2", Percents = 0.25m};

            _shoppingCartService.AddProduct(product1);
            _shoppingCartService.AddProduct(product2);
            _shoppingCartService.AddProductDiscount(product1, discount1);
            _shoppingCartService.AddProductDiscount(product2, discount2);

            var receipt1 = _shoppingCartService.GetReceipt();

            _shoppingCartService.Undo();
            _shoppingCartService.Undo();

            _shoppingCartService.Redo();
            _shoppingCartService.Redo();

            var receipt2 = _shoppingCartService.GetReceipt();

            Assert.AreEqual(receipt1, receipt2);
        }
    }
}