using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.UseCases.CustomerPortal.PlaceOrder.Interfaces;
using Blazored.WebShop.Application.UseCases.CustomerPortal.ShoppingCart.Interfaces;
using Blazored.WebShop.Client.CustomerPortal.ViewModels;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Pages
{
    partial class PlaceOrderComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IViewShoppingCart ViewShoppingCart { get; set; }
        [Inject] public IPlaceOrder PlaceOrder { get; set; }
        private Order _order;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _order = await ViewShoppingCart.Execute();
                StateHasChanged();
            }
        }

        private async void HandleCustomerInfoSubmitted(CustomerViewModel customer)
        {
            var mapper = new AutoMapper
                    .MapperConfiguration(config => 
                        config.CreateMap<CustomerViewModel, Order>())
                    .CreateMapper();
            mapper.Map<CustomerViewModel, Order>(customer, _order);

            var orderUniqueId = await PlaceOrder.Execute(_order);

            if (string.IsNullOrEmpty(orderUniqueId))
            {
                // TODO: Handle Order NOT created
            }
            else
            {
                NavigationManager.NavigateTo($"/order-confirmation/{orderUniqueId}");
            }
        }
    }
}
