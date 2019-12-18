using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceCraft craft = new SpaceCraft();
            List<int> weights = craft.GetWeights("Modules.txt");
            List<int> moduleFuel = craft.CalculateFuel(weights);
            int totalWeight = craft.AddFuel(moduleFuel);
            Console.WriteLine(totalWeight.ToString());
            List<int> weights2 = craft.GetWeights("Modules.txt");
            List<int> moduleFuel2 = craft.CalculateFuelAndItsFuel(weights2);
            int totalWeight2 = craft.AddFuel(moduleFuel2);
            Console.WriteLine(totalWeight2.ToString());
        }
    }
}
