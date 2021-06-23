using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Application.Interfaces.Persistence;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.SearchProduct
{
    public class SearchProduct
    {
        private readonly IProductRepository _productRepository;

        public SearchProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(string filter)
        {
            return _productRepository.GetProducts(filter);
        }
    }
}
