namespace AdventOfCode2023
{
    public class DayThree
    {
        public static void DayThreeMain()
        {
            // Day 3: Gear Ratios
            Console.WriteLine("Day 3: Gear Ratios");

            string engineSchematicFilename = @"";

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
}
