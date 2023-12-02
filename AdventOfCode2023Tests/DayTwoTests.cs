using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class DayTwoTests
    {
        [TestMethod]
        public void Game1()
        {
            var cubeGame = new CubeGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

            Assert.AreEqual(1, cubeGame.GameNumber);

            Assert.AreEqual(4, cubeGame.MaxRedCubes);
            Assert.AreEqual(2, cubeGame.MaxGreenCubes);
            Assert.AreEqual(6, cubeGame.MaxBlueCubes);

            Assert.AreEqual(48, cubeGame.MinimumSet.Power);

            Assert.IsTrue(cubeGame.TestGame(12,13,14));
        }

        [TestMethod]
        public void Game2()
        {
            var cubeGame = new CubeGame("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");

            Assert.AreEqual(2, cubeGame.GameNumber);

            Assert.AreEqual(1, cubeGame.MaxRedCubes);
            Assert.AreEqual(3, cubeGame.MaxGreenCubes);
            Assert.AreEqual(4, cubeGame.MaxBlueCubes);

            Assert.AreEqual(12, cubeGame.MinimumSet.Power);

            Assert.IsTrue(cubeGame.TestGame(12, 13, 14));
        }

        [TestMethod]
        public void Game3()
        {
            var cubeGame = new CubeGame("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");

            Assert.AreEqual(3, cubeGame.GameNumber);

            Assert.AreEqual(20, cubeGame.MaxRedCubes);
            Assert.AreEqual(13, cubeGame.MaxGreenCubes);
            Assert.AreEqual(6, cubeGame.MaxBlueCubes);

            Assert.AreEqual(1560, cubeGame.MinimumSet.Power);

            Assert.IsFalse(cubeGame.TestGame(12, 13, 14));
        }

        [TestMethod]
        public void Game4()
        {
            var cubeGame = new CubeGame("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");

            Assert.AreEqual(4, cubeGame.GameNumber);

            Assert.AreEqual(14, cubeGame.MaxRedCubes);
            Assert.AreEqual(3, cubeGame.MaxGreenCubes);
            Assert.AreEqual(15, cubeGame.MaxBlueCubes);

            Assert.AreEqual(630, cubeGame.MinimumSet.Power);

            Assert.IsFalse(cubeGame.TestGame(12, 13, 14));
        }

        [TestMethod]
        public void Game5()
        {
            var cubeGame = new CubeGame("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

            Assert.AreEqual(5, cubeGame.GameNumber);

            Assert.AreEqual(6, cubeGame.MaxRedCubes);
            Assert.AreEqual(3, cubeGame.MaxGreenCubes);
            Assert.AreEqual(2, cubeGame.MaxBlueCubes);

            Assert.AreEqual(36, cubeGame.MinimumSet.Power);

            Assert.IsTrue(cubeGame.TestGame(12, 13, 14));
        }

        [TestMethod]
        public void Game84()
        {
            var cubeGame = new CubeGame("Game 84: 1 blue, 7 red, 6 green; 6 red, 8 green, 10 blue; 8 green, 1 blue, 6 red; 8 red, 4 blue, 6 green; 3 red, 12 blue, 8 green; 3 red, 2 blue, 7 green");

            Assert.AreEqual(84, cubeGame.GameNumber);

            Assert.AreEqual(8, cubeGame.MaxRedCubes);
            Assert.AreEqual(8, cubeGame.MaxGreenCubes);
            Assert.AreEqual(12, cubeGame.MaxBlueCubes);


            Assert.IsTrue(cubeGame.TestGame(12, 13, 14));
        }

        [TestMethod]
        public void Game95()
        {
            var cubeGame = new CubeGame("Game 95: 3 red; 7 green, 4 red, 7 blue; 5 red, 5 blue");

            Assert.AreEqual(95, cubeGame.GameNumber);

            Assert.AreEqual(5, cubeGame.MaxRedCubes);
            Assert.AreEqual(7, cubeGame.MaxGreenCubes);
            Assert.AreEqual(7, cubeGame.MaxBlueCubes);

            Assert.IsTrue(cubeGame.TestGame(12, 13, 14));
        }
    }
}
