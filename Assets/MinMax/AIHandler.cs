using System;
using UnityEngine;

namespace MinMax
{
    public class AIHandler : MonoBehaviour
    {
        public int MinMax(Node node, int depth, bool maximizingPlayer)
        {
            if (depth == 0 || node.IsTerminal())
            {
                return node.HeursticValue();
            }

            if (maximizingPlayer)
            {
                int maxEval = int.MinValue;
                foreach (var child in node.Children())
                {
                    int eval = MinMax(child, depth - 1, false);
                    maxEval = Math.Max(maxEval, eval);
                }
                return maxEval;
            }
            else
            {
                int minEval = int.MaxValue;
                foreach (var child in node.Children())
                {
                    int eval = MinMax(child, depth - 1, true);
                    minEval = Math.Min(minEval, eval);
                }
                return minEval;
            }
        }

        public int AlphaBetaMinMax(Node node, int depth, int a, int b, bool maximizingPlayer)
        {
            if (depth == 0 || node.IsTerminal())
            {
                return node.HeursticValue();
            }

            if (maximizingPlayer)
            {
                int value = int.MinValue;
                foreach (var child in node.Children())
                {
                    value = Math.Max(value, AlphaBetaMinMax(child, depth - 1, a, b, false));
                    if (value > b)
                    {
                        break;
                    }
                    a = Math.Max(a, value);
                }
                return value;
            }
            else
            {
                int value = int.MaxValue;
                foreach (var child in node.Children())
                {
                    value = Math.Min(value, AlphaBetaMinMax(child, depth - 1, a, b, true));

                    if (value < a)
                    {
                        break;
                    }
                    b = Math.Min(b, value);
                }
                return value;
            }
        }
    }
}
