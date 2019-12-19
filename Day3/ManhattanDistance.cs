using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Day3
{
    public class ManhattanDistance
    {
        public List<List<string>> GetLocations(string textFile)
        {
            FileStream fileStream = new FileStream($"Inputs\\{textFile}", FileMode.Open);
            List<List<string>> locations = new List<List<string>>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    List<string> codes = new List<string>();
                    string line = reader.ReadLine();
                    string[] splitLine = line.Split(',');
                    foreach (string code in splitLine)
                    {
                        codes.Add(code);
                    }
                    locations.Add(codes);
                }


            }
            return locations;
        }

        public bool CrossLocation(List<List<string>> locations, int[] tests)
        {
            bool allPassed = false;
            int index = 0;
            foreach (int test in tests)
            {
                List<List<string>> testLocations = locations.Skip(index).Take(2).ToList();
                int result = CrossLocation(testLocations);
                if(result == test)
                {
                    allPassed = true;
                }
                else
                {
                    allPassed = false;
                }
                index += 2;
            }
            return allPassed;
        }

        public int CrossLocation(List<List<string>> locations)
        {
            bool second = false;
            List<PointF> coords1 = new List<PointF>() {
                new PointF(0,0)
            };
            List<PointF> coords2 = new List<PointF>(){
                new PointF(0,0)
            };

            foreach (List<string> wire in locations)
            {
                if (!second)
                {
                    coords1 = PlotPoints(wire, coords1);
                    second = true;
                }
                else
                {
                    coords2 = PlotPoints(wire, coords2);
                }


            }
            float result = CompareCoords(coords1, coords2);
            return Convert.ToInt32(result);
        }

        private List<PointF> PlotPoints(List<string> locations, List<PointF> coords)
        {
            float pointX = coords[0].X;
            float pointY = coords[0].Y;
            foreach(string plot in locations)
            {
                string code = plot.First().ToString();
                int number = Convert.ToInt32(plot.Split(code)[1]);
                PointF point = new PointF(pointX, pointY);
                switch (code)
                {
                    case "U":
                        pointY += number;
                        coords.Add(new PointF(pointX, pointY));
                        break;
                    case "R":
                        pointX += number;
                        coords.Add(new PointF(pointX, pointY));
                        break;
                    case "D":
                        pointY -= number;
                        coords.Add(new PointF(pointX, pointY));
                        break;
                    case "L":
                        pointX -= number;
                        coords.Add(new PointF(pointX, pointY));
                        break;
                    default:
                        break;
                }
            }
            return coords;
        }

        private float CompareCoords(List<PointF> coords, List<PointF> coords2)
        {
            PointF zero = new PointF(0, 0);
            coords = FillPoints(coords);
            coords2 = FillPoints(coords2);
            List<PointF> intersections = coords.Intersect(coords2).ToList();
            List<Tuple<PointF, float>> map = new List<Tuple<PointF, float>>();
            foreach (PointF point in intersections)
            {
                if (point.X != 0 && point.Y != 0)
                {
                    if (point.X < 0 && point.Y < 0)
                    {
                        map.Add(new Tuple<PointF, float>(point, -point.X - point.Y));
                    }
                    else if (point.X < 0 && point.Y >= 0)
                    {
                        map.Add(new Tuple<PointF, float>(point, -point.X + point.Y));
                    }
                    else if (point.X >= 0 && point.Y < 0)
                    {
                        map.Add(new Tuple<PointF, float>(point, point.X - point.Y));
                    }
                    else
                    {
                        map.Add(new Tuple<PointF, float>(point, point.X + point.Y));
                    }
                }
            }
            //var map = intersections.Select(x => new { Point = x, Distance = x.X + x.Y }).Where(x => x.Point.X != 0 && x.Point.Y != 0);           
            float result = map.OrderBy(x => x.Item2).First().Item2;
            return result;
        }

        private List<PointF> FillPoints(List<PointF> coords)
        {
            List<PointF> newCoords = new List<PointF>();
            foreach(var point in coords)
            {
                newCoords.Add(point);
                int index = coords.IndexOf(point);
                index += 1;
                if(index < coords.Count)
                {
                    PointF point2 = coords[index];
                    float x = point2.X;
                    float y = point2.Y;

                    if (x > point.X)
                    {
                        while (x > point.X)
                        {
                            x--;
                            PointF newPoint = new PointF(x, point2.Y);
                            newCoords.Add(newPoint);
                        }
                    }
                    else if(x < point.X)
                    {
                        while (x < point.X)
                        {
                            x++;
                            PointF newPoint = new PointF(x, point2.Y);
                            newCoords.Add(newPoint);
                        }
                    }

                    if (y > point.Y)
                    {
                        while (y > point.Y)
                        {
                            y--;
                            PointF newPoint = new PointF(point2.X, y);
                            newCoords.Add(newPoint);
                        }
                    }
                    else if (y < point.Y)
                    {
                        while (y < point.Y)
                        {
                            y++;
                            PointF newPoint = new PointF(point2.X, y);
                            newCoords.Add(newPoint);
                        }
                    }
                }
            }
            return newCoords;
        }
    }
}
