

namespace WeatherApp
{
    public class WeatherInFile : WeatherBase
    {
        private const string fileName = "temperatures.txt";
        protected override event TemperatureAddedDelegate TemperatureAdded;

        public WeatherInFile(string date) : base(date)
        {
            TemperatureAdded += PrintEvent;
        }

        public override void AddTemperature(float value)
        {
            if (value >= -50 && value <= 50)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(value);
                }
                if (this.TemperatureAdded != null)
                    this.TemperatureAdded(this, new EventArgs());
            }
            else
                throw new Exception("Temperature must be value between -50 and 50.");
        }

        public override Statistics GetStatistics()
        {
            if (File.Exists(fileName))
            {
                Statistics statistics = new Statistics();
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (float.TryParse(line, out float value))
                            statistics.Add(value);
                        else
                            throw new Exception("Invalid grade format in file {fileName}");
                        line = reader.ReadLine();
                    }
                }
                return statistics;
            }
            else
            {
                throw new Exception($"File {fileName} dosn't exist.");
            }
        }

        public override void PrintEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Temperature value added to file.\n");
        }
    }
}
