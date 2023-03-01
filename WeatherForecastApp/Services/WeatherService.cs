using Newtonsoft.Json;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration configuration;

        public WeatherService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<OpenWeatherResponseModel> GetCity(string name)
        {
            var key = configuration.GetValue<string>("OpenWeather:SecretKey");
            var uri = $"{configuration.GetValue<string>("OpenWeather:url")}/weather?q={name}&appid={key}";


            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(uri);

                if (!request.IsSuccessStatusCode)
                {
                    return null;
                }

                var response = await request.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OpenWeatherResponseModel>(response);
                result.weather.FirstOrDefault();
                return result;
            }
        }
    }
}
