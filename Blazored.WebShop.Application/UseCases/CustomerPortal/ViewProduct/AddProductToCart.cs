using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.Plugins.StateManagement;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ViewProduct.Interfaces;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.ViewProduct
{
    public class AddProductToCart : IAddProductToCart
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public AddProductToCart(IProductRepository productRepository, IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
            _shoppingCartStateStore = shoppingCartStateStore;
        }

        public async void Execute(int productId)
        {
            await _shoppingCart.AddProductAsync(_productRepository.GetProduct(productId));

            _shoppingCartStateStore.UpdateOrderLineItemsCount();
        }
    }
}
