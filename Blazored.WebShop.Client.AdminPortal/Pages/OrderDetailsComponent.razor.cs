using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.AdminPortal.Pages
{
    [Authorize]
    partial class OrderDetailsComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public int OrderId { get; set; }
        [Inject] public IViewOrderDetails ViewOrderDetails { get; set; }
        [Inject] public IProcessOrder ProcessOrder { get; set; }

        private Order _order;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (OrderId > 0)
            {
                _order = ViewOrderDetails.Execute(OrderId);
            }
        }

        private void HandleProcessOrder()
        {
            if (_order?.OrderId == null) 
                return;

            ProcessOrder.Execute(_order.OrderId.Value, "admin");
            NavigationManager.NavigateTo("/orders-in-progress");
        }
    }
}
