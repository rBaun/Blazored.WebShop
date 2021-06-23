using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.SearchProduct.Interfaces
{
    public interface ISearchProduct
    {
        IEnumerable<Product> Execute(string filter = null);
    }
}
