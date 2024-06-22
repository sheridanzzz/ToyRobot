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
            switch (Facing)
            {
                case "NORTH":
                    Y += 1; // Move the robot one unit north.
                    break;
                case "SOUTH":
                    Y -= 1; // Move the robot one unit south.
                    break;
                case "EAST":
                    X += 1; // Move the robot one unit east.
                    break;
                case "WEST":
                    X -= 1; // Move the robot one unit west.
                    break;
            }
        }

        // Left method to rotate the robot 90 degrees to the left.
        public void Left()
        {
            Facing = Facing switch
            {
                "NORTH" => "WEST", // North to West
                "WEST" => "SOUTH", // West to South
                "SOUTH" => "EAST", // South to East
                "EAST" => "NORTH", // East to North
                _ => Facing
            };
        }

        // Right method to rotate the robot 90 degrees to the right.
        public void Right()
        {
            Facing = Facing switch
            {
                "NORTH" => "EAST", // North to East
                "EAST" => "SOUTH", // East to South
                "SOUTH" => "WEST", // South to West
                "WEST" => "NORTH", // West to North
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

