using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    public abstract class Pièce : ScriptableObject
    {
        public Sprite sprite;
        public bool isWhite;

        public abstract Vector2Int availableMouvments();
    }
}

