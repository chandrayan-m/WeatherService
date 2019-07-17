using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Utilities
{
    public class ServiceUtil<T> : IServiceUtil<T>
    {
        private readonly string _mediaType = "application/json";
        private readonly string _hostAddress;

        //public ServiceUtil(string hostName)
        //{
        //    this._hostAddress = hostName;
        //    this._mediaType = "application/json";
        //}

        public async Task<T> GetWeatherReportAsync(string fullAddress, string hostAddress)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(hostAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_mediaType));
                HttpResponseMessage response = await client.GetAsync(fullAddress).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    return default(T);
                }
                return await response.Content.ReadAsAsync<T>().ConfigureAwait(false);

            }

        }

    }
}
