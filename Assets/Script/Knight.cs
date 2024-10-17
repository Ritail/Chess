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

             // Explorer chaque mouvement
             foreach (Vector2Int move in knightMoves)
             {
                 Vector2Int newPosition = position + move;

                 // Vérifiez si la nouvelle position est valide
                 if (IsValidPosition(newPosition))
                 {
                     // Récupérer la pièce à la nouvelle position dans la matrice du GameManager
                     Pièce pieceAtNewPosition = GameManager.Instance.Pieces[newPosition.x, newPosition.y];

                     if (pieceAtNewPosition == null)
                     {
                         // Si la case est vide, ajouter le mouvement
                         mouvements.Add(newPosition);
                     }
                     else
                     {
                         // Si la case est occupée par une pièce de couleur différente, on peut la capturer
                         if (pieceAtNewPosition.isWhite != this.isWhite)
                         {
                             mouvements.Add(newPosition);
                         }
                         // Si la case est occupée par une pièce de la même couleur, on ne peut pas y aller
                     }
                 }
             }

             return mouvements;
         }

         private bool IsValidPosition(Vector2Int pos)
         {
             // Vérifiez si la position est à l'intérieur des limites du plateau (8x8 pour un échiquier)
             return pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8;
         }
     }
 }