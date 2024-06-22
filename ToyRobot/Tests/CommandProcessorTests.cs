using NUnit.Framework;
using NUnit.Framework.Legacy;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor processor;
        private Table table;

        // Setup method runs before each test to initialize the CommandProcessor with a 5x5 table.
        [SetUp]
        public void Setup()
        {
            table = new Table(5, 5);
            processor = new CommandProcessor(table);
        }

        // Test to verify that the PLACE command correctly initializes the Robot.
        [Test]
        public void ProcessCommand_Place_ValidPosition_PlacesRobot()
        {
            // Act
            processor.ProcessCommand("PLACE 0,0,NORTH");

            // Assert
            ClassicAssert.IsNotNull(processor.Robot);
            ClassicAssert.AreEqual(0, processor.Robot.X);
            ClassicAssert.AreEqual(0, processor.Robot.Y);
            ClassicAssert.AreEqual("NORTH", processor.Robot.Facing);
        }

        // Test to verify that the MOVE command correctly moves the Robot.
        [Test]
        public void ProcessCommand_Move_ValidCommand_MovesRobotNorth()
        {
            // Arrange
            processor.ProcessCommand("PLACE 0,0,NORTH");

            // Act
            processor.ProcessCommand("MOVE");

            // Assert
            ClassicAssert.AreEqual(1, processor.Robot.Y);
        }

        // Test to verify that the REPORT command outputs the correct position and facing.
        [Test]
        public void ProcessCommand_Report_OutputsCorrectPosition()
        {
            // Arrange
            processor.ProcessCommand("PLACE 1,2,EAST");
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                processor.ProcessCommand("REPORT");

                // Assert
                ClassicAssert.AreEqual("1,2,EAST", sw.ToString().Trim());
            }
        }
    }
}

