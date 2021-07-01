using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.OrderConfirmation.Interfaces
{
    public interface IViewOrderConfirmation
    {
        Order Execute(string uniqueId);
    }
}
