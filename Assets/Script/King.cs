using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "King", menuName = "Piece/King")]
    public class King : Pièce
    {
        public override List<Vector2Int> availableMouvments(Vector2Int position)
        {
            List<Vector2Int> mouvements = new List<Vector2Int>();
            Vector2Int[] kingMoves = new Vector2Int[]
            {
                new Vector2Int(1, 0),   // Droite
                new Vector2Int(-1, 0),  // Gauche
                new Vector2Int(0, 1),   // Haut
                new Vector2Int(0, -1),  // Bas
                new Vector2Int(1, 1),   // Diagonale Haut-Droite
                new Vector2Int(1, -1),  // Diagonale Bas-Droite
                new Vector2Int(-1, 1),  // Diagonale Haut-Gauche
                new Vector2Int(-1, -1)  // Diagonale Bas-Gauche
            };

            // Explorer chaque mouvement possible
            foreach (Vector2Int move in kingMoves)
            {
                Vector2Int newPosition = position + move;

                // Vérifiez si la nouvelle position est valide (sur le plateau)
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
                    }
                }
            }


            return mouvements;
        }

        
    }
}