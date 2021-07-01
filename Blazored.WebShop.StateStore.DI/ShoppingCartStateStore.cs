using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.Plugins.StateManagement;

namespace Blazored.WebShop.StateStore.DI
{
    public class ShoppingCartStateStore : StateStoreBase, IShoppingCartStateStore
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartStateStore(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public async Task<int> GetOrderLineItemsCount()
        {
            var order = await _shoppingCart.GetOrderAsync();

            if (order?.OrderLineItems != null && order.OrderLineItems.Any())
                return order.OrderLineItems.Count;

            return 0;
        }

        public void UpdateOrderLineItemsCount()
        {
            BroadcastStateChange();
        }

        public void UpdateProductQuantity()
        {
            BroadcastStateChange();
        }
    }
}
