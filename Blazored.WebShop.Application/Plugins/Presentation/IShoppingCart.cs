using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.Plugins.Presentation
{
    public interface IShoppingCart
    {
        Task<Order> GetOrderAsync();
        Task<Order> AddProductAsync(Product product);
        Task<Order> UpdateQuantityAsync(int productId, int quantity);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> RemoveProductAsync(int productId);
        Task<Order> PlaceOrderAsync();
        Task EmptyAsync();
    }
}
