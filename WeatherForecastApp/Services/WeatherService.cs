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
            //returns an empty response when nothing is passed to the parameter {name} 
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var key = configuration.GetValue<string>("OpenWeather:SecretKey");
            var uri = $"{configuration.GetValue<string>("OpenWeather:url")}/weather?q={name}&appid={key}";


            using (var client = new HttpClient())
            {
                var request = await client.GetAsync(uri);

                /*returns an empty response when the cityname passed to the parameter {name}
                is wrong or not found*/

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
