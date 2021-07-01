using Blazored.WebShop.Application.Plugins.Persistence;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ViewProduct.Interfaces;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.CustomerPortal.ViewProduct
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
