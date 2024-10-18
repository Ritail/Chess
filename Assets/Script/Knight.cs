 using System.Collections.Generic;
 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Knight", menuName = "Piece/Knight")]
     public class Knight : Pièce
     {
         public override List<Vector2Int> availableMouvments(Vector2Int position)
         {
             List<Vector2Int> mouvements = new List<Vector2Int>();
             Vector2Int[] knightMoves = new Vector2Int[]
             {
                 new Vector2Int(2, 1),
                 new Vector2Int(2, -1),
                 new Vector2Int(-2, 1),
                 new Vector2Int(-2, -1),
                 new Vector2Int(1, 2),
                 new Vector2Int(1, -2),
                 new Vector2Int(-1, 2),
                 new Vector2Int(-1, -2)
             };
             
             foreach (Vector2Int move in knightMoves)
             {
                 Vector2Int newPosition = position + move;
                 
                 if (IsValidPosition(newPosition))
                 {
                     Pièce pieceAtNewPosition = GameManager.Instance.Pieces[newPosition.x, newPosition.y];

                     if (pieceAtNewPosition == null)
                     {
                         mouvements.Add(newPosition);
                     }
                     else
                     {
                         if (pieceAtNewPosition.isWhite != this.isWhite)
                         {
                             mouvements.Add(newPosition);
                         }
                     }
                 }
             }

             return mouvements;
         }
     }
 }