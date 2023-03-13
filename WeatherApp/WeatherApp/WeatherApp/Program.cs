
using WeatherApp;


string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

Console.WriteLine("Welcome in program for Weather history of temperatures.!");

Console.WriteLine("Choose one of options:");
Console.WriteLine("M - mode for adding temperatures in memory");
Console.WriteLine("F - mode for adding temperatures in file");
Console.WriteLine("S - to stop adding and to show temperatures statistics");
Console.WriteLine("Q - to quit the program");

string option = Console.ReadLine();
try
{
    switch (option)
    {
        case "M":
            WeatherInMemory weatherMemory = new WeatherInMemory(currentDate);
            Console.WriteLine("Write value, for example: 35,1");
            string lineToMemory = Console.ReadLine();
            while (lineToMemory != "S")
            {
                weatherMemory.AddTemperature(lineToMemory);
                Console.WriteLine("Write next value");
                lineToMemory = Console.ReadLine();
            }
            Statistics statFromMem = weatherMemory.GetStatistics();
            Console.WriteLine("Today: " + currentDate);
            Console.WriteLine(statFromMem);
            break;
        case "F":
            WeatherInFile weatherFile = new WeatherInFile(currentDate);
            Console.WriteLine("Write value, for example: 35,1");
            string lineToFile = Console.ReadLine();
            while (lineToFile != "S")
            {
                weatherFile.AddTemperature(lineToFile);
                Console.WriteLine("Write next value");
                lineToFile = Console.ReadLine();
            }
            Statistics statFromFile = weatherFile.GetStatistics();
            Console.WriteLine("Today: " + currentDate);
            Console.WriteLine(statFromFile);
            break;
        case "Q":
            Console.WriteLine("You are exiting this program.");
            break;
        default:
            Console.WriteLine("You din't choose any option.");
            break;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Exeption catched: {ex.Message}");
}


