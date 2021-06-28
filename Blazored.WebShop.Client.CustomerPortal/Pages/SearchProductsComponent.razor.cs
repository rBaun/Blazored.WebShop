using System.Collections.Generic;
using Blazored.WebShop.Application.UseCases.SearchProduct.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Pages
{
    partial class SearchProductsComponent
    {
        [Inject] public ISearchProduct SearchProduct { get; set; }
        private IEnumerable<Product> _products;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _products = SearchProduct.Execute();
        }

        private void HandleSearch(string filter)
        {
            _products = SearchProduct.Execute(filter);
        }
    }
}
