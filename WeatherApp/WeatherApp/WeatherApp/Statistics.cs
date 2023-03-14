using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average { get; private set; }

        private List<float> _Temperatures;
        public Statistics(List<float> temperatures)
        {
            this._Temperatures = temperatures;
        }
        public void CountStatistics()
        {
            this.Min = this._Temperatures.Min();
            this.Max = this._Temperatures.Max();
            this.Sum = this._Temperatures.Sum();
            this.Count = this._Temperatures.Count();
            this.Average = this._Temperatures.Average();
        }
        public override string ToString()
        {
            string result = "STATISTICS OF TEMPERATURES TODAY:\n";
            result = result + $"Min: {this.Min}\n";
            result = result + $"Max: {this.Max}\n";
            result = result + $"Sum: {this.Sum}\n";
            result = result + $"Count: {this.Count}\n";
            result = result + $"Average: {this.Average}\n";
            return result;
        }
    }
}
