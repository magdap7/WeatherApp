
using WeatherApp;


string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
WriteLineColor(ConsoleColor.Green, "WELCOME IN MY PROGRAM FOR WEATHER STATISTICS.!\n");
Console.WriteLine("Choose one of the following options:\n");

Console.WriteLine("M or m - mode for adding temperatures in memory");
Console.WriteLine("F or f - mode for adding temperatures in file");
Console.WriteLine("S or s - to stop adding and to show temperatures statistics and quit the program");
Console.WriteLine("\n");

string option = Console.ReadLine().ToUpper();
switch (option)
{
    case "M":
        AddValuesToMemory(currentDate);
        break;
    case "F":
        AddValuesToFile(currentDate);
        break;
    case "S":
        WriteLineColor(ConsoleColor.Red, "You don't have data for statistics.");
        break;
    default:
        WriteLineColor(ConsoleColor.Red, "You din't choose any option.");
        break;
}

 static void WriteLineColor(ConsoleColor color, string text)
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}

static void AddValuesToMemory(string currentDate)
{   
    WeatherInMemory weatherMemory = new WeatherInMemory(currentDate);

    WriteLineColor(ConsoleColor.Green, "Write value, for example: 35,1");
    string lineToMemory = Console.ReadLine();
    while (lineToMemory.ToUpper() != "S")
    {
        try
        { weatherMemory.AddTemperature(lineToMemory); }
        catch (Exception ex)
        { WriteLineColor(ConsoleColor.Red, $"Exeption catched: {ex.Message}\n"); }

        WriteLineColor(ConsoleColor.Green, "Write next value or type S to see statictic.");
        lineToMemory = Console.ReadLine();
    }

    try
    {
        Statistics statFromMem = weatherMemory.GetStatistics();
        WriteLineColor(ConsoleColor.DarkMagenta, "\nTODAY: " + currentDate);
        WriteLineColor(ConsoleColor.Blue, statFromMem.ToString());
    }
    catch (Exception ex)
    { WriteLineColor(ConsoleColor.Red, $"Exeption catched: {ex.Message}\n"); }
}

static void AddValuesToFile(string currentDate)
{
    WeatherInFile weatherFile = new WeatherInFile(currentDate);

    WriteLineColor(ConsoleColor.Green, "Write value, for example: 35,1");
    string lineToFile = Console.ReadLine();
    while (lineToFile.ToUpper() != "S")
    {
        try { weatherFile.AddTemperature(lineToFile); }
        catch (Exception ex)
        { WriteLineColor(ConsoleColor.Red, $"Exeption catched: {ex.Message}\n"); }

        WriteLineColor(ConsoleColor.Green, "Write next value or type S to see statictic.");
        lineToFile = Console.ReadLine();
    }

    try
    {
        Statistics statFromFile = weatherFile.GetStatistics();
        WriteLineColor(ConsoleColor.DarkMagenta, "\nTODAY: " + currentDate);
        WriteLineColor(ConsoleColor.Blue, statFromFile.ToString());
    }
    catch (Exception ex)
    { WriteLineColor(ConsoleColor.Red, $"Exeption catched: {ex.Message}\n"); }

}





