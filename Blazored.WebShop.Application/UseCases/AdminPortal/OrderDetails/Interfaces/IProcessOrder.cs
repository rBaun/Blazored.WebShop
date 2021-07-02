using System;
using System.Collections.Generic;
using System.Text;

namespace Blazored.WebShop.Application.UseCases.AdminPortal.OrderDetails.Interfaces
{
    public interface IProcessOrder
    {
        bool Execute(int orderId, string adminUsername);
    }
}
