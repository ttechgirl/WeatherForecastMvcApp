using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public interface IWeatherService
    {
        Task<OpenWeatherResponseModel> GetCity(string name);

    }
}
