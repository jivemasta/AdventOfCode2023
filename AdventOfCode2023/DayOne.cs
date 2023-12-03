using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public partial class DayOne
    {
        public static void DayOneMain()
        {

            var calibrationStrings = Utils.LinesFromFile(@"Input Files\TrebuchetCalibration.txt");

            // Day 1: Part 1
            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Digit Based Calibration Value: {DayOnePartOne(calibrationStrings)}");
            Console.WriteLine($"Ran in {-startTime.Subtract(DateTime.Now).TotalMilliseconds} milliseconds");

            // Day 1: Part 2
            startTime = DateTime.Now;
            Console.WriteLine($"Digit and Word Based Calibration Value {DayOnePartTwo(calibrationStrings)}");
            Console.WriteLine($"Ran in {-startTime.Subtract(DateTime.Now).TotalMilliseconds} milliseconds");
        }

        public static int DayOnePartOne(IEnumerable<string> calibrationStrings)
        {
            int totalCalibration = 0;
            foreach (var calibrationString in calibrationStrings)
            {
                totalCalibration += GetCalibrationValueDigits(calibrationString);
            }

            return totalCalibration;
        }

        public static int DayOnePartTwo(IEnumerable<string> calibrationStrings)
        {
            int totalCalibration = 0;
            foreach (var calibrationString in calibrationStrings)
            {
                int test = GetCalibrationValue(calibrationString);
                totalCalibration += GetCalibrationValue(calibrationString);
            }

            return totalCalibration;
        }

        public static int GetCalibrationValue(string calibrationString)
        {
            var digitStrings = GetAllDigitsAndNumberWords().Matches(calibrationString).FirstOrDefault() ?? throw new Exception("Invalid calibration string");
            var digits = ParseNumberListFromStringList(digitStrings.Groups.Values.Select(g => g.Value).Skip(1));
            return (digits.First() * 10) + digits.Last();
        }

        public static int ParseNumberFromString(string input)
        {
            if (int.TryParse(input, out var result)) return result;

            return input switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => throw new Exception("Word was not a spelled out number")
            };
        }

        public static IEnumerable<int> ParseNumberListFromStringList(IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                yield return ParseNumberFromString(item);
            }
        }

        public static int GetCalibrationValueDigits(string calibrationString)
        {
            var digits = GetAllDigits().Matches(calibrationString);
            if (digits.Count == 0) return 0;
            return ParseNumberFromString(digits.First().Value + digits.Last().Value);
        }

        [GeneratedRegex(@"\d")]
        private static partial Regex GetAllDigits();

        [GeneratedRegex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine)).*(\d|one|two|three|four|five|six|seven|eight|nine)")]
        private static partial Regex GetAllDigitsAndNumberWords();
    }
}
