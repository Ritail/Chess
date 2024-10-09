 using System.Collections.Generic;
 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Pawn", menuName = "Piece/Pawn")]
     public class Pawn : Pièce
     {
         public override Vector2Int[] availableMouvments()
         {
             throw new System.NotImplementedException();
         }
     }
}