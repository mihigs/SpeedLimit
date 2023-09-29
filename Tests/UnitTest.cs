using NUnit.Framework;
using SpeedLimit;

namespace Tests
{

    [TestFixture]
    public class VariableSpeedLimitTests
    {
        [Test]
        public void TestJourneyTime_Example1() //Example 1
        {
            // Arrange
            VariableSpeedLimit speedLimitCalculator = new VariableSpeedLimit();
            int journeyLength = 100;
            int[] speedLimits = { 50 };

            // Act
            double totalTime = speedLimitCalculator.journeyTime(journeyLength, speedLimits);

            // Assert
            Assert.That(totalTime, Is.EqualTo(2.0).Within(1E-9)); // Expected result is 2.0, with a tolerance of 1E-9
        }

        [Test]
        public void TestJourneyTime_Example3() //Example 3
        {
            // Arrange
            VariableSpeedLimit speedLimitCalculator = new VariableSpeedLimit();
            int journeyLength = 1000;
            int[] speedLimits = { 50, 40, 30, 40, 50 };

            // Act
            double totalTime = speedLimitCalculator.journeyTime(journeyLength, speedLimits);

            // Assert
            Assert.That(totalTime, Is.EqualTo(24.0).Within(1E-9)); // Expected result is 24.0, with a tolerance of 1E-9
        }

        [Test]
        public void TestJourneyTime_Example5() //Example 5
        {
            // Arrange
            VariableSpeedLimit speedLimitCalculator = new VariableSpeedLimit();
            int journeyLength = 17216;
            int[] speedLimits = { 26, 30, 62, 55, 51, 56, 58, 4, 60, 23, 31 };

            // Act
            double totalTime = speedLimitCalculator.journeyTime(journeyLength, speedLimits);

            // Assert
            Assert.That(totalTime, Is.EqualTo(415.03333333333336).Within(1E-9)); // Expected result is 415.03333333333336, with a tolerance of 1E-9
        }
    }
}