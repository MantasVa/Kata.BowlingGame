using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Kata.BowlingGame
{
    public enum StrikeType
    {
        Number,
        Spare,
        Strike
    }
    public static class BowlingScoreCalculator
    {
        public static ushort CalculateScore(string gamescore)
        {
            gamescore = gamescore.ToLower().Replace('-', '0');

            Node firstNode = null;
            Node prevNode = null;
            foreach (var ch in gamescore)
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

                Node node = new Node()
                {
                    Value = numberValue,
                    Type = type,
                    PrevNode = prevNode,
                };

                if(prevNode != null)
                {
                    prevNode.NextNode = node;
                }
                else
                {
                    firstNode = node;
                }

                prevNode = node;
            }

            ushort score = 0;
            Node currentNode = firstNode;
            while (true)
            {
                if(currentNode.Type == StrikeType.Number)
                {    
                    if (currentNode.NextNode.Type == StrikeType.Spare)
                    {
                        score += (ushort)(currentNode.Value + currentNode.NextNode.Value + currentNode.NextNode.NextNode.Value);

                        if (currentNode.NextNode.NextNode.NextNode == null)
                            break;
                    }
                    else
                    {
                        score += (ushort)(currentNode.Value + currentNode.NextNode.Value);

                        if (currentNode.NextNode.NextNode == null)
                            break;
                    }

                    currentNode = currentNode.NextNode.NextNode;
                }
                else
                {      
                    score += (ushort)(currentNode.Value + currentNode.NextNode.Value + currentNode.NextNode.NextNode.Value);

                    if (currentNode.NextNode.NextNode.NextNode == null)
                        break;
                    currentNode = currentNode.NextNode;
                }
            }

            //gamescore = gamescore.ToLower().Replace('-','0');
            //for (ushort i = 0; i < gamescore.Length-1; i++)
            //{

            //    if(gamescore[i] == 'x')
            //    {
            //        score += 10;
            //        if(gamescore[i+1] == 'x')
            //        {
            //            score += 10;
            //        }
            //        else
            //        {
            //            score += (ushort)(Int16.Parse(gamescore[i + 1].ToString()));
            //        }

            //        if (gamescore[i + 2] == 'x')
            //        {
            //            score += 10;
            //        }
            //        else if(gamescore[i + 2] == '/')
            //        {
            //            score += (ushort)(10 - Int16.Parse(gamescore[i + 1].ToString()));
            //        }
            //        else
            //        {
            //            score += (ushort)(Int16.Parse(gamescore[i + 2].ToString()));
            //        }

            //        if (i == gamescore.Length-3)
            //            break;

            //    }
            //    else
            //    {
            //        if(gamescore[i+1] != '/')
            //        {
            //            score += (ushort)(Int16.Parse(gamescore[i].ToString()) + Int16.Parse(gamescore[i+1].ToString()));
            //            i++;
            //        }
            //        else
            //        {
            //            if(gamescore[i+2] == 'x')
            //            {
            //                score += 20;
            //            }
            //            else
            //            {
            //                score += (ushort)(10 + Int16.Parse(gamescore[i + 2].ToString()));

            //            }
            //            i++;
            //        }
            //    }
            //}

            return score;
        }
    }
}
