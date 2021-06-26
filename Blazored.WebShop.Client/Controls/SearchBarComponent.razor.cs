using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.Controls
{
    public partial class SearchBarComponent
    {
        public string SearchTerm { get; set; }
        [Parameter] public EventCallback<string> OnSearch { get; set; }

        private void HandleSearch()
        {
            OnSearch.InvokeAsync(SearchTerm);
        }
    }
}
