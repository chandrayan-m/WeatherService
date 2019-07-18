using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherService.Repository;
using WeatherService.Repository.Entity;
using WeatherService.Repository.Middleware;
using WeatherService.Repository.Repository;

namespace PrudentialWeatherService.Test
{
    [TestClass()]
    public class WeatherRepositoryMiddlewareTest
    {
        private IList<CityDAO> citiesDAO;
        private int cityId;
        private OpenWeatherReport weatherReport;
        private IEnumerable<CityDAO> cities;
        private OpenWeatherReport weatherReportNull;


        [TestInitialize]
        public void Init()
        {
            cityId = 12345;
            cities = new List<CityDAO> { new CityDAO { cityId = 12345, cityName = "Paris" } };
            weatherReport = new OpenWeatherReport { id = 12345, name = "Paris" };
            weatherReportNull = null;
        }
        [TestMethod]
        public async Task GetWeatherReports_ReturnsNotNull()
        {
            
            var mock = new Mock<IWeatherRepository>();
            mock.Setup(p => p.GetWeatherReport(cityId, "", "")).ReturnsAsync(weatherReport);
            var middleware = new Mock<Middleware>(mock.Object);
            var result = middleware.Object.GetWeatherReport(cities, "", "", "");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetWeatherReports_ReturnsNull()
        {
            var mock = new Mock<IWeatherRepository>();
            mock.Setup(p => p.GetWeatherReport(cityId, "", "")).ReturnsAsync(weatherReportNull);
            var middleware = new Mock<Middleware>(mock.Object);
            var result = middleware.Object.GetWeatherReport(cities, "", "", "");
            Assert.IsNull(result.Result[0]);
        }
    }
}
