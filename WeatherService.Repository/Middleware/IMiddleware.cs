using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Repository.Middleware
{
    public interface IMiddleware
    {
        Task<IList<OpenWeatherReport>> GetWeatherReport(IEnumerable<Entity.CityDAO> cities, string s1, string s2, string s3);
    }
}
