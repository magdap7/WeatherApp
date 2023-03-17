
namespace WeatherApp
{
    public interface IWeather
    {
        string Date { get; }

        void AddTemperature(string value);

        void AddTemperature(float value);

        Statistics GetStatistics();
    }
}
