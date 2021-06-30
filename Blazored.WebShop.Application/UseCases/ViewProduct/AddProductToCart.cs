using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Application.Interfaces.Persistence;
using Blazored.WebShop.Application.Plugins.Presentation;
using Blazored.WebShop.Application.UseCases.ViewProduct.Interfaces;

namespace Blazored.WebShop.Application.UseCases.ViewProduct
{
    public class AddProductToCart : IAddProductToCart
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCart _shoppingCart;

        public AddProductToCart(IProductRepository productRepository, IShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public async void Execute(int productId)
        {
            await _shoppingCart.AddProductAsync(_productRepository.GetProduct(productId));
        }
    }
}
