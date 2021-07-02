using System.Collections.Generic;
using Blazored.WebShop.Application.UseCases.AdminPortal.ProcessedOrders.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.AdminPortal.Pages
{
    [Authorize]
    partial class OrdersCompletedComponent
    {
        [Inject] public IViewOrdersCompleted ViewOrdersCompleted{ get; set; }
        private IEnumerable<Order> _orders;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _orders = ViewOrdersCompleted.Execute();
        }
    }
}
