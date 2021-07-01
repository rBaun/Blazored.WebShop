using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.UseCases.AdminPortal.OutstandingOrders.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.AdminPortal.OutstandingOrders
{
    public class ViewOrdersInProgress : IViewOrdersInProgress
    {
        private readonly IOrderRepository _orderRepository;

        public ViewOrdersInProgress(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return _orderRepository.GetOrdersInProgress();
        }
    }
}
