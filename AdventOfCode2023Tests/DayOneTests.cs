using AdventOfCode2023;

namespace AdventOfCode2023Tests
{
    [TestClass]
    public class DayOneTests
    {
        [TestMethod]
        public void DigitSimple()
        {
            Assert.AreEqual(12, DayOne.GetCalibrationValueDigits("1abc2"));
        }

        [TestMethod]
        public void DigitHard()
        {
            Assert.AreEqual(38, DayOne.GetCalibrationValueDigits("pqr3stu8vwx"));
        }

        [TestMethod]
        public void DigitMultipleDigits()
        {
            Assert.AreEqual(15, DayOne.GetCalibrationValueDigits("a1b2c3d4e5f"));
        }

        [TestMethod]
        public void DigitSingleDigit()
        {
            Assert.AreEqual(77, DayOne.GetCalibrationValueDigits("treb7uchet"));
        }

        [TestMethod]
        public void StringSimple()
        {
            Assert.AreEqual(29, DayOne.GetCalibrationValue("two1nine"));
        }

        [TestMethod]
        public void StringWithNoDigits()
        {
            Assert.AreEqual(83, DayOne.GetCalibrationValue("eightwothree"));
        }

        [TestMethod]
        public void StringWithExtraChars()
        {
            Assert.AreEqual(13, DayOne.GetCalibrationValue("abcone2threexyz"));
        }

        [TestMethod]
        public void StringWithMergedWords()
        {
            Assert.AreEqual(24, DayOne.GetCalibrationValue("xtwone3four"));
        }

        [TestMethod]
        public void StringWithDigitsOnEnds()
        {
            Assert.AreEqual(42, DayOne.GetCalibrationValue("4nineeightseven2"));
        }

        [TestMethod]
        public void StringWithMergedWordsAndNumbers()
        {
            Assert.AreEqual(14, DayOne.GetCalibrationValue("zoneight234"));
        }

        [TestMethod]
        public void StringWithSixteen()
        {
            Assert.AreEqual(76, DayOne.GetCalibrationValue("7pqrstsixteen"));
        }

        [TestMethod]
        public void EightThree()
        {
            Assert.AreEqual(83, DayOne.GetCalibrationValue("eighthree"));
        }

        [TestMethod]
        public void SevenNine()
        {
            Assert.AreEqual(79, DayOne.GetCalibrationValue("sevennine"));
        }
    }
}