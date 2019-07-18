# WeatherService
A Weather Service API written in ASP.NET Core which retrieves daily information for number of cities in the world from Open API-OpenWeatherMap and stores the city wise daily report in the local Log file.

The Input for the API is a JSON file containing cityId and cityName of various cities across the world. 

It stores the city wise daily report at the local file path, which is configurable in the appsetting.json file.

Build & Execut Steps:

using Docker: 



The API can be tested using API testing tools like SoapUI or Postman. 

Sample JSON input for testing.
[
  {
    "cityId: 2643741
    "cityName: "London"
  },
    {
    "cityId: 2988507
    "cityName: "Paris"
  },
  {
    "cityId: 2964574
    "cityName: "Dublin"
  },
  {
    "cityId: 1273294
    "cityName: "Delhi"
  },
  {
    "cityId: 1275339
    "cityName: "Mumbai"
  }

]
