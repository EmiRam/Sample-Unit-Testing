using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestingSample.AggregatorInterface
{
    public interface IWeatherDataAggregator
    {
        int GetCityWeatherData(string cityName);
    }
}
