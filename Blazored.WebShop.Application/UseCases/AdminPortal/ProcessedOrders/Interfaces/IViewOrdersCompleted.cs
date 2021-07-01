using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.AdminPortal.ProcessedOrders.Interfaces
{
    public interface IViewOrdersCompleted
    {
        IEnumerable<Order> Execute();
    }
}