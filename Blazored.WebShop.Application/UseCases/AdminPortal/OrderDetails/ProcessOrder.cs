using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails.Interfaces;
using Blazored.WebShop.Core.Business.Services.Interfaces;

namespace Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails
{
    public class ProcessOrder : IProcessOrder
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;

        public ProcessOrder(IOrderRepository orderRepository, IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
        }

        public bool Execute(int orderId, string adminUsername)
        {
            var order = _orderRepository.GetOrderById(orderId);
            order.AdminUser = adminUsername;
            order.OrderFinishedOn = DateTime.Now;

            if (!_orderService.ValidateProcessOrder(order)) 
                return false;

            _orderRepository.UpdateOrder(order);

            return true;
        }
    }
}
