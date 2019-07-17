using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace WeatherService.Utilities
{
    public static class StorageService
    {
        
        public static void LogDailyWeatherReport(JObject report, string fileName, string path)
        {
            Directory.CreateDirectory(path);
            string filePath = $"{path}\\{fileName}.txt";
            File.WriteAllText(filePath, report.ToString());
        }

    }
}
