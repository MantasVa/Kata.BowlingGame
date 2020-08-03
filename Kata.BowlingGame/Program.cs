using System;

namespace Kata.BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "xxxxxxxxxxxx";
            BowlingScoreCalculator calculator = new BowlingScoreCalculator(input);
            Console.WriteLine(calculator.CalculateScore());
        }
    }
}
