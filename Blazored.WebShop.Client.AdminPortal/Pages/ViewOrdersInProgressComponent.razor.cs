using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.UseCases.AdminPortal.OutstandingOrders.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.AdminPortal.Pages
{
    partial class ViewOrdersInProgressComponent
    {
        [Inject] public IViewOrdersInProgress ViewOrdersInProgress { get; set; }
        private IEnumerable<Order> _orders;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _orders = ViewOrdersInProgress.Execute();
        }
    }
}
