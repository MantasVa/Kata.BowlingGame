using System;

namespace Kata.BowlingGame
{
    public enum StrikeType
    {
        Number,
        Spare,
        Strike
    }
    public class BowlingScoreCalculator
    {
        private ushort _score = 0;
        private Node _currentNode = null;
        private string _gameScore;

        public BowlingScoreCalculator(string gameScore)
        {
            _gameScore = gameScore;
            BuildGameScoreNodes();
        }

        public ushort CalculateScore()
        {
            ushort frameCount = 0;
            while (frameCount != 10)
            {
                frameCount++;
                if (_currentNode.Type == StrikeType.Number)
                {
                    CalculateRegularThrow();
                }
                else
                {
                    CalculateStrikeThrow();
                }
            }

            return _score;
        }

        private void BuildGameScoreNodes()
        {
            _gameScore = _gameScore.ToLower().Replace('-', '0');
            Node prevNode = null;
            foreach (var ch in _gameScore)
            {
                ushort numberValue;
                StrikeType type;
                if (UInt16.TryParse(ch.ToString(), out numberValue))
                {
                    type = StrikeType.Number;
                }
                else if (ch == '/')
                {
                    type = StrikeType.Spare;
                    numberValue = (ushort)(10 - prevNode.Value);
                }
                else
                {
                    type = StrikeType.Strike;
                    numberValue = 10;
                }

                Node node = new Node(numberValue, type, prevNode);

                if (prevNode != null)
                {
                    prevNode.NextNode = node;
                }
                else
                {
                    _currentNode = node;
                }

                prevNode = node;
            }
        }

        private void CalculateRegularThrow()
        {
            if (_currentNode.NextNode.Type == StrikeType.Spare)
            {
                AddThrowScore(_currentNode.NextNode.NextNode.Value);
            }
            else
            {
                AddThrowScore();
            }
            _currentNode = _currentNode.NextNode.NextNode;
        }
        private void CalculateStrikeThrow()
        {
            AddThrowScore(_currentNode.NextNode.NextNode.Value);
            _currentNode = _currentNode.NextNode;
        }
        private void AddThrowScore(ushort extraScore = 0)
        {
            _score += (ushort)(_currentNode.Value + _currentNode.NextNode.Value + extraScore);
        }
    }
}
