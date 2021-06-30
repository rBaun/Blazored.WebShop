using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.StateManagement;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Features
{
    partial class CartComponent : IDisposable
    {
        [Inject] public IShoppingCartStateStore ShoppingCartStateStore { get; set; }
        private int _orderLineItemsCount = 0;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                ShoppingCartStateStore.AddStateChangeListeners(OnShoppingCartStateChanged);
                _orderLineItemsCount = await ShoppingCartStateStore.GetOrderLineItemsCount();
                StateHasChanged();
            }
        }

        private async void OnShoppingCartStateChanged()
        {
            _orderLineItemsCount = await ShoppingCartStateStore.GetOrderLineItemsCount();
            StateHasChanged();
        }

        public void Dispose()
        {
            ShoppingCartStateStore.RemoveStateChangeListeners(OnShoppingCartStateChanged);
        }
    }
}
