using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023Tests
{
    [TestClass()]
    public class DayThreeTests
    {
        [TestMethod()]
        public void PartOneExampleSchematic()
        {
            // Load ExampleEngineSchematic file
            string engineSchematicFileName = @"Input Files\ExampleEngineSchematic.txt";

            Assert.AreEqual(4361, DayThree.DayThreePartOne(engineSchematicFileName));
        }
    }
}