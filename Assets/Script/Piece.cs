using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    public abstract class Piece : ScriptableObject
    {
        public Sprite sprite;
        public bool isWhite;
        public int Value;
        public bool IsInCheck;

        public abstract List<Vector2Int> availableMovements(Vector2Int position, Piece[,] pieces);
        public bool IsValidPosition(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
        }
    }
}

