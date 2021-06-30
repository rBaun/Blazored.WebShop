using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Features
{
    partial class OrderLineItemComponent
    {
        [Parameter] public OrderLineItem OrderLineItem { get; set; }

        private void OnQuantityChanged()
        {

        }

        private void RemoveProduct(int productId)
        {

        }
    }
}
