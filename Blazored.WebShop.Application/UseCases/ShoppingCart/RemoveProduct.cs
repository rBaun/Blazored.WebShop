using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.Plugins.StateManagement;
using Blazored.WebShop.Application.UseCases.ShoppingCart.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.ShoppingCart
{
    public class RemoveProduct : IRemoveProduct
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public RemoveProduct(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            _shoppingCart = shoppingCart;
            _shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<Order> Execute(int productId)
        {
            var order = await _shoppingCart.RemoveProductAsync(productId);
            _shoppingCartStateStore.UpdateOrderLineItemsCount();

            return order;
        }
    }
}
