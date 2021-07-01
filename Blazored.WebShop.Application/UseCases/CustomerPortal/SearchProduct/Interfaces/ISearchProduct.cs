using System.Collections.Generic;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.SearchProduct.Interfaces
{
    public interface ISearchProduct
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}
