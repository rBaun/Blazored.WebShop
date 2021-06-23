using System;
using System.Collections.Generic;
using System.Text;
using Blazored.WebShop.Core.Business.Models;

namespace Blazored.WebShop.Application.UseCases.ViewProduct.Interfaces
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}
