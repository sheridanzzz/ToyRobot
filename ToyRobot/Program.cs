using ToyRobot.Models;
using ToyRobot.Services;


class Program
{
    static void Main(string[] args)
    {
        Table table = new Table(5, 5); // Create a 5x5 table.
        CommandProcessor processor = new CommandProcessor(table); // Initialize the command processor with the table.

        Console.WriteLine("Toy Robot Simulator");
        Console.WriteLine("Enter commands, or type 'EXIT' to finish:");

        string command;
        while ((command = Console.ReadLine()) != "EXIT")
        {
            processor.ProcessCommand(command); // Process each command entered by the user until 'EXIT' is typed.
        }
    }
}