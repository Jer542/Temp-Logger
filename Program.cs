using System;
using System.Collections.Generic;
using System.Linq;


class Program
{

    //list to store temperature logs
    static List<TemperatureLog> temperatureLogs = new List<TemperatureLog>();


    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            
            Console.WriteLine("Temperature Logger by Jeremy");
            Console.WriteLine("1. Log Temperature");
            Console.WriteLine("2. View Logs");
            Console.WriteLine("3. Analyze Data");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    LogTemperature();
                    break;
                case "2":
                    ViewLogs();
                    break;
                case "3":
                    AnalyzeData();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    // Allow users to log the temperatures
    static void LogTemperature()
    {

        Console.WriteLine("Enter temperature: ");
        double temperature = Convert.ToDouble(Console.ReadLine());
        DateTime timestamp = DateTime.Now;

        temperatureLogs.Add(new TemperatureLog(temperature, timestamp));
        Console.WriteLine("Temperature logged successfully " + temperature + " at " + timestamp);

    }

    // Allow users to view the temerature logged so far
    static void ViewLogs()
    {
        if (temperatureLogs.Count > 0) 
        {
            Console.WriteLine("Temperature Logs");
            foreach (var log in temperatureLogs)
            {
                Console.WriteLine("Temperature: " + log.Temperature + " at " + log.Timestamp);
            }
        }
        else
        {
            Console.WriteLine("No logs available as of " + DateTime.Now);
        }
    }

    // Allow users to analyze the data of logged temperatures
    static void AnalyzeData()
    {
        if (temperatureLogs.Count > 0)
        {
            double average = temperatureLogs.Average(log => log.Temperature);
            double max = temperatureLogs.Max(log => log.Temperature);
            double min = temperatureLogs.Min(log => log.Temperature);

            Console.WriteLine("Temperature Analysis");
            Console.WriteLine("Average Temperature: " + average);
            Console.WriteLine("Max Temperature: " + max);
            Console.WriteLine("Min Temperature: " + min);
        }
        else
        {
            Console.WriteLine("No logs available as of " + DateTime.Now);
        }
    }


}


//class for temperature logs
public class TemperatureLog
{
    //properties for temp log
    public double Temperature { get; set; }
    public DateTime Timestamp { get; set; }


    //constructor for temp log
    public TemperatureLog(double temperature, DateTime timestamp)
    {
        Temperature = temperature;
        Timestamp = timestamp;
    }
}