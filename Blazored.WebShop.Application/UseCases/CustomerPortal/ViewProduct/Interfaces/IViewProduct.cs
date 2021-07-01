using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.ViewProduct.Interfaces
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}
