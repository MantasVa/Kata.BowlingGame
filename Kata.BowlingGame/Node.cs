using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.BowlingGame
{
    public class Node
    {
        public ushort Value { get; set; }
        public StrikeType Type { get; set; }

        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
}
