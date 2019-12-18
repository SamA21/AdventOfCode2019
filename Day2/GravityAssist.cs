using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day2
{
    public class GravityAssist
    {
        public List<int> GetCodes(string textFile)
        {
            List<int> codes = new List<int>();
            FileStream fileStream = new FileStream($"Inputs\\{textFile}", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();
                string[] splitLine = line.Split(',');
                foreach(string number in splitLine)
                {
                    if (int.TryParse(number, out int code))
                    {
                        codes.Add(code);
                    }
                }
            }
            return codes;
        }

        public List<int> ProcessCodes(List<int> codes)
        {
            int index = 0;
            bool notEnd = true;
            while (notEnd)
            {
                if (index + 3 <= codes.Count)
                {
                    int code = codes[index];
                    int? newValue = null;
                    if (code == 1)
                    {
                        newValue = Add(codes[codes[index + 1]], codes[codes[index + 2]]);                        
                        codes[codes[index + 3]] = newValue.Value;
                    }
                    else if (code == 2)
                    {
                        newValue = Multiply(codes[codes[index + 1]], codes[codes[index + 2]]);
                        codes[codes[index + 3]] = newValue.Value;
                    }
                    else if(code == 99)
                    {
                        notEnd = false;
                        Console.WriteLine($"stop code {code} at {index}");
                    }
                    index += 4;
                }
                else
                {
                    notEnd = false;
                }
            }
            return codes;
        }

        public List<int> ProcessCodes2(string textFile, int noun, int verb)
        {
            List<int> codes = GetCodes(textFile);
            codes[1] = noun;
            codes[2] = verb;
            int index = 0;
            bool notEnd = true;
            while (notEnd)
            {
                if (index + 3 <= codes.Count)
                {
                    int code = codes[index];
                    int? newValue = null;
                    if (code == 1)
                    {
                        newValue = Add(codes[codes[index + 1]], codes[codes[index + 2]]);
                        codes[codes[index+3]] = newValue.Value;
                    }
                    else if (code == 2)
                    {
                        newValue = Multiply(codes[codes[index + 1]], codes[codes[index + 2]]);
                        codes[codes[index+3]] = newValue.Value;
                    }
                    else if (code == 99)
                    {
                        notEnd = false;
                    }
                    else
                    {
                        break;
                    }
                    index += 4;
                }
                else
                {
                    notEnd = false;
                }
            }
            return codes;
        }


        private int Multiply(int first, int second)
        {
            return first * second;
        }

        private int Add(int first, int second)
        {
            return first + second;
        }      
    }
}
