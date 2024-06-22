using NUnit.Framework;
using NUnit.Framework.Legacy;
using ToyRobot.Models;

namespace ToyRobot.Tests
{
    [TestFixture]
    public class RobotTests
    {
        [Test]
        public void Move_Forward_North_Increases_Y()
        {
            // Arrange
            var robot = new Robot(0, 0, "NORTH");

            // Act
            robot.Move();

            // Assert
            ClassicAssert.AreEqual(1, robot.Y);
        }

        [Test]
        public void Rotate_Left_From_North_Faces_West()
        {
            // Arrange
            var robot = new Robot(0, 0, "NORTH");

            // Act
            robot.Left();

            // Assert
            ClassicAssert.AreEqual("WEST", robot.Facing);
        }

        [Test]
        public void Report_Returns_Correct_Position_And_Facing()
        {
            // Arrange
            var robot = new Robot(1, 2, "EAST");

            // Act
            var result = robot.Report();

            // Assert
            ClassicAssert.AreEqual("1,2,EAST", result);
        }
    }
}