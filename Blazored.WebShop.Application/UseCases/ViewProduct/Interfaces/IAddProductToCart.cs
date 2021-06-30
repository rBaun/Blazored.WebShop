using System;
using System.Collections.Generic;
using System.Text;

namespace Blazored.WebShop.Application.UseCases.ViewProduct.Interfaces
{
    public interface IAddProductToCart
    {
        void Execute(int productId);
    }
}
