using HelloWorldWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude = "46.770439";
        private readonly string longitude = "23.591423";
        private readonly string apiKey = "cc1d9318d81a28a04bf0bd039a22f1a3";

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            // lat 46.7700 lon 23.5800 Cluj napoca
            //https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.591423&exclude=hourly,minutely&appid=cc1d9318d81a28a04bf0bd039a22f1a3


            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content);

        }

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            return new DailyWeatherRecord[] { new DailyWeatherRecord(DateTime.Now, 22.0f, WeatherType.Mild) };
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
