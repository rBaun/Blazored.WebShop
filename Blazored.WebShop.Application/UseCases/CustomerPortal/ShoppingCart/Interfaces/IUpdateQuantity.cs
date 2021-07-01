using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart.Interfaces
{
    public interface IUpdateQuantity
    {
        Task<Order> Execute(int productId, int quantity);
    }
}
