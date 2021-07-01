using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.ShoppingCart.Interfaces
{
    public interface IPlaceOrder
    {
        Task<string> Execute(Order order);
    }
}
