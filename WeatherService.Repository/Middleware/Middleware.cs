using System;
using System.Collections.Generic;
using System.Text;
using WeatherService.Repository.Repository;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using WeatherService.Utilities;

namespace WeatherService.Repository.Middleware
{
    public class Middleware : IMiddleware
    {
        private readonly IWeatherRepository _weatherRepository;
        //private readonly IMapper _mapper;
        //private readonly string _appId;
        //private readonly string _baseAddress;
        //private readonly string _localFilePath;
        public Middleware(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<IList<OpenWeatherReport>> GetWeatherReport(IEnumerable<Entity.CityDAO> cities , string appId, string baseAddress, string localFilePath)
        {
            var citiesReport = new List<Task<OpenWeatherReport>>();
            foreach (var city in cities)
            {
                var response = _weatherRepository.GetWeatherReport(city.cityId, appId, baseAddress);
                citiesReport.Add(response);
            }
            OpenWeatherReport[] report = await Task.WhenAll(citiesReport);
            LogWeatherReport(report, localFilePath);
            return report;
        }

        private void LogWeatherReport(OpenWeatherReport[] reports, string localFilePath)
        {
            {

                foreach (var report in reports)
                {
                    var json = (JObject)JToken.FromObject(report);
                    string cityName = $"{report.name}";
                    string fileName = cityName + "_" + DateTime.Now.ToString("MMddyyyy");
                    StorageService.LogDailyWeatherReport(json, fileName, localFilePath);
                }
            }
        }
    }
}
