namespace WeatherApp.Tests
{
    public class Tests
    {
        float[] tabOfTestValues = new float[] { -10, 10, 13.3f };

        [Test]
        public void InMemoryTest()
        {
            WeatherInMemory weatherMemory = new WeatherInMemory(DateTime.UtcNow.ToString("yyyy-MM-dd"));
            float sum = 0;
            for (int i = 0; i < tabOfTestValues.Length; i++)
            {
                weatherMemory.AddTemperature(tabOfTestValues[i]);
                sum += tabOfTestValues[i];
            }
            Statistics statFromMem = weatherMemory.GetStatistics();
            Assert.AreEqual(sum, statFromMem.Sum);
            Assert.AreEqual(tabOfTestValues.Length, statFromMem.Count);
        }

        [Test]
        public void InFileTest()
        {
            WeatherInFile weatherFile = new WeatherInFile(DateTime.UtcNow.ToString("yyyy-MM-dd"));
            weatherFile.AddTemperature(0);
            Statistics statFromFile = weatherFile.GetStatistics();
            float sum = 0;
            for (int i = 0; i < tabOfTestValues.Length; i++)
            {
                weatherFile.AddTemperature(tabOfTestValues[i]);
                sum += tabOfTestValues[i];
            }
            Statistics statFromFile1 = weatherFile.GetStatistics();
            Assert.AreEqual(statFromFile.Sum + sum, statFromFile1.Sum);
            Assert.AreEqual(statFromFile.Count + tabOfTestValues.Length, statFromFile1.Count);
        }
       
    }
}