
namespace WeatherApp
{
    public class WeatherInMemory : WeatherBase
    {
        private List<float> _Temperatures;
        public WeatherInMemory(string date) : base(date)
        {
            _Temperatures = new List<float>();
            TemperatureAdded += PrintEvent;
        }

        protected override event TemperatureAddedDelegate TemperatureAdded;

        public override void AddTemperature(float value)
        {
            if (value>=-50 && value<=50)
            {
                this._Temperatures.Add(value);
                if (this.TemperatureAdded != null)
                    this.TemperatureAdded(this, new EventArgs());
            }
            else
                throw new Exception("Temperature must be value between -50 and 50.");
        }

        public override Statistics GetStatistics()
        {
            if (_Temperatures.Count > 0)
            {
                Statistics result = new Statistics(_Temperatures);
                result.CountStatistics();
                return result;
            }
            else
            {
                throw new Exception("The list of temperature values is empty.");
            }
            
        }
        public override void PrintEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Temperature value added to memory.\n");
        }
    }
}
