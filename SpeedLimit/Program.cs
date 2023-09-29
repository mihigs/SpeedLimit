using System.ComponentModel;

namespace SpeedLimit;

public class VariableSpeedLimit
{
    public double journeyTime(int journeyLength, int[] speedLimit)
    {
        // Validate journeyLength
        if (journeyLength < 1 || journeyLength > 100000)
        {
            throw new ArgumentException("journeyLength is outside the valid range.");
        }

        // Validate speedLimit array
        if (speedLimit.Length < 1 || speedLimit.Length > 50)
        {
            throw new ArgumentException("speedLimit array length is outside the valid range.");
        }
        // Validate speed limit values
        foreach (int limit in speedLimit)
        {
            if (limit < 1 || limit > 100)
            {
                throw new ArgumentException("Invalid speed limit value in the array.");
            }
        }

        double totalTime = 0;
        int speedLimitIndex = 0; // Index to keep track of the current speed limit

        // Iterate through the journey in segments
        // Each loop represents a segment
        for (int distanceRemaining = journeyLength; distanceRemaining > 0;)
        {
            // Calculate the time it takes to travel the current segment at the current speed limit
            int currentSpeedLimit = speedLimit[speedLimitIndex];
            int distanceInSegment = Math.Min(distanceRemaining, currentSpeedLimit); // Distance in this segment
            double timeInSegment = (double)distanceInSegment / currentSpeedLimit;

            // Add the time for this segment to the total time
            totalTime += timeInSegment;

            // Reduce the remaining distance by the distance covered in this segment
            distanceRemaining -= distanceInSegment;

            // Move to the next speed limit (loops back to the beginning if necessary)
            speedLimitIndex = (speedLimitIndex + 1) % speedLimit.Length;
        }

        return totalTime;
    }
}

public class Program
{
    public static void Main()
    {
        // Create an instance of the VariableSpeedLimit class
        VariableSpeedLimit speedLimitCalculator = new VariableSpeedLimit();

        // Define the journey length and speed limits
        int journeyLength = 9839; 
        int[] speedLimits = { 45, 90, 13, 4, 81, 50, 81, 10, 64, 86, 69 };

        // Call the journeyTime method to calculate the time
        double totalTime = speedLimitCalculator.journeyTime(journeyLength, speedLimits);

        // Display the result
        Console.WriteLine($"Total time to complete the journey: {totalTime} units of time");
    }
}


