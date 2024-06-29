namespace ToyRobot.Models
{
    // The Robot class represents a robot moving on a grid.
    public class Robot
    {
        // Properties to store the X and Y coordinates on the grid, and the direction the robot is facing.
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Facing { get; private set; }

        // Constructor to initialize the robot with a specific position and facing direction.
        public Robot(int x, int y, string facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        // Move method to update the robot's position based on its current facing.
        public void Move()
        {
            var nextPosition = GetNextPosition();
            X = nextPosition.X;
            Y = nextPosition.Y;
        }

        // Get the next position based on the current facing direction.
        public (int X, int Y) GetNextPosition()
        {
            int newX = X, newY = Y;
            switch (Facing)
            {
                case "NORTH":
                    newY += 1;
                    break;
                case "SOUTH":
                    newY -= 1;
                    break;
                case "EAST":
                    newX += 1;
                    break;
                case "WEST":
                    newX -= 1;
                    break;
            }
            return (newX, newY);
        }

        // Left method to rotate the robot 90 degrees to the left.
        public void Left()
        {
            Facing = Facing switch
            {
                "NORTH" => "WEST",
                "WEST" => "SOUTH",
                "SOUTH" => "EAST",
                "EAST" => "NORTH",
                _ => Facing
            };
        }

        // Right method to rotate the robot 90 degrees to the right.
        public void Right()
        {
            Facing = Facing switch
            {
                "NORTH" => "EAST",
                "EAST" => "SOUTH",
                "SOUTH" => "WEST",
                "WEST" => "NORTH",
                _ => Facing
            };
        }

        // Report method to return the current position and facing of the robot as a string.
        public string Report()
        {
            return $"{X},{Y},{Facing}";
        }
    }
}