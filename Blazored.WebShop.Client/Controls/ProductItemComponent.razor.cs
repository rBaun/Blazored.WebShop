using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.Controls
{
    partial class ProductItemComponent
    {
        [Parameter]
        public Product Product { get; set; }
    }
}
