
namespace WeatherApp
{
    public class Statistics
    {
        public float MaxValue;
        public float MinValue;
        public float SumOfValues;
        public int CountOfElements;

        public Statistics()
        {
            CountOfElements = 0;
            SumOfValues = 0.0f;
            MaxValue = float.MinValue;
            MinValue = float.MaxValue;
        }

        public double AverageValue
        {
            get
            {
                return SumOfValues / CountOfElements;
            }
        }

        public void Add(float value)
        {
            SumOfValues += value;
            CountOfElements += 1;
            MinValue = Math.Min(value, MinValue);
            MaxValue = Math.Max(value, MaxValue);
        }

        public override string ToString()
        {
            string result = "STATISTICS OF TEMPERATURES TODAY:\n";
            result = result + $"Min: {this.MinValue}\n";
            result = result + $"Max: {this.MaxValue}\n";
            result = result + $"Sum: {this.SumOfValues}\n";
            result = result + $"Count: {this.CountOfElements}\n";
            result = result + $"Average: {this.AverageValue.ToString("##.##")}\n";
            return result;
        }
    }
}
