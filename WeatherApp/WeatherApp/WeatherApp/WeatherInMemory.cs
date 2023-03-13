using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherInMemory : WeatherBase
    {
        private List<float> m_list;
        public WeatherInMemory(string date) : base(date)
        {
            m_list = new List<float>();
        }


        public override string AverageTemperature => throw new NotImplementedException();
        public override event TemperatureAddedDelegate TemperatureAdded;

        public override void AddTemperature(string value)
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
        public override void AddTemperature(double value)
        {
            float result = (float)value;
            this.AddTemperature(result);
        }
        public override void AddTemperature(int value)
        {
            float result = (float)value;
            this.AddTemperature(result);
        }
        public override void AddTemperature(float value)
        {
            if (value>=-50 && value<=50)
            {
                this.m_list.Add(value);
                if (this.TemperatureAdded != null)
                    this.TemperatureAdded(this, new EventArgs());
            }
            else
                throw new Exception("Temperature must be value between -50 and 50.");
        }

        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics(m_list);
            result.CountStatistics();
            return result;
        }
    }
}
