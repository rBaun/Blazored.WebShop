using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.UseCases.AdminPortal.ProcessedOrders.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Blazored.WebShop.Core.Business.Services.Interfaces;

namespace Blazored.WebShop.Application.UseCases.AdminPortal.ProcessedOrders
{
    public class ViewOrdersCompleted : IViewOrdersCompleted
    {
        private readonly IOrderRepository _orderRepository;

        public ViewOrdersCompleted(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return _orderRepository.GetOrdersCompleted();
        }
    }
}
