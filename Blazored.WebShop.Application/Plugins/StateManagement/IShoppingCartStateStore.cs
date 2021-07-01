using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazored.WebShop.Application.Plugins.StateManagement
{
    public interface IShoppingCartStateStore : IStateStore
    {
        Task<int> GetOrderLineItemsCount();

        void UpdateOrderLineItemsCount();
        void UpdateProductQuantity();
    }
}
