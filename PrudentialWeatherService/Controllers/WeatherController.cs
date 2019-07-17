using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using PrudentialWeatherService.Model;
using WeatherService.Repository.Middleware;
using WeatherService.Repository.Entity;
using Microsoft.Extensions.Options;
using WeatherService.Repository;

namespace PrudentialWeatherService.Controllers
{
    
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private ConfigurationItem configItem { get; set; }

        private readonly IMiddleware _middleware;

        public WeatherController(IMiddleware middleware, IOptions<ConfigurationItem> settings )
        {
            this._middleware = middleware;
            configItem = settings.Value;
            
        }
        [Route("api/weather")]
        [HttpPost]
        public async Task<IActionResult> GetWeatherReports(IEnumerable<CityDAO> cities)
        {
            if (cities != null)
            {
                string path = configItem.localFilePath;
                string appId = configItem.appId;
                string baseAddress = configItem.baseAddress;
                var response = await _middleware.GetWeatherReport(cities,  appId, baseAddress, path);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
        

    }
}
