using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.WebShop.Application.UseCases.ViewProduct.Interfaces;
using Blazored.WebShop.Core.Business.Models;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.Pages
{
    partial class ViewProductComponent
    {
        [Inject] public IViewProduct ViewProduct { get; set; }
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
    }
}
