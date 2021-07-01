using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails.Interfaces
{
    public interface IViewOrderDetails
    {
        Order Execute(int orderId);
    }
}
