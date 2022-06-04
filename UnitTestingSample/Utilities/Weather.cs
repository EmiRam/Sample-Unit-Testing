using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingSample.Aggregator;
using UnitTestingSample.AggregatorInterface;

namespace UnitTestingSample.Utilities
{
    public class Weather
    {
        private IWeatherDataAggregator _weatherDataAggregator;

        public Weather()
        {
            _weatherDataAggregator = new WeatherDataAggregator();
        }

        public Weather(IWeatherDataAggregator weatherDataAggregator)
        {
            _weatherDataAggregator = weatherDataAggregator;
        }


        // this function throws an exception if the api doesn't know the city, otherwise it will return the city weather
        public int GetWeather(string cityName)
        {

            int degree = _weatherDataAggregator.GetCityWeatherData(cityName);

            if (degree < 0)
            {
                throw new NotSupportedException("Unknown city");
            }
            return degree;
        }
    }
}
