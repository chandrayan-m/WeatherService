using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherService.Utilities
{
    public interface IServiceUtil<T>
    {
        Task<T> GetWeatherReportAsync(string fullAddress, string hostAddress);
    }
}
