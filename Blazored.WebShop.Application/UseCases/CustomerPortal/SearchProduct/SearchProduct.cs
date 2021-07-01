using System.Collections.Generic;
using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.UseCases.CustomerPortal.SearchProduct.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.SearchProduct
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository _productRepository;

        public SearchProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter = null)
        {
            return _productRepository.GetProducts(filter);
        }
    }
}
