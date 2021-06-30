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
        [Parameter] public Order Order { get; set; }

        private int orderLineItemsCount = 0;
        private double orderTotalPrice = 0;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Order == null) return;
            orderLineItemsCount = Order.OrderLineItems.Count;
            Order.OrderLineItems.ForEach(item => orderTotalPrice += item.Price * item.Quantity);
        }

        private void PlaceOrder()
        {

        }
    }
}
