using System;
using System.Collections.Generic;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            GravityAssist gravityAssist = new GravityAssist();
            List<int> codes = gravityAssist.GetCodes("intercode.txt");
            codes =  gravityAssist.ProcessCodes(codes);
            Console.WriteLine($"part1 result {codes[0]}");
            decimal result = 0;
            bool matched = false;
            while (!matched)
            {
                for (int noun = 0; noun < 100; noun++)
                {
                    for (int verb = 0; verb < 100; verb++)
                    {
                        List<int> codes2 = gravityAssist.ProcessCodes2("intercode.txt", noun, verb);
                        if (19690720 == codes2[0])
                        {
                            result = (noun * 100) + verb;
                            matched = true; 
                        }
                    }
                }
            }
            Console.WriteLine($"result: {result}");
        }
    }
}
