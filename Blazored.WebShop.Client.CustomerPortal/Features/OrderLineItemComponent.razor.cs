using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.UseCases.ShoppingCart.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Features
{
    partial class OrderLineItemComponent
    {
        [Inject] public IRemoveProduct RemoveProduct { get; set; }
        [Inject] public IUpdateQuantity UpdateQuantity { get; set; }
        [Parameter] public OrderLineItem OrderLineItem { get; set; }
        [Parameter] public EventCallback<Order> OnRemovedProduct { get; set; }
        [Parameter] public EventCallback<Order> OnQuantityUpdated { get; set; }

        private async void OnQuantityChanged(ChangeEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value.ToString())) return;
            if (!int.TryParse(args.Value.ToString(), out var qty)) return;
            if (qty < 0) return;

            await OnQuantityUpdated.InvokeAsync(await UpdateQuantity.Execute(OrderLineItem.ProductId, qty));
        }

        private async void RemoveProductById(int productId)
        {
            await OnRemovedProduct.InvokeAsync(await RemoveProduct.Execute(productId));
        }
    }
}
