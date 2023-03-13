using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public abstract class WeatherBase : IWeather
    {
        public delegate void TemperatureAddedDelegate(object sender, EventArgs args);
        public abstract event TemperatureAddedDelegate TemperatureAdded;

        public  string Date { get; private set; }
        public abstract string AverageTemperature { get; }

        public WeatherBase(string date)
        {
            Date=date;
        }

        public abstract void AddTemperature(string value);
        public abstract void AddTemperature(double value);
        public abstract void AddTemperature(int value);
        public abstract void AddTemperature(float value);

        public abstract Statistics GetStatistics();
    }
}
