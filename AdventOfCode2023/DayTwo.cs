using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public class DayTwo
    {
        public static void DayTwoMain()
        {
            // Day 2: Cube Conundrum
            var linesFromFile = Utils.LinesFromFile("CubeGames.txt");

            // Day 2: Part 1
            // Sum of the game number of possible games
            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Part 1: {DayTwoPartOne(linesFromFile)}");
            Console.WriteLine($"Ran in {-startTime.Subtract(startTime).Milliseconds} milliseconds");

            // Day 2: Part 2
            // Sum of the power of the minimum number of cubes needed for each game
            startTime = DateTime.Now;
            Console.WriteLine($"Part 2: {DayTwoPartTwo(linesFromFile)}");
            Console.WriteLine($"Ran in {-startTime.Subtract(startTime).Milliseconds} milliseconds");
        }

        private static int DayTwoPartOne(IEnumerable<string> linesFromFile)
        {
            var cubeGames = ParseCubeGames(linesFromFile);

            int gameSum = 0;
            foreach (var cubeGame in cubeGames)
            {
                gameSum += cubeGame.TestGame(12,13,14) ? cubeGame.GameNumber : 0;
            }

            return gameSum;
        }

        private static int DayTwoPartTwo(IEnumerable<string> linesFromFile)
        {
            var cubeGames = ParseCubeGames(linesFromFile);

            int powerSum = 0;
            foreach (var cubeGame in cubeGames)
            {
                powerSum += cubeGame.MinimumSet.Power;
            }

            return powerSum;
        }

        private static IEnumerable<CubeGame> ParseCubeGames(IEnumerable<string> gameStrings)
        {
            foreach (var gameString in gameStrings)
            {
                yield return new(gameString);
            }
        }
    }

    public partial class CubeGame
    {
        public int GameNumber { get; }

        public int MaxRedCubes {
            get
            {

                return CubeSets.OrderBy(s => s.RedCubes).Select(s => s.RedCubes).LastOrDefault();
            }
        }

        public int MaxGreenCubes
        {
            get
            {
                return CubeSets.OrderBy(s => s.GreenCubes).Select(s => s.GreenCubes).LastOrDefault();
            }
        }

        public int MaxBlueCubes
        {
            get
            {
                return CubeSets.OrderBy(s => s.BlueCubes).Select(s => s.BlueCubes).LastOrDefault();
            }
        }

        /// <summary>
        /// The minimum set of cubes needed for the game to be possible
        /// </summary>
        public GameSet MinimumSet
        {
            get
            {
                return new GameSet()
                {
                    RedCubes = MaxRedCubes,
                    GreenCubes = MaxGreenCubes,
                    BlueCubes = MaxBlueCubes
                };
            }
        }

        private IEnumerable<GameSet> CubeSets { get; set; }

        /// <summary>
        /// Build a CubeGame from a game string
        /// </summary>
        /// <param name="cubeGameString">String in the form of "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"</param>
        public CubeGame(string cubeGameString)
        {
            GameNumber = GetGameNumber(cubeGameString);
            CubeSets = GetCubeSets(cubeGameString);
        }

        /// <summary>
        /// Builds a collection of game sets from a game string
        /// </summary>
        /// <param name="gameString"></param>
        /// <returns>Collection of game sets</returns>
        private IEnumerable<GameSet> GetCubeSets(string gameString)
        {
            // Get the parts of the game string that has the sets of cubes separated by semicolons
            var cubeSetStrings = GameSetsRegex().Match(gameString).Value.Split(';');

            foreach (var cubeSet in cubeSetStrings)
            {
                yield return ParseGameSet(cubeSet);
            }
        }

        /// <summary>
        /// Take a cube set string and convert it to a game set. 
        /// </summary>
        /// <param name="cubeSet">A cube set string in the form of "5 red, 4 green, 2 blue"</param>
        /// <returns></returns>
        private GameSet ParseGameSet(string cubeSet)
        {
            var cubeTuples = CubeAmountsRegex().Matches(cubeSet).Select(m => (m.Groups[2].Value, m.Groups[1].Value));

            return new GameSet()
            {
                RedCubes = cubeTuples.Where(t => t.Item1 == "red").Select(t => t.Item2.ParseIntOrThrow()).FirstOrDefault(),
                GreenCubes = cubeTuples.Where(t => t.Item1 == "green").Select(t => t.Item2.ParseIntOrThrow()).FirstOrDefault(),
                BlueCubes = cubeTuples.Where(t => t.Item1 == "blue").Select(t => t.Item2.ParseIntOrThrow()).FirstOrDefault()
            };
        }

        /// <summary>
        /// Get the game number from a game string
        /// </summary>
        /// <param name="gameString">String in the form of "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"</param>
        /// <returns></returns>
        /// <exception cref="Exception">Throws when the game number can't be found</exception>
        private int GetGameNumber(string gameString)
        {
            var gameNumberString = GameNumberRegex().Match(gameString).Groups[1].Value;
            if (String.IsNullOrEmpty(gameNumberString)) throw new Exception("Game number not found");
            return gameNumberString.ParseIntOrThrow();
        }

        /// <summary>
        /// Tests if a cube game is possible with the known amount of cubes of each color
        /// </summary>
        /// <param name="redCubes"></param>
        /// <param name="greenCubes"></param>
        /// <param name="blueCubes"></param>
        /// <returns>True if game is possible</returns>
        public bool TestGame(int redCubes, int greenCubes, int blueCubes)
        {
            return redCubes >= MaxRedCubes
                   && greenCubes >= MaxGreenCubes
                   && blueCubes >= MaxBlueCubes;
        }

        [GeneratedRegex(@"Game (\d+)")]
        private static partial Regex GameNumberRegex();

        [GeneratedRegex(@"Game \d+: (.+)")]
        private static partial Regex GameSetsRegex();

        [GeneratedRegex(@"(?:(\d+)\s(\w+))")]
        private static partial Regex CubeAmountsRegex();

        public class GameSet
        {
            public int RedCubes { get; set; }
            public int GreenCubes { get; set; }
            public int BlueCubes { get; set; }
            public int Power
            {
                get
                {
                    return RedCubes * GreenCubes * BlueCubes;
                }
            }
        }
    }
}
