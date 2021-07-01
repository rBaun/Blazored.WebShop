using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.OrderConfirmation.Interfaces
{
    public interface IViewOrderConfirmation
    {
        Order Execute(string uniqueId);
    }
}
