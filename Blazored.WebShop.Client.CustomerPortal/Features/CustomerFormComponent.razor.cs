using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Client.CustomerPortal.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.CustomerPortal.Features
{
    partial class CustomerFormComponent
    {
        [Parameter] public EventCallback<CustomerViewModel> OnCustomerInfoSubmitted { get; set; }
        private CustomerViewModel _customer;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _customer = new CustomerViewModel();
        }

        private void HandleValidSubmit()
        {
            OnCustomerInfoSubmitted.InvokeAsync(_customer);
        }
    }
}
