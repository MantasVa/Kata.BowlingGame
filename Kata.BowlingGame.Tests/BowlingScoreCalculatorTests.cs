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
        public void CalculateScore_ValidInput_CalculatesScoreCorrectly(string input, ushort expectedScore)
        {
            ushort actualScore = BowlingScoreCalculator.CalculateScore(input);

            Assert.Equal(expectedScore, actualScore);
        }
    }
}
