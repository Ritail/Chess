 using System.Collections.Generic;
 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Pawn", menuName = "Piece/Pawn")]
     public class Pawn : Pièce
     {
         public override List<Vector2Int> availableMouvments(Vector2Int position)
         {
             List<Vector2Int> mouvements = new List<Vector2Int>();
             if (isWhite != true)
             {
                 if (position.x == 1)
                 {
                     mouvements.Add(new Vector2Int(1,0) + position);
                     mouvements.Add(new Vector2Int(2,0) + position);
                     return mouvements;
                 }
                 mouvements.Add(new Vector2Int(1,0) + position);
                 return mouvements;
             }
             else
             {
                 if (position.x == 6)
                 {
                     mouvements.Add(new Vector2Int(-1,0) + position);
                     mouvements.Add(new Vector2Int(-2,0) + position);
                     return mouvements;
                 }
                 mouvements.Add(new Vector2Int(-1,0) + position);
                 return mouvements;
             }
         }
         
     }
}