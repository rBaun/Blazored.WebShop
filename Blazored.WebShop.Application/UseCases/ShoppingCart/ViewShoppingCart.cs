using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.UseCases.ShoppingCart.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.ShoppingCart
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
