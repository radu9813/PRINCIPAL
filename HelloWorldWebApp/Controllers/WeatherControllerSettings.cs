using Microsoft.Extensions.Configuration;

namespace HelloWorldWebApp.Controllers
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration conf)
        {
            ApiKey = conf["WeatherForecast:ApiKey"];
            Longitude = conf["WeatherForecast:Longitude"];
            Latitude = conf["WeatherForecast:Latitude"];

        }

        public string ApiKey { get; }

        public string Longitude { get; }

        public string Latitude { get; }
    }
}
