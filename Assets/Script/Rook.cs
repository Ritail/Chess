 using System.Collections.Generic;
 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Rook", menuName = "Piece/Rook")]
     public class Rook : Pièce
     {
          private Vector2Int _currentUp = new Vector2Int(1,0) ;
         // private Vector2Int _currentRight = new Vector2Int(0,1);
        public override List<Vector2Int> availableMouvments(Vector2Int position)
        { 
            List<Vector2Int> mouvements = new List<Vector2Int>();

            // Directions possibles pour la tour (horizontalement et verticalement)
            int[,] directions = new int[,]
            {
                { 1, 0 },  // Droite
                { -1, 0 }, // Gauche
                { 0, 1 },  // Haut
                { 0, -1 }  // Bas
            };

            // Explorer chaque direction
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                for (int step = 1; step < 8; step++) // On peut se déplacer jusqu'à 7 cases
                {
                    int newX = position.x + directions[i, 0] * step;
                    int newY = position.y + directions[i, 1] * step;

                    Vector2Int newPosition = new Vector2Int(newX, newY);

                    // Vérifiez si la nouvelle position est valide
                    if (IsValidPosition(newPosition))
                    {
                        Pièce pieceAtNewPosition = GameManager.Instance.Pieces[newX, newY];
                        
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

                            // Arrêter d'explorer dans cette direction
                            break;
                        }
                    }
                    else
                    {
                        // Sortir de la boucle si la position n'est pas valide
                        break;
                    }
                }
            }

            return mouvements;
        }

    }
 }