using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails
{
    public class ViewOrderDetails : IViewOrderDetails
    {
        private readonly IOrderRepository _orderRepository;

        public ViewOrderDetails(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Execute(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }
    }
}
