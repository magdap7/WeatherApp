
namespace WeatherApp
{
    public interface IWeather
    {
        string Date { get; }

        void AddTemperature(string value);
        void AddTemperature(double value);
        void AddTemperature(int value);
        void AddTemperature(float value);

        Statistics GetStatistics();
    }
}
