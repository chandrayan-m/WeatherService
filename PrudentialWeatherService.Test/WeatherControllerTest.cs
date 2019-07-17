using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WeatherService.Repository.Entity;
using WeatherService.Repository.Middleware;
using WeatherService.Repository.Repository;
using PrudentialWeatherService;
using System.Net.Http;
using System.Web.Http;
using Moq;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherService.Repository;

namespace PrudentialWeatherService.Test
{
    [TestClass]
    public class WeatherControllerTest
    {
        private IList<CityDAO> citiesDAO;
        private IList<OpenWeatherReport> weatherReport;
        private IList<OpenWeatherReport> nullresponse = null;


        [TestInitialize]
        public void Init()
        {
            weatherReport = new List<OpenWeatherReport> { new OpenWeatherReport { id = 12345, name = "Paris" } };
        }
        [TestMethod]
        public async void GetWeatherReports_ReturnsOKStatusCode()
        {
            //Arrange
            citiesDAO = new List<CityDAO> { new CityDAO { cityId = 1234 } };
            var mock = new Mock<IMiddleware>();
            var config = new Mock<IOptions<ConfigurationItem>>();
            mock.Setup(p => p.GetWeatherReport(citiesDAO, "", "", "")).ReturnsAsync(weatherReport);
            var controller = new Controllers.WeatherController(mock.Object, config.Object);

            //Act
            IActionResult result = await controller.GetWeatherReports(citiesDAO) as OkObjectResult;
            // to case and check for OkObjectResult

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public async void GetWeatherReports_Returns500StatusCode()
        {
            //Arrange
            citiesDAO = new List<CityDAO> { new CityDAO { cityId = 12345} };
            var mock = new Mock<IMiddleware>();
            var config = new Mock<IOptions<ConfigurationItem>>();
            mock.Setup(p => p.GetWeatherReport(citiesDAO, "", "", "")).ReturnsAsync(nullresponse);
            var controller = new Controllers.WeatherController(mock.Object, config.Object);

            //Act
            IActionResult result = await controller.GetWeatherReports(citiesDAO) as BadRequestResult;
            // to case and check for BadRequestResult

            //Assert
            Assert.IsInstanceOfType(result, typeof (BadRequestResult));

        }
    }
}
