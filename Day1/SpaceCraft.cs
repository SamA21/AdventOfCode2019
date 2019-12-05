using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day1
{
    public class SpaceCraft
    {
        public List<int> GetWeights(string textFile)
        {
            List<int> modules = new List<int>();
            FileStream fileStream = new FileStream($"Inputs\\{textFile}", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (int.TryParse(line, out int weight))
                    {
                        modules.Add(weight);
                    }
                }
            }
            return modules;
        }

        public List<int> CalculateFuel(List<int> weights)
        {
            List<int> fuelValues = new List<int>();
            foreach(int mass in weights)
            {
                decimal fuel = mass / 3;
                fuel = Math.Floor(fuel) - 2;
                fuelValues.Add((int)fuel);
            }
            return fuelValues;
        }

        public List<int> CalculateFuelAndItsFuel(List<int> weights)
        {
            List<int> fuelValues = new List<int>();
            foreach (int mass in weights)
            {
                decimal weight = mass;
                bool aboveZero = true;
                decimal totalWeight = 0;
                while (aboveZero)
                {
                    weight = weight / 3;
                    weight = Math.Floor(weight);
                    weight = weight - 2;
                    if (weight > 0)
                    {
                        totalWeight += weight;
                    }
                    else
                    {
                        weight = 0;
                        totalWeight += weight;
                        fuelValues.Add((int)totalWeight);
                        aboveZero = false;
                    }
                }
            }
            return fuelValues;
        }

        public int AddFuel(List<int> fuelValues)
        {
            return fuelValues.Sum();
        }
    }
}
