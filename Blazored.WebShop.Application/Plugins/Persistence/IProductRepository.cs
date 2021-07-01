using System.Collections.Generic;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.Plugins.Persistence
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(string filter);
        Product GetProduct(int id);
    }
}
