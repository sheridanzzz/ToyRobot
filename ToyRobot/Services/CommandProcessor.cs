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
            string[] parts = command.Split(' ');
            switch (parts[0])
            {
                case "PLACE":
                    if (parts.Length == 2)
                    {
                        var position = parts[1].Split(',');
                        if (position.Length == 3 &&
                            int.TryParse(position[0], out int x) &&
                            int.TryParse(position[1], out int y) &&
                            IsValidFacing(position[2]) &&
                            _table.IsValidPosition(x, y))
                        {
                            Robot = new Robot(x, y, position[2]);  // Initialize Robot at specified position and facing.
                        }
                    }
                    break;
                case "MOVE":
                    if (Robot != null)
                    {
                        var newPosition = Robot.GetNextPosition();
                        if (_table.IsValidPosition(newPosition.X, newPosition.Y))
                        {
                            Robot.Move();  // Command the robot to move in its current facing direction.
                        }
                    }
                    break;
                case "LEFT":
                    Robot?.Left();  // Command the robot to rotate left.
                    break;
                case "RIGHT":
                    Robot?.Right();  // Command the robot to rotate right.
                    break;
                case "REPORT":
                    if (Robot != null)
                    {
                        Console.WriteLine(Robot.Report());  // Output the current position and facing of the robot.
                    }
                    break;
            }
        }

        private bool IsValidFacing(string facing)
        {
            return facing == "NORTH" || facing == "SOUTH" || facing == "EAST" || facing == "WEST";
        }
    }
}