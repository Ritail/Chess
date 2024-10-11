using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "Bishop", menuName = "Piece/Bishop")]
    public class Bishop : Pièce
    {
        public override List<Vector2Int> availableMouvments(Vector2Int position)
        {
            List<Vector2Int> mouvments = new List<Vector2Int>();
            mouvments.Add(new Vector2Int(0,0));
            return mouvments;
        }
    }
}