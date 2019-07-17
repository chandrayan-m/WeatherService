using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Repository.Repository
{
    public interface IWeatherRepository
    {
        Task<OpenWeatherReport> GetWeatherReport(int id, string s1, string s2);
    }
}
