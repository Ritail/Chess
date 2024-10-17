using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "Bishop", menuName = "Piece/Bishop")]
    public class Bishop : Pièce
    { 
        public override List<Vector2Int> availableMouvments(Vector2Int position)
        {
            List<Vector2Int> mouvements = new List<Vector2Int>();

            // Directions possibles pour le fou (diagonales)
            int[,] directions = new int[,]
            {
                { 1, 1 },   // Diagonale haut droite
                { 1, -1 },  // Diagonale bas droite
                { -1, 1 },  // Diagonale haut gauche
                { -1, -1 }   // Diagonale bas gauche
            };

            // Explorer chaque direction
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                for (int step = 1; step < 8; step++) // On peut se déplacer jusqu'à 7 cases
                {
                    int newX = position.x + directions[i, 0] * step;
                    int newY = position.y + directions[i, 1] * step;

                    Vector2Int newPosition = new Vector2Int(newX, newY);
                    if(IsValidPosition(newPosition))
                    {
                        Pièce pieceAtNewPosition = GameManager.Instance.Pieces[newX, newY];
                        if (pieceAtNewPosition == null)
                        {
                            mouvements.Add(newPosition);
                        }
                        else
                        {
                            if (pieceAtNewPosition.isWhite != this.isWhite)
                            {
                                mouvements.Add(newPosition);
                                Destroy(pieceAtNewPosition);
                            }
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return mouvements;
        }
    } 
    
        
    
}