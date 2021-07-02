using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.AdminPortal.Features
{
    partial class OrderListComponent
    {
        [Parameter] public IEnumerable<Order> Orders { get; set; }
    }
}
