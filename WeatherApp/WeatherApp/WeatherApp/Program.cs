
using System.Security.Cryptography.X509Certificates;
using WeatherApp;

Console.WriteLine("Welcome in program for Weather history of temperatures.!");
string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
WeatherInMemory weather = new WeatherInMemory(currentDate);

try
{
    weather.AddTemperature(10);
    weather.AddTemperature(12.4);
    weather.AddTemperature("-12");
    weather.AddTemperature(10.0);
}
catch (Exception ex)
{
    Console.WriteLine($"Exeption catched: {ex.Message}");
}


Statistics stat = weather.GetStatistics();

Console.WriteLine(currentDate);
Console.WriteLine(stat);