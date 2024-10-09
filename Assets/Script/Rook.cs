 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Rook", menuName = "Piece/Rook")]
     public class Rook : Pièce
    {
        public override Vector2Int availableMouvments()
        {
            throw new System.NotImplementedException();
        }
    }
 }