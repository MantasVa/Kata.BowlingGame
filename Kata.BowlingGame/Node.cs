namespace Kata.BowlingGame
{
    public class Node
    {
        public Node(ushort value, StrikeType type, Node prevNode)
        {
            Value = value;
            Type = type;
            PrevNode = prevNode;
        }
        public ushort Value { get; }
        public StrikeType Type { get; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; }
    }
}
