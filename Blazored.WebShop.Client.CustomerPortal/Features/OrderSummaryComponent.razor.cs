using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Features
{
    partial class OrderSummaryComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public Order Order { get; set; }
        [Parameter] public bool HidePlaceOrderButton { get; set; } = false;

        private int _orderLineItemsCount = 0;
        private double _orderTotalPrice = 0;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Order == null) return;
            _orderLineItemsCount = Order.OrderLineItems.Count;
            _orderTotalPrice = 0; // calculates new price when parameters are set, starting from 0
            Order.OrderLineItems.ForEach(item => _orderTotalPrice += item.Price * item.Quantity);
        }

        private void PlaceOrder()
        {
            NavigationManager.NavigateTo("/PlaceOrder");
        }
    }
}
