using Microsoft.AspNetCore.Components;

namespace Blazored.WebShop.Client.Common.Features
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
