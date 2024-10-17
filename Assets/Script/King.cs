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

            // Directions possibles pour le roi (toutes les cases autour)
            int[,] directions = new int[,]
            {
                { 1, 0 },   // Droite
                { -1, 0 },  // Gauche
                { 0, 1 },   // Haut
                { 0, -1 },  // Bas
                { 1, 1 },   // Diagonale haut droite
                { 1, -1 },  // Diagonale bas droite
                { -1, 1 },  // Diagonale haut gauche
                { -1, -1 }   // Diagonale bas gauche
            };

            // Explorer chaque direction
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newX = position.x + directions[i, 0];
                int newY = position.y + directions[i, 1];

                Vector2Int newPosition = new Vector2Int(newX, newY);
                // Vérifiez si la nouvelle position est valide (dans les limites du plateau)
                if (IsValidPosition(newPosition))
                {
                    mouvements.Add(newPosition);
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