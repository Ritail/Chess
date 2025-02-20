 using System.Collections.Generic;
 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Pawn", menuName = "Piece/Pawn")]
     public class Pawn : Piece
     {
         public override List<Vector2Int> availableMovements(Vector2Int position, Piece[,] pieces)
         {
             List<Vector2Int> mouvements = new List<Vector2Int>();
             Vector2Int[] blackPawnFirstMoove = new Vector2Int[]
             {
                 new Vector2Int(2,0)
             };
             Vector2Int[] whitePawnFirstMoove = new Vector2Int[]
             {
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
                     bool check = false;
                     foreach (Vector2Int firstFrontB in blackPawnMoove)
                     {
                         Vector2Int firstFrontBlack = position + firstFrontB;
                         if (IsValidPosition(firstFrontBlack))
                         {
                             Piece pieceAtFirstFrontBlack = pieces[firstFrontBlack.x, firstFrontBlack.y];
                             if (pieceAtFirstFrontBlack == null)
                             {
                                 check = true;
                                 mouvements.Add(firstFrontBlack);
                             }
                         }
                     }

                     if (check == true)
                     {
                         foreach (Vector2Int firstFrontB in blackPawnFirstMoove)
                         {
                             Vector2Int firstFrontBlack = position + firstFrontB;
                             if (IsValidPosition(firstFrontBlack))
                             {
                                 Piece pieceAtFirstFrontBlack = pieces[firstFrontBlack.x, firstFrontBlack.y];
                                 if (pieceAtFirstFrontBlack == null)
                                 {
                                     mouvements.Add(firstFrontBlack);
                                 }
                             }
                         }
                     }
                     foreach (Vector2Int eat in blackPawnEat)
                     {
                         Vector2Int diagonalRight = position + eat;
                         if (IsValidPosition(diagonalRight))
                         {
                             Piece pieceAtDiagonalRight = pieces[diagonalRight.x, diagonalRight.y];
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
                         Piece pieceAtFrontBlack = pieces[frontBlack.x, frontBlack.y];
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
                         Piece pieceAtDiagonalRight = pieces[diagonalRight.x, diagonalRight.y];
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
                     bool check = false;
                     foreach (Vector2Int frontW in whitePawnMoove)
                     {
                         Vector2Int frontWhite = position + frontW;
                         if (IsValidPosition(frontWhite))
                         {
                             Piece pieceAtFirstFrontBlack = pieces[frontWhite.x, frontWhite.y];
                             if (pieceAtFirstFrontBlack == null)
                             {
                                 check = true;
                                 mouvements.Add(frontWhite);
                             }
                         }
                     }

                     if (check == true)
                     {
                         foreach (Vector2Int firstFrontW in whitePawnFirstMoove)
                         {
                             Vector2Int firstFrontWhite = position + firstFrontW;
                             if (IsValidPosition(firstFrontWhite))
                             {
                                 Piece pieceAtFirstFrontBlack = pieces[firstFrontWhite.x, firstFrontWhite.y];
                                 if (pieceAtFirstFrontBlack == null)
                                 {
                                     mouvements.Add(firstFrontWhite);
                                 }
                             }
                         }
                     }
                     
                     foreach (Vector2Int eat in whitePawnEat)
                     {
                         Vector2Int diagonalRight = position + eat;
                         if (IsValidPosition(diagonalRight))
                         {
                             Piece pieceAtDiagonalRight = pieces[diagonalRight.x, diagonalRight.y];
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
                         Piece pieceAtFirstFrontBlack = pieces[frontWhite.x, frontWhite.y];
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
                         Piece pieceAtDiagonalRight = pieces[diagonalRight.x, diagonalRight.y];
                         if (pieceAtDiagonalRight != null && pieceAtDiagonalRight.isWhite!= isWhite)
                         {
                             pieces[diagonalRight.x, diagonalRight.y] = null;
                             mouvements.Add(diagonalRight);
                         }
                     }
                 }
                 return mouvements;
             }
         }
         
     }
}