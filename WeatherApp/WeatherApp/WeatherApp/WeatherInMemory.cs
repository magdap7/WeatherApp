
namespace WeatherApp
{
    public class WeatherInMemory : WeatherBase
    {
        private List<float> temperatures;
        protected override event TemperatureAddedDelegate TemperatureAdded;

        public WeatherInMemory(string date) : base(date)
        {
            temperatures = new List<float>();
            TemperatureAdded += PrintEvent;
        }

        public override void AddTemperature(float value)
        {
            if (value >= -50 && value <= 50)
            {
                this.temperatures.Add(value);
                if (this.TemperatureAdded != null)
                    this.TemperatureAdded(this, new EventArgs());
            }
            else
                throw new Exception("Temperature must be value between -50 and 50.");
        }

        public override Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();
            foreach (var item in temperatures)
                statistics.Add(item);
            return statistics;
        }

        public override void PrintEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Temperature value added to memory.\n");
        }
    }
}
