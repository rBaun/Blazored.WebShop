using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.UseCases.ShoppingCart.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Pages
{
    partial class ShoppingCartComponent
    {
        [Inject] public IViewShoppingCart ViewShoppingCart { get; set; }
        private Order _order;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _order = await ViewShoppingCart.Execute();
                StateHasChanged();
            }
        }
    }
}
