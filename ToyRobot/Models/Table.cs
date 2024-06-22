namespace ToyRobot.Models
{
    // The Table class represents the tabletop environment where the robot moves.
    public class Table
    {
        // Properties to store the dimensions of the table.
        public int Width { get; }
        public int Height { get; }

        // Constructor to initialize the table with specific dimensions.
        public Table(int width, int height)
        {
            Width = width;
            Height = height;
        }

        // IsValidPosition method checks if a given position (x, y) is within the bounds of the table.
        public bool IsValidPosition(int x, int y)
        {
            // Return true if the position is within the table boundaries; otherwise, return false.
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}

