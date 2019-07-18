using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Utilities
{
    public class ServiceUtil<T> : IServiceUtil<T>
    {
        private const string _mediaType = "application/json";

        /// <summary>
        /// Retrieves Weather Report from OpenWeatherMap API
        /// </summary>
        /// <param name="fullAddress"></param>
        /// <param name="hostAddress"></param>
        /// <returns></returns>
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
