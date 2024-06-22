using NUnit.Framework;
using NUnit.Framework.Legacy;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor _processor;
        private Table _table;

        // Setup method runs before each test to initialize the CommandProcessor with a 5x5 table.
        [SetUp]
        public void Setup()
        {
            _table = new Table(5, 5);
            _processor = new CommandProcessor(_table);
        }

        // Test to verify that the PLACE command correctly initializes the Robot.
        [Test]
        public void ProcessCommand_Place_ValidPosition_PlacesRobot()
        {
            // Act
            _processor.ProcessCommand("PLACE 0,0,NORTH");

            // Assert
            ClassicAssert.IsNotNull(_processor.Robot);
            ClassicAssert.AreEqual(0, _processor.Robot.X);
            ClassicAssert.AreEqual(0, _processor.Robot.Y);
            ClassicAssert.AreEqual("NORTH", _processor.Robot.Facing);
        }

        // Test to verify that the MOVE command correctly moves the Robot.
        [Test]
        public void ProcessCommand_Move_ValidCommand_MovesRobotNorth()
        {
            // Arrange
            _processor.ProcessCommand("PLACE 0,0,NORTH");

            // Act
            _processor.ProcessCommand("MOVE");

            // Assert
            ClassicAssert.AreEqual(1, _processor.Robot.Y);
        }

        // Test to verify that the REPORT command outputs the correct position and facing.
        [Test]
        public void ProcessCommand_Report_OutputsCorrectPosition()
        {
            // Arrange
            _processor.ProcessCommand("PLACE 1,2,EAST");
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                _processor.ProcessCommand("REPORT");

                // Assert
                ClassicAssert.AreEqual("1,2,EAST", sw.ToString().Trim());
            }
        }
    }
}

