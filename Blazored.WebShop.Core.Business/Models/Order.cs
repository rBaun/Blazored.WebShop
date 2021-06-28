using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blazored.WebShop.Core.Business.Models
{
    public class Order
    {
        public Order()
        {
            OrderLineItems = new List<OrderLineItem>();
        }

        public int? OrderId { get; set; }

        // Order State
        public DateTime? OrderPlacedOn { get; set; }
        public DateTime? OrderReceivedOn { get; set; }
        public DateTime? OrderFinishedOn { get; set; }

        // Customer Details
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStateProvince { get; set; }
        public string CustomerCountry { get; set; }

        public string AdminUser { get; set; }

        public List<OrderLineItem> OrderLineItems { get; set; }

        public string UniqueId { get; set; }

        public void AddProduct(int productId, int quantity, double price)
        {
            var item = OrderLineItems.FirstOrDefault(item => item.ProductId == productId);
            if (item != null)
                item.Quantity += quantity;
            else
                OrderLineItems.Add(new OrderLineItem {ProductId = productId, Quantity = quantity, Price = price, OrderId = OrderId});
        }

        public void RemoveProduct(int productId)
        {
            var productToRemove = OrderLineItems.SingleOrDefault(orderLineItem => orderLineItem.ProductId == productId);
            
            if (productToRemove != null && productToRemove.ProductId > 0)
                OrderLineItems.Remove(productToRemove);
        }
    }
}
