using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazored.WebShop.Client.Common.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.Common.Features
{
    partial class LoginComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        private LoginViewModel _loginViewModel;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _loginViewModel = new LoginViewModel();
        }

        private void HandleValidLogin()
        {
            NavigationManager.NavigateTo($"/authenticate?user={_loginViewModel.Username}&password={_loginViewModel.Password}", true);
        }
    }
}
