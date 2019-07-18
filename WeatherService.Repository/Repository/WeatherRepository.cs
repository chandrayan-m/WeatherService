using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Utilities;

namespace WeatherService.Repository.Repository
{
    public class WeatherRepository : ServiceUtil<OpenWeatherReport>, IWeatherRepository
    {

        public WeatherRepository() : base()
        {
           
        }

        public async Task<OpenWeatherReport> GetWeatherReport(int cityId, string appId, string hostURL)
        {
            return await GetWeatherReportAsync($"weather?id={cityId}&appid={appId}" , hostURL);
        }
    }
}
