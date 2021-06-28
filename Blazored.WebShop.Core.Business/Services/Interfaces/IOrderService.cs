using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Core.Business.Services.Interfaces
{
    public interface IOrderService
    {
        bool ValidateCustomerInformation(string name, string address, string city, string province, string country);
        bool ValidateCreateOrder(Order order);
        bool ValidateUpdateOrder(Order order);
        bool ValidateProcessOrder(Order order);
    }
}
