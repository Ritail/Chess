 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Knight", menuName = "Piece/Knight")]
     public class Knight : Pièce
     {
        public override Vector2Int[] availableMouvments()
        {
            throw new System.NotImplementedException();
        }
     }
 }