using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blazored.WebShop.Core.Business.Models;
using Blazored.WebShop.Core.Business.Services.Interfaces;

namespace Blazored.WebShop.Core.Business.Services
{
    public class OrderService : IOrderService
    {
        public bool ValidateCustomerInformation(string name, string address,
            string city, string province, string country)
        {
            return !string.IsNullOrWhiteSpace(name) 
                   && !string.IsNullOrWhiteSpace(address) 
                   && !string.IsNullOrWhiteSpace(city) 
                   && !string.IsNullOrWhiteSpace(province) 
                   && !string.IsNullOrWhiteSpace(country);
        }

        public bool ValidateCreateOrder(Order order)
        {
            if (order == null)
                return false;

            if (!OrderHasOrderLineItems(order))
                return false;

            if (order.OrderLineItems.Any(item => item.ProductId <= 0 || item.Price < 0 || item.Quantity <= 0))
                return false;

            return ValidateCustomerInformation(order.CustomerName, order.CustomerAddress,
                order.CustomerCity, order.CustomerStateProvince, order.CustomerCountry);
        }

        public bool ValidateUpdateOrder(Order order)
        {
            if (order?.OrderId == null) 
                return false;

            if (!OrderHasOrderLineItems(order))
                return false;

            if (OrderIsActive(order) || !order.OrderPlacedOn.HasValue)
                return false;

            if (string.IsNullOrWhiteSpace(order.UniqueId)) 
                return false;

            if (order.OrderLineItems
                .Any(item => item.ProductId <= 0 || item.Price < 0 ||
                             item.Quantity <= 0 || item.OrderId == order.OrderId))
            {
                return false;
            }

            return ValidateCustomerInformation(order.CustomerName,
                order.CustomerAddress,
                order.CustomerCity,
                order.CustomerStateProvince,
                order.CustomerCountry);
        }

        public bool ValidateProcessOrder(Order order)
        {
            return order.OrderFinishedOn.HasValue
                   && !string.IsNullOrWhiteSpace(order.AdminUser);
        }

        private static bool OrderHasOrderLineItems(Order order)
        {
            return order.OrderLineItems != null && order.OrderLineItems.Count > 0;
        }

        private static bool OrderIsActive(Order order)
        {
            return order.OrderReceivedOn.HasValue
                   || order.OrderFinishedOn.HasValue;
        }
    }
}
