using Blazored.WebShop.Application.UseCases.ViewProduct.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Pages
{
    partial class ViewProductComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IViewProduct ViewProduct { get; set; }
        [Inject] public IAddProductToCart AddProductToCart { get; set; }
        private Product _product;

        [Parameter]
        public int Id { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Id > 0)
            {
                _product = ViewProduct.Execute(Id);
            }
        }

        private void AddToCart()
        {
            AddProductToCart.Execute(_product.ProductId);
            NavigationManager.NavigateTo("/");
        }
    }
}
