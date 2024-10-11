 using System.Collections.Generic;
 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Rook", menuName = "Piece/Rook")]
     public class Rook : Pièce
    {
        public override List<Vector2Int> availableMouvments(Vector2Int position)
        {
            List<Vector2Int> mouvments = new List<Vector2Int>();
            mouvments.Add(new Vector2Int(0,0));
            return mouvments;
        }
    }
 }