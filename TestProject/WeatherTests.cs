using Moq;
using System;
using UnitTestingSample.AggregatorInterface;
using UnitTestingSample.Utilities;
using Xunit;

namespace TestProject
{
    public class WeatherTests
    {

        [Fact]
        public void GetWeather_APIKnowsCityAndDegreeIsGreaterThan0_ReturnsDegreeAsInt()
        {
            //arrange
            var weatherDataAggregator = new Mock<IWeatherDataAggregator>();
            var weather = new Weather(weatherDataAggregator.Object);

            weatherDataAggregator.Setup(m => m.GetCityWeatherData(It.IsAny<string>())).Returns(2);

            //act
            var degree = weather.GetWeather("ACity");

            //assert
            Assert.True(2 == degree);
        }


        [Fact]
        public void GetWeather_APIDoesNotKnowCity_NotSupportedException()
        {
            var weatherDataAggregator = new Mock<IWeatherDataAggregator>();
            var weather = new Weather(weatherDataAggregator.Object);

            weatherDataAggregator.Setup(m => m.GetCityWeatherData(It.IsAny<string>())).Returns(-1);

            Assert.Throws<NotSupportedException>(() => weather.GetWeather("ACity"));
        }

        [Fact]
        public void GetWeather_APIKnowsCityAndDegreeIs0_ReturnsDegreeAsInt()
        {
            var weatherDataAggregator = new Mock<IWeatherDataAggregator>();
            var weather = new Weather(weatherDataAggregator.Object);

            weatherDataAggregator.Setup(m => m.GetCityWeatherData(It.IsAny<string>())).Returns(0);

            var degree = weather.GetWeather("ACity");

            Assert.True(0 == degree);
        }

        [Fact]
        public void GetWeather_APIKnowsCity_CityNameGetsPassedToAPICall()
        {
            var weatherDataAggregator = new Mock<IWeatherDataAggregator>();
            var weather = new Weather(weatherDataAggregator.Object);

            weather.GetWeather("ACity");

            weatherDataAggregator.Verify(m => m.GetCityWeatherData("ACity"));
        }
    }
}
