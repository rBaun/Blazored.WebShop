using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.Plugins.Persistence
{
    public interface IOrderRepository
    {
        Order GetOrderById(int orderId);
        Order GetOrderByUniqueId(string uniqueId);
        int CreateOrder(Order order);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrdersInProgress();
        IEnumerable<Order> GetOrdersCompleted();

        IEnumerable<OrderLineItem> GetOrderLineItemsByOrderId(int orderId);
    }
}
