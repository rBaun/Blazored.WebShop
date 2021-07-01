using System;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.Plugins.StateManagement;
using Blazored.WebShop.Application.UseCases.PlaceOrder.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Blazored.WebShop.Core.Business.Services.Interfaces;

namespace Blazored.WebShop.Application.UseCases.PlaceOrder
{
    public class PlaceOrder : IPlaceOrder
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public PlaceOrder(IOrderService orderService, IOrderRepository orderRepository, IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<string> Execute(Order order)
        {
            if (!_orderService.ValidateCreateOrder(order)) 
                return null;

            order.OrderPlacedOn = DateTime.Now;
            order.UniqueId = Guid.NewGuid().ToString();
            _orderRepository.CreateOrder(order);

            await _shoppingCart.EmptyAsync();
            _shoppingCartStateStore.UpdateOrderLineItemsCount();

            return order.UniqueId;
        }
    }
}
