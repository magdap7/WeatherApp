using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public abstract class WeatherBase : IWeather
    {
        protected delegate void TemperatureAddedDelegate(object sender, EventArgs args);
        protected abstract event TemperatureAddedDelegate TemperatureAdded;

        public  string Date { get; private set; }

        public WeatherBase(string date)
        {
            Date=date;
        }
        public void AddTemperature(string value)
        {
            if (int.TryParse(value, out int resultInt))
                this.AddTemperature(resultInt);
            else if (double.TryParse(value, out double resultDouble))
                this.AddTemperature(resultDouble);
            else if (float.TryParse(value, out float resultFloat))
                this.AddTemperature(resultFloat);
            else
                throw new Exception("Temperature must be integer, float or double value.");
        }
        public void AddTemperature(double value)
        {
            float result = (float)value;
            this.AddTemperature(result);
        }
        public void AddTemperature(int value)
        {
            float result = (float)value;
            this.AddTemperature(result);
        }

        public abstract void AddTemperature(float value);
        public abstract Statistics GetStatistics();
        public abstract void PrintEvent(object sender, EventArgs args);
    }
}
