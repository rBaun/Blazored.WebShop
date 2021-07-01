using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.PlaceOrder.Interfaces
{
    public interface IPlaceOrder
    {
        Task<string> Execute(Order order);
    }
}
