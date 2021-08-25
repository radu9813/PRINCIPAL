using HelloWorldWebApp.Controllers;
using HelloWorldWebApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWebApp.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void TestCheckingConversion()
        {
            //Assume
            var weatherControllerSettingsMock = new Mock<IWeatherControllerSettings>();
            var weatherObject = weatherControllerSettingsMock.Object;
            string content = LoadJsonFromResource();
            WeatherController weatherController = new WeatherController(weatherObject);
            //Act
            var result = weatherController.ConvertResponseToWeatherRecordList(content);
            //Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();

            Assert.Equal(new DateTime(2021, 8, 12), firstDay.Day);
            Assert.Equal(24.730010986328125, firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }

        private string LoadJsonFromResource()
        { var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.TestData.ContetWeatherApi.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
