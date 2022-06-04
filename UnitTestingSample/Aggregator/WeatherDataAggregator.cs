using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnitTestingSample.AggregatorInterface;

namespace UnitTestingSample.Aggregator
{
    public class WeatherDataAggregator : IWeatherDataAggregator
    {
        private HttpClient _client;
        private Uri _uri;

        public WeatherDataAggregator()
        {
            _client = new HttpClient();
            _uri = new Uri("https://www.fakeApi.ca/getWeather");
        }

        public int GetCityWeatherData(string cityName)
        {
            _client.BaseAddress = _uri;
            string urlParameters = "?city=" + cityName;

            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync(urlParameters).Result;
            return int.Parse(response.Content.ReadAsStringAsync().Result);
        }
    }
}
