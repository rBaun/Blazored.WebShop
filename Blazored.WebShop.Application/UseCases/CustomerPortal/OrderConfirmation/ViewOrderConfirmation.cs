using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.UseCases.CustomerPortal.OrderConfirmation.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.OrderConfirmation
{
    public class ViewOrderConfirmation : IViewOrderConfirmation
    {
        private readonly IOrderRepository _orderRepository;

        public ViewOrderConfirmation(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Execute(string uniqueId)
        {
            return _orderRepository.GetOrderByUniqueId(uniqueId);
        }
    }
}
