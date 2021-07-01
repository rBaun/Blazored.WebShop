using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart
{
    public class ViewShoppingCart : IViewShoppingCart
    {
        private readonly IShoppingCart _shoppingCart;

        public ViewShoppingCart(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public Task<Order> Execute()
        {
            return _shoppingCart.GetOrderAsync();
        }
    }
}
