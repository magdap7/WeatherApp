
using WeatherApp;


string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

Console.WriteLine("Welcome in program for Weather history of temperatures.!");

Console.WriteLine("Choose one of options:");
Console.WriteLine("M or m - mode for adding temperatures in memory");
Console.WriteLine("F or f - mode for adding temperatures in file");
Console.WriteLine("S or s - to stop adding and to show temperatures statistics");
Console.WriteLine("Q or q - to quit the program");

string option = Console.ReadLine().ToUpper();

    switch (option)
    {
        case "M":
            WeatherInMemory weatherMemory = new WeatherInMemory(currentDate);            
            Console.WriteLine("Write value, for example: 35,1");
            string lineToMemory = Console.ReadLine();
            while (lineToMemory.ToUpper() != "S")
            {
                try { weatherMemory.AddTemperature(lineToMemory); }
                catch (Exception ex) { Console.WriteLine($"Exeption catched: {ex.Message}"); }

                Console.WriteLine("Write next value or type S to see statictic.");
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
            while (lineToFile.ToUpper() != "S")
            {
                try { weatherFile.AddTemperature(lineToFile); }
                catch (Exception ex) { Console.WriteLine($"Exeption catched: {ex.Message}"); } 
            
                Console.WriteLine("Write next value or type S to see statictic.");
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







