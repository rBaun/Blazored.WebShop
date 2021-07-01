using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Blazored.WebShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private const string _shoppingCartString = "Blazored.WebShop.ShoppingCart";
        private readonly IJSRuntime _jsRuntime;
        private readonly IProductRepository _productRepository;

        public ShoppingCart(IJSRuntime jsRuntime, IProductRepository productRepository)
        {
            _jsRuntime = jsRuntime;
            _productRepository = productRepository;
        }

        public async Task<Order> GetOrderAsync()
        {
            return await GetOrder();
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrder();
            order.AddProduct(product.ProductId, 1, product.Price);
            await SetOrder(order);

            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var order = await GetOrder();

            if (quantity < 0)
                return order;

            if (quantity == 0)
                return await RemoveProductAsync(productId);

            var orderLineItem = order.OrderLineItems.SingleOrDefault(x => x.ProductId == productId);
            if (orderLineItem != null)
                orderLineItem.Quantity = quantity;

            await SetOrder(order);

            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            await SetOrder(order);

            return order;
        }

        public async Task<Order> RemoveProductAsync(int productId)
        {
            var order = await GetOrder();
            order.RemoveProduct(productId);
            await SetOrder(order);

            return order;
        }

        public Task<Order> PlaceOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task EmptyAsync()
        {
            // Does NOT delete it, but makes the order contain the string "null"
            return SetOrder(null);
        }

        private async Task<Order> GetOrder()
        {
            Order order = null;

            var stringOrder = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", _shoppingCartString);
            if (!string.IsNullOrWhiteSpace(stringOrder) && stringOrder.ToLower() != "null")
                order = JsonConvert.DeserializeObject<Order>(stringOrder);
            else
            {
                order = new Order();
                await SetOrder(order);
            }

            foreach (var orderLineItem in order.OrderLineItems)
            {
                orderLineItem.Product = _productRepository.GetProduct(orderLineItem.ProductId);
            }

            return order;
        }

        private async Task SetOrder(Order order)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", _shoppingCartString,
                JsonConvert.SerializeObject(order));
        }
    }
}
