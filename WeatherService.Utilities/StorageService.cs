using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace WeatherService.Utilities
{
    public static class StorageService
    {
        /// <summary>
        /// Drops file to specified Local Path
        /// </summary>
        /// <param name="report"></param>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        public static void LogDailyWeatherReport(JObject report, string fileName, string path)
        {
            Directory.CreateDirectory(path);
            string filePath = $"{path}\\{fileName}.txt";
            File.WriteAllText(filePath, report.ToString());
        }

    }
}
