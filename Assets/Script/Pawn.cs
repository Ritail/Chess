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
             Vector2Int[] blackPawnFirstMoove = new Vector2Int[]
             {
                 new Vector2Int(1,0),
                 new Vector2Int(2,0)
             };
             Vector2Int[] whitePawnFirstMoove = new Vector2Int[]
             {
                 new Vector2Int(-1,0),
                 new Vector2Int(-2,0)
             };
             Vector2Int[] blackPawnMoove = new Vector2Int[]
             {
                 new Vector2Int(1,0)
             };Vector2Int[] whitePawnMoove = new Vector2Int[]
             {
                 new Vector2Int(-1,0)
             };
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
                     foreach (Vector2Int firstFrontB in blackPawnFirstMoove)
                     {
                         Vector2Int firstFrontBlack = position + firstFrontB;
                         if (IsValidPosition(firstFrontBlack))
                         {
                             Pièce pieceAtFirstFrontBlack = GameManager.Instance.Pieces[firstFrontBlack.x, firstFrontBlack.y];
                             if (pieceAtFirstFrontBlack == null)
                             {
                                 mouvements.Add(firstFrontBlack);
                             }
                         }
                     }
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
                 foreach (Vector2Int front in blackPawnMoove)
                 {
                     Vector2Int frontBlack = position + front;
                     if (IsValidPosition(frontBlack))
                     {
                         Pièce pieceAtFrontBlack = GameManager.Instance.Pieces[frontBlack.x, frontBlack.y];
                         if (pieceAtFrontBlack == null)
                         {
                             mouvements.Add(frontBlack);
                         }
                     }
                 }
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
                     foreach (Vector2Int firstFrontW in whitePawnFirstMoove)
                     {
                         Vector2Int firstFrontWhite = position + firstFrontW;
                         if (IsValidPosition(firstFrontWhite))
                         {
                             Pièce pieceAtFirstFrontBlack = GameManager.Instance.Pieces[firstFrontWhite.x, firstFrontWhite.y];
                             if (pieceAtFirstFrontBlack == null)
                             {
                                 mouvements.Add(firstFrontWhite);
                             }
                         }
                     }
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
                 foreach (Vector2Int frontW in whitePawnMoove)
                 {
                     Vector2Int frontWhite = position + frontW;
                     if (IsValidPosition(frontWhite))
                     {
                         Pièce pieceAtFirstFrontBlack = GameManager.Instance.Pieces[frontWhite.x, frontWhite.y];
                         if (pieceAtFirstFrontBlack == null)
                         {
                             mouvements.Add(frontWhite);
                         }
                     }
                 }
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