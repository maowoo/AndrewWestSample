using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using WebAssemblySample.Client.Services;
using WebAssemblySample.Shared;

namespace WebAssemblySample.Client.Pages
{
    public partial class DataFromTimer : IDisposable
    {
       
        [Inject] private HttpClient _httpClient { get; set; }
        [Inject] private IStateService _stateService { get; set; }
        private PeriodicTimer _periodicTimer = new(TimeSpan.FromSeconds(20));
        private WeatherForecast[]? _forecasts;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _forecasts = _stateService.GetWeatherForcasts();
                if (_forecasts == null)
                  await  GetForcasts();
                else
                {
                    StateHasChanged();
                }
                await RunTimer();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task GetForcasts()
        {
            _forecasts = await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            _stateService.SetWeatherForcast(_forecasts);
            StateHasChanged();
        }

        private async Task RunTimer()
        {
            while (await _periodicTimer.WaitForNextTickAsync())
            {
               GetForcasts();
            }
        }
        

        public void Dispose()
        {
            _periodicTimer.Dispose();
        }
    }
}
