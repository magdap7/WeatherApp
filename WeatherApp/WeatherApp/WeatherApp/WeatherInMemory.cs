﻿
namespace WeatherApp
{
    public class WeatherInMemory : WeatherBase
    {
        private List<float> m_list;
        public WeatherInMemory(string date) : base(date)
        {
            m_list = new List<float>();
            TemperatureAdded += PrintEvent;
        }

        public override event TemperatureAddedDelegate TemperatureAdded;

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
        public override void PrintEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Temperature value added to memory.");
        }
    }
}
