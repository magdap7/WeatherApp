
namespace WeatherApp
{
    public abstract class WeatherBase : IWeather
    {
        protected delegate void TemperatureAddedDelegate(object sender, EventArgs args);
        protected abstract event TemperatureAddedDelegate TemperatureAdded;

        public string Date { get; private set; }

        public WeatherBase(string date)
        {
            Date = date;
        }

        public void AddTemperature(string value)
        {
            if (float.TryParse(value, out float result))
                this.AddTemperature(result);
            else
                throw new Exception("Temperature must be integer, float or double value.");
        }

        public abstract void AddTemperature(float value);

        public abstract Statistics GetStatistics();

        public abstract void PrintEvent(object sender, EventArgs args);
    }
}
