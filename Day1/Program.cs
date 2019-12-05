using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceCraft craft = new SpaceCraft();
            List<int> weights = craft.GetWeights();
            List<int> moduleFuel = craft.CalculateFuel(weights);
            int totalWeight = craft.AddFuel(moduleFuel);
            Console.WriteLine(totalWeight.ToString());
        }
    }
}
