using System;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            ManhattanDistance manhattanDistance = new ManhattanDistance();
            List<List<string>> locations = manhattanDistance.GetLocations("wirestest.txt");
            int[] tests = new[] { 6, 159, 135 };
            bool passed = manhattanDistance.CrossLocation(locations, tests);
            if (passed)
            {
                List<List<string>> locations2 = manhattanDistance.GetLocations("wires.txt");
                int result = manhattanDistance.CrossLocation(locations2);
                Console.WriteLine($"result: {result}");
            }
            else
            {
                Console.WriteLine("failed");
            }
        }
    }
}
