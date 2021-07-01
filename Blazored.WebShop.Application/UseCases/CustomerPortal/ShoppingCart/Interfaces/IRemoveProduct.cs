using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart.Interfaces
{
    public interface IRemoveProduct
    {
        Task<Order> Execute(int productId);
    }
}
