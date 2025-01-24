using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    public abstract class Pièce : ScriptableObject
    {
        public Sprite sprite;
        public bool isWhite;
        public int Value;

        public abstract List<Vector2Int> availableMouvments(Vector2Int position);
        public bool IsValidPosition(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
        }
    }
}

