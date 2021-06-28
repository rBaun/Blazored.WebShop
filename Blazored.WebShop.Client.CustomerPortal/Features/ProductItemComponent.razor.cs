using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Features
{
    partial class ProductItemComponent
    {
        [Parameter]
        public Product Product { get; set; }
    }
}
