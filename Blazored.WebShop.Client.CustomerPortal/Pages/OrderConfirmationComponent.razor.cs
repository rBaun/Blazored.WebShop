using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Application.UseCases.OrderConfirmation.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Pages
{
    partial class OrderConfirmationComponent
    {
        [Inject] public IViewOrderConfirmation ViewOrderConfirmation { get; set; }
        [Parameter] public string UniqueId { get; set; }

        private Order _order;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (!string.IsNullOrWhiteSpace(UniqueId))
            {
                _order = ViewOrderConfirmation.Execute(UniqueId);
            }
        }
    }
}
