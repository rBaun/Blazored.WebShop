using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Application.Interfaces.Persistence;
using Blazored.WebShop.Application.UseCases.ViewProduct.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.ViewProduct
{
    public class ViewProduct : IViewProduct
    {
        private readonly IProductRepository _productRepository;

        public ViewProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Execute(int id)
        {
            return _productRepository.GetProduct(id);
        }
    }
}
