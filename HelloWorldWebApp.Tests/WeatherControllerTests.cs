using HelloWorldWebApp.Controllers;
using HelloWorldWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWebApp.Tests
{
    public class WeatherControllerTests
    {
        IWeatherControllerSettings weatherControllerSettings;
        [Fact]
        public void TestCheckingConversion()
        {
            //Assume
            weatherControllerSettings = new WeatherControllerSettings();
            string content = "{\"lat\":46.77,\"lon\":23.5914,\"timezone\":\"Europe / Bucharest\",\"timezone_offset\":10800,\"current\":{\"dt\":1628756332,\"sunrise\":1628738376,\"sunset\":1628790115,\"temp\":296.92,\"feels_like\":296.92,\"pressure\":1020,\"humidity\":60,\"dew_point\":288.7,\"uvi\":4.57,\"clouds\":20,\"visibility\":10000,\"wind_speed\":4.12,\"wind_deg\":300,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}]},\"daily\":[{\"dt\":1628762400,\"sunrise\":1628738376,\"sunset\":1628790115,\"moonrise\":1628753220,\"moonset\":1628797680,\"moon_phase\":0.13,\"temp\":{\"day\":297.88,\"min\":290.11,\"max\":300.6,\"night\":290.77,\"eve\":298.35,\"morn\":291.52},\"feels_like\":{\"day\":297.74,\"night\":289.92,\"eve\":297.97,\"morn\":291.19},\"pressure\":1020,\"humidity\":51,\"dew_point\":287.07,\"wind_speed\":4.85,\"wind_deg\":318,\"wind_gust\":6.74,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":20,\"pop\":0,\"uvi\":6.81},{\"dt\":1628848800,\"sunrise\":1628824853,\"sunset\":1628876418,\"moonrise\":1628844180,\"moonset\":1628885400,\"moon_phase\":0.17,\"temp\":{\"day\":299.72,\"min\":287.39,\"max\":302.08,\"night\":292.33,\"eve\":300.43,\"morn\":287.84},\"feels_like\":{\"day\":299.72,\"night\":291.56,\"eve\":300.22,\"morn\":286.98},\"pressure\":1023,\"humidity\":37,\"dew_point\":283.15,\"wind_speed\":2.67,\"wind_deg\":269,\"wind_gust\":3.79,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":23,\"pop\":0,\"uvi\":6.82},{\"dt\":1628935200,\"sunrise\":1628911331,\"sunset\":1628962719,\"moonrise\":1628935140,\"moonset\":1628973240,\"moon_phase\":0.2,\"temp\":{\"day\":301.78,\"min\":288.85,\"max\":303.99,\"night\":294.33,\"eve\":302.88,\"morn\":289.17},\"feels_like\":{\"day\":300.96,\"night\":293.81,\"eve\":302.43,\"morn\":288.34},\"pressure\":1022,\"humidity\":34,\"dew_point\":283.81,\"wind_speed\":2.03,\"wind_deg\":329,\"wind_gust\":3.51,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":15,\"pop\":0,\"uvi\":7.09},{\"dt\":1629021600,\"sunrise\":1628997809,\"sunset\":1629049020,\"moonrise\":1629026280,\"moonset\":0,\"moon_phase\":0.25,\"temp\":{\"day\":302.94,\"min\":291.57,\"max\":306.02,\"night\":299.7,\"eve\":305.87,\"morn\":291.57},\"feels_like\":{\"day\":302.2,\"night\":299.7,\"eve\":305.4,\"morn\":290.88},\"pressure\":1017,\"humidity\":36,\"dew_point\":285.7,\"wind_speed\":2.05,\"wind_deg\":282,\"wind_gust\":4.53,\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":10,\"pop\":0.07,\"uvi\":6.99},{\"dt\":1629108000,\"sunrise\":1629084287,\"sunset\":1629135319,\"moonrise\":1629117480,\"moonset\":1629061260,\"moon_phase\":0.28,\"temp\":{\"day\":300.33,\"min\":293.31,\"max\":306.91,\"night\":299.15,\"eve\":306.91,\"morn\":293.31},\"feels_like\":{\"day\":300.74,\"night\":299.15,\"eve\":306.29,\"morn\":293.29},\"pressure\":1015,\"humidity\":50,\"dew_point\":288.24,\"wind_speed\":3.44,\"wind_deg\":203,\"wind_gust\":4.66,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":86,\"pop\":0.69,\"rain\":0.89,\"uvi\":6.24},{\"dt\":1629194400,\"sunrise\":1629170764,\"sunset\":1629221617,\"moonrise\":1629208500,\"moonset\":1629149760,\"moon_phase\":0.31,\"temp\":{\"day\":306.11,\"min\":295.15,\"max\":309.36,\"night\":298.16,\"eve\":306.96,\"morn\":295.15},\"feels_like\":{\"day\":304.71,\"night\":297.84,\"eve\":305.72,\"morn\":294.69},\"pressure\":1010,\"humidity\":27,\"dew_point\":284.04,\"wind_speed\":7.96,\"wind_deg\":225,\"wind_gust\":7.83,\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":70,\"pop\":0.07,\"uvi\":7},{\"dt\":1629280800,\"sunrise\":1629257242,\"sunset\":1629307915,\"moonrise\":1629299100,\"moonset\":1629238800,\"moon_phase\":0.35,\"temp\":{\"day\":302.28,\"min\":292.39,\"max\":304.31,\"night\":296.32,\"eve\":304.13,\"morn\":292.39},\"feels_like\":{\"day\":302.29,\"night\":296.21,\"eve\":303.76,\"morn\":292.25},\"pressure\":1010,\"humidity\":44,\"dew_point\":288.23,\"wind_speed\":4.54,\"wind_deg\":337,\"wind_gust\":4.98,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":14,\"pop\":0.03,\"uvi\":7},{\"dt\":1629367200,\"sunrise\":1629343720,\"sunset\":1629394210,\"moonrise\":1629389040,\"moonset\":1629328560,\"moon_phase\":0.39,\"temp\":{\"day\":300.09,\"min\":291.1,\"max\":302.15,\"night\":292.38,\"eve\":293.84,\"morn\":291.1},\"feels_like\":{\"day\":300.02,\"night\":292.6,\"eve\":294.16,\"morn\":290.86},\"pressure\":1007,\"humidity\":41,\"dew_point\":285.29,\"wind_speed\":3.87,\"wind_deg\":311,\"wind_gust\":4.93,\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"clouds\":64,\"pop\":0.99,\"rain\":9.67,\"uvi\":7}]}";
            WeatherController weatherController = new WeatherController(weatherControllerSettings);
            //Act
            var result = weatherController.ConvertResponseToWeatherRecordList(content);
            //Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();

            Assert.Equal(new DateTime(2021, 8, 12), firstDay.Day);
            Assert.Equal(24.730010986328125, firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }
    }
}
