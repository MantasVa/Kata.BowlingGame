using System;
using Xunit;

namespace Kata.BowlingGame.Tests
{
    public class BowlingScoreCalculatorTests
    {
        [Theory]
        [InlineData("12345123451234512345", 60)]
        [InlineData("9-9-9-9-9-9-9-9-9-9-", 90)]
        [InlineData("5/5/5/5/5/5/5/5/5/5/5", 150)]
        [InlineData("xxxxxxxxxxxx", 300)]
        [InlineData("xxxxxxxxxx52", 282)]
        [InlineData("52xx3/52x112/x53", 132)]
        [InlineData("2/x543/215/5/80x5/3",137)]
        [InlineData("61200/4/3/8/x1443xx2", 123)]
        public void CalculateScore_ValidInput_CalculatesScoreCorrectly(string input, ushort expectedScore)
        {
            BowlingScoreCalculator calculator = new BowlingScoreCalculator(input);

            ushort actualScore = calculator.CalculateScore();

            Assert.Equal(expectedScore, actualScore);
        }
    }
}
