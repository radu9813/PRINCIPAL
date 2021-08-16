using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace HelloWorldWebApp.Controllers
{ /// <summary>
    /// fetch data from weather API
  /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude;
        private readonly string longitude;
        private readonly string apiKey;

        public WeatherController(IWeatherControllerSettings weatherControllerSettings)
        {
            longitude = weatherControllerSettings.Longitude;
            latitude = weatherControllerSettings.Latitude;
            apiKey = weatherControllerSettings.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            // lat 46.7700 lon 23.5800 Cluj napoca
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.591423&exclude=hourly,minutely&appid=cc1d9318d81a28a04bf0bd039a22f1a3
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content);
        }

        /// <summary>
        /// Get a weather forecast for the day in specified amount of days from now.
        /// </summary>
        /// <param name="index">Amount of days from now (e.g. 0 is the current day, index is from 0 - 7).</param>
        /// <returns>The weather forecast.</returns>
        [HttpGet("{index}")]
        public DailyWeatherRecord Get(int index)
        {
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content).ElementAt(index);
        }

        [NonAction]
        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);

            List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();

            var jsonArray = json["daily"].Take(7);

            return jsonArray.Select(CreateDailyWeatherRecordFromJToken);
        }



        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            DailyWeatherRecord daily = new DailyWeatherRecord(new DateTime(), item.SelectToken("temp").Value<float>("day") - DailyWeatherRecord.KELVIN_CONST, WeatherType.FewClouds);
            daily.Day = DateTimeOffset.FromUnixTimeSeconds(item.Value<long>("dt")).DateTime.Date;
            string weather = item.SelectToken("weather")[0].Value<string>("description");
            daily.Type = Convert(weather);
            return daily;
        }

        private WeatherType Convert(String description)
        {
            switch (description)
            {
                case "few clouds":
                    return WeatherType.FewClouds;
                case "light rain":
                    return WeatherType.LigtRain;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "clear sky":
                    return WeatherType.ClearSky;
                case "moderate rain":
                    return WeatherType.ModerateRain;
                case "overcast clouds":
                    return WeatherType.OvercastCluds;
                default:
                    throw new Exception("Unknown weather type " + description);
            }
        }
    }
}
