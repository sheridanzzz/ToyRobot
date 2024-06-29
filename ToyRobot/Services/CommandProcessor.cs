using ToyRobot.Models;

namespace ToyRobot.Services
{
    // The CommandProcessor class is responsible for interpreting and executing commands for the robot on the table.
    public class CommandProcessor
    {
        // Publicly accessible Robot property to allow state inspection in tests and other classes.
        public Robot Robot { get; private set; }
        private Table _table;

        // Constructor initializes the CommandProcessor with a specific table.
        public CommandProcessor(Table table)
        {
            this._table = table;
        }

        // Processes a string command and performs actions on the Robot based on the command.
        public void ProcessCommand(string command)
        {
            // Split the command into parts to identify the command type and its parameters.
            string[] parts = command.Split(' ');
            switch (parts[0])
            {
                case "PLACE":
                    // Ensure the PLACE command has the correct format and parameters.
                    if (parts.Length == 2)
                    {
                        var position = parts[1].Split(',');
                        if (position.Length == 3 &&
                            int.TryParse(position[0], out int x) &&
                            int.TryParse(position[1], out int y) &&
                            IsValidFacing(position[2]) &&
                            _table.IsValidPosition(x, y))
                        {
                            // Initialize Robot at specified position and facing.
                            Robot = new Robot(x, y, position[2]);
                        }
                        else
                        {
                            // Provide feedback if the PLACE command is invalid.
                            Console.WriteLine("Invalid PLACE command. Command ignored.");
                        }
                    }
                    else
                    {
                        // Provide feedback if the PLACE command format is incorrect.
                        Console.WriteLine("Invalid PLACE command format. Command ignored.");
                    }
                    break;
                case "MOVE":
                    // Ensure the Robot is placed on the table before processing the MOVE command.
                    if (Robot != null)
                    {
                        var newPosition = Robot.GetNextPosition();
                        // Check if the new position is valid and within the table boundaries.
                        if (_table.IsValidPosition(newPosition.X, newPosition.Y))
                        {
                            // Command the robot to move in its current facing direction.
                            Robot.Move();
                        }
                        else
                        {
                            // Provide feedback if the move would cause the robot to fall off the table.
                            Console.WriteLine("Move would cause the robot to fall off the table. Command ignored.");
                        }
                    }
                    else
                    {
                        // Provide feedback if the Robot is not placed on the table.
                        Console.WriteLine("Robot not placed on the table. Command ignored.");
                    }
                    break;
                case "LEFT":
                    // Ensure the Robot is placed on the table before processing the LEFT command.
                    if (Robot != null)
                    {
                        // Command the robot to rotate left.
                        Robot.Left();
                    }
                    else
                    {
                        // Provide feedback if the Robot is not placed on the table.
                        Console.WriteLine("Robot not placed on the table. Command ignored.");
                    }
                    break;
                case "RIGHT":
                    // Ensure the Robot is placed on the table before processing the RIGHT command.
                    if (Robot != null)
                    {
                        // Command the robot to rotate right.
                        Robot.Right();
                    }
                    else
                    {
                        // Provide feedback if the Robot is not placed on the table.
                        Console.WriteLine("Robot not placed on the table. Command ignored.");
                    }
                    break;
                case "REPORT":
                    // Ensure the Robot is placed on the table before processing the REPORT command.
                    if (Robot != null)
                    {
                        // Output the current position and facing of the robot.
                        Console.WriteLine(Robot.Report());
                    }
                    else
                    {
                        // Provide feedback if the Robot is not placed on the table.
                        Console.WriteLine("Robot not placed on the table. Command ignored.");
                    }
                    break;
                default:
                    // Provide feedback if an unrecognized command is entered.
                    Console.WriteLine("Invalid command. Command ignored.");
                    break;
            }
        }

        // Helper method to validate the facing direction.
        private bool IsValidFacing(string facing)
        {
            return facing == "NORTH" || facing == "SOUTH" || facing == "EAST" || facing == "WEST";
        }
    }
}