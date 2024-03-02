using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using WebAssemblySample.Shared;

namespace WebAssemblySample.Client.Pages
{
    public partial class DataBetweenParentAndChild
    {
        [Parameter] public EventCallback<ChildEditDto> OnDataUpdated { get; set; }
        [Parameter] public EditDto _EditDto { get; set; } = new();
        [Inject] protected HttpClient _httpClient { get; set; }

       

        public async Task LoadData()
        {
            var result = await _httpClient.GetFromJsonAsync<ChildEditDto>("Demo/GetChildData");
            await OnDataUpdated.InvokeAsync(result);
        }

        private async Task UpdateParent()
        {
            await OnDataUpdated.InvokeAsync(_EditDto);
        }
    }
}
