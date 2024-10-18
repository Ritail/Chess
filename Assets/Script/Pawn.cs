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
             Vector2Int[] blackPawnEat = new Vector2Int[]
             {
                 new Vector2Int(1,-1),
                 new Vector2Int(1,1)
             };
             Vector2Int[] whitePawnEat = new Vector2Int[]
             {
                 new Vector2Int(-1,-1),
                 new Vector2Int(-1,1)
             };
             
             if (isWhite != true)
             {
                 if (position.x == 1)
                 {
                     mouvements.Add(new Vector2Int(1,0) + position);
                     mouvements.Add(new Vector2Int(2,0) + position);

                     foreach (Vector2Int eat in blackPawnEat)
                     {
                         Vector2Int diagonalRight = position + eat;
                         if (IsValidPosition(diagonalRight))
                         {
                             Pièce pieceAtDiagonalRight = GameManager.Instance.Pieces[diagonalRight.x, diagonalRight.y];
                             if (pieceAtDiagonalRight != null && pieceAtDiagonalRight.isWhite)
                             {
                                 mouvements.Add(diagonalRight);
                             }
                         }
                     }
                     return mouvements;
                 }
                 mouvements.Add(new Vector2Int(1,0) + position);
                 foreach (Vector2Int eat in blackPawnEat)
                 {
                     Vector2Int diagonalRight = position + eat;
                     if (IsValidPosition(diagonalRight))
                     {
                         Pièce pieceAtDiagonalRight = GameManager.Instance.Pieces[diagonalRight.x, diagonalRight.y];
                         if (pieceAtDiagonalRight != null && pieceAtDiagonalRight.isWhite)
                         {
                             mouvements.Add(diagonalRight);
                         }
                     }
                 }
                 return mouvements;
             }
             else
             {
                 if (position.x == 6)
                 {
                     mouvements.Add(new Vector2Int(-1,0) + position);
                     mouvements.Add(new Vector2Int(-2,0) + position);
                     foreach (Vector2Int eat in whitePawnEat)
                     {
                         Vector2Int diagonalRight = position + eat;
                         if (IsValidPosition(diagonalRight))
                         {
                             Pièce pieceAtDiagonalRight = GameManager.Instance.Pieces[diagonalRight.x, diagonalRight.y];
                             if (pieceAtDiagonalRight != null && pieceAtDiagonalRight.isWhite != isWhite)
                             {
                                 mouvements.Add(diagonalRight);
                             }
                         }
                     }
                     return mouvements;
                 }
                 mouvements.Add(new Vector2Int(-1,0) + position);
                 foreach (Vector2Int eat in whitePawnEat)
                 {
                     Vector2Int diagonalRight = position + eat;
                     if (IsValidPosition(diagonalRight))
                     {
                         Pièce pieceAtDiagonalRight = GameManager.Instance.Pieces[diagonalRight.x, diagonalRight.y];
                         if (pieceAtDiagonalRight != null && pieceAtDiagonalRight.isWhite!= isWhite)
                         {
                             GameManager.Instance.Pieces[diagonalRight.x, diagonalRight.y] = null;
                             mouvements.Add(diagonalRight);
                         }
                     }
                 }
                 return mouvements;
             }
         }
         
     }
}