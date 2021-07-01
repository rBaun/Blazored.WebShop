using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.Plugins.StateManagement;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart
{
    public class UpdateQuantity : IUpdateQuantity
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public UpdateQuantity(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            _shoppingCart = shoppingCart;
            _shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<Order> Execute(int productId, int quantity)
        {
            var order = await _shoppingCart.UpdateQuantityAsync(productId, quantity);
            _shoppingCartStateStore.UpdateProductQuantity();

            return order;
        }
    }
}
