using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.PlaceOrder.Interfaces
{
    public interface IPlaceOrder
    {
        Task<string> Execute(Order order);
    }
}
