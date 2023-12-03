using System.Collections;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public class DayThree
    {
        public static void DayThreeMain()
        {
            // Day 3: Gear Ratios
            Console.WriteLine("Day 3: Gear Ratios");

            string engineSchematicFilename = @"Input Files\ExampleEngineSchematic.txt";

            // Day 3: Part 1
            // Sum of the part numbers in engine schematic
            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Part 1: {DayThreePartOne(engineSchematicFilename)}");
            Console.WriteLine($"Ran in {-startTime.Subtract(startTime).Milliseconds} milliseconds");

            // Day 3: Part 2
            // ???
            startTime = DateTime.Now;
            Console.WriteLine($"Part 2: {DayThreePartTwo(engineSchematicFilename)}");
            Console.WriteLine($"Ran in {-startTime.Subtract(startTime).Milliseconds} milliseconds");
        }

        public static int DayThreePartOne(string engineSchematicFilename)
        {
            // Get file into 2d grid of chars
            var engineSchematic = new EngineSchematic(engineSchematicFilename);

            // get list of coordinates of all special symbols (everything that isn't a number or '.') <- regex? [^0-9|.]

            // go through list and find numbers in the 8 coordinates around it's coordinates
            // put those coordinates in list
            // go through list of the number coordinates and find the start of each number
            // then traverse to the end to get all digits
            // concatenate the digits together to get the number add it to a list
            // add up all the numbers

            /*
             * Note: If a number is beside two symbols, does it count twice? 
             * It's not explained in the example, but could matter in the final total.
             * Might have to get a list of all the part number starting coords
             * then remove any duplicates
             */ 
            throw new NotImplementedException();
        }

        public static int DayThreePartTwo(string engineSchematicFilename)
        {
            throw new NotImplementedException();
        }
    }

    public class EngineSchematic(string filePath)
    {
        private readonly List<List<char>> _grid = Utils.FileTo2d(filePath);
        private readonly IEnumerable<string> lines = File.ReadAllLines(filePath);
        public int Width
        {
            get
            {
                return lines.First().Length;
            }
        }

        public int Height
        {
            get
            {
                return lines.ToArray().Length;
            }
        }

        public IEnumerable<Point> SymbolPoints
        {
            get
            {
                var symbolRegex = new Regex(@"[^0-9|.]");

                int lineNumber = -1;
                foreach (var line in lines)
                {
                    lineNumber++;

                    MatchCollection matches = symbolRegex.Matches(line);
                    if (matches.Count == 0) continue;
                    foreach (Match match in matches.Cast<Match>())
                    {
                        yield return new Point
                        {
                            X = lineNumber,
                            Y = match.Index % Width
                        };
                    }

                }
            }
        }
    }

    public record Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
