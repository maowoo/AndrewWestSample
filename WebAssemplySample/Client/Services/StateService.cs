using WebAssemblySample.Shared;

namespace WebAssemblySample.Client.Services
{
    public interface IStateService
    {
        void SetWeatherForcast(WeatherForecast[]? current);
        WeatherForecast[]? GetWeatherForcasts();
        void SetEditDto(EditDto dto);
        EditDto GetEditDto();
    }

    public class StateService : IStateService
    {
        private WeatherForecast[]? _weatherForcasts;
        private EditDto? _editDto;

        public void SetWeatherForcast(WeatherForecast[]? current)
        {
            _weatherForcasts=current;

        }

        public WeatherForecast[]? GetWeatherForcasts()
        {
            return _weatherForcasts;
        }

        public void SetEditDto(EditDto dto)
        {
            _editDto=dto;
        }

        public EditDto GetEditDto()
        {
            return _editDto;
        }
    }
}
