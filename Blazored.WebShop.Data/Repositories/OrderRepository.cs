using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> _orders;

        public OrderRepository()
        {
            _orders = new Dictionary<int, Order>();
        }

        public Order GetOrderById(int orderId)
        {
            return _orders[orderId];
        }

        public Order GetOrderByUniqueId(string uniqueId)
        {
            return _orders.SingleOrDefault(order => order.Value.UniqueId == uniqueId).Value;
        }

        public int CreateOrder(Order order)
        {
            order.OrderId = _orders.Count + 1;
            _orders.Add(order.OrderId.Value, order);

            return order.OrderId.Value;
        }

        public void UpdateOrder(Order order)
        {
            if (order?.OrderId == null) return;
            if (_orders[order.OrderId.Value] == null) return;

            _orders[order.OrderId.Value] = order;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders.Values;
        }

        public IEnumerable<Order> GetOrdersInProgress()
        {
            var allOrders = (IEnumerable<Order>) _orders.Values;

            return allOrders.Where(order => !order.OrderFinishedOn.HasValue);
        }

        public IEnumerable<Order> GetOrdersCompleted()
        {
            var allOrders = (IEnumerable<Order>) _orders.Values;

            return allOrders.Where(order => order.OrderFinishedOn.HasValue);
        }

        public IEnumerable<OrderLineItem> GetOrderLineItemsByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
