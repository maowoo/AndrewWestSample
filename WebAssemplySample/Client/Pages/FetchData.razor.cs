using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using WebAssemblySample.Client.Services;
using WebAssemblySample.Shared;

namespace WebAssemblySample.Client.Pages
{
    public partial class FetchData
    {

        [Inject] private HttpClient _httpClient { get; set; }
        [Inject] private IStateService _stateService { get; set; }
        private EditDto _dto { get; set; } = new();
        private DataBetweenParentAndChild _child;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var stateDto = _stateService.GetEditDto();
                if (stateDto == null)
                    await LoadData();
                else
                {
                    _dto = stateDto;
                    StateHasChanged();
                }
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task LoadData()
        {
            _dto = await _httpClient.GetFromJsonAsync<EditDto>("Demo");
           StateHasChanged();
        }

        private void FakeSubmit()
        {
            //not in demo
            // var json = JsonConvert.SerializeObject(_dto);
            // var content = new StringContent(json, encoding: Encoding.UTF8, "application/json");
            // var request = new HttpRequestMessage(HttpMethod.Post, "sample/myEndPoint");
            // request.Content = content;
            //await _httpClient.PostAsync(url, content);
        }

        private void UpdateParentDtoFromChild(ChildEditDto childDto)
        {
            _dto.UpdateChildData(childDto);
            UpdateState();
            StateHasChanged();
        }

        private void UpdateState()
        {
            _stateService.SetEditDto(_dto);
        }

        private async Task LoadDataFromChild()
        {
          await  _child.LoadData();
        }
    }
}
