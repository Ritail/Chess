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
                for (int step = 1; step < 8; step++) 
                {
                    int newX = position.x + directions[i, 0] * step;
                    int newY = position.y + directions[i, 1] * step;

                    Vector2Int newPosition = new Vector2Int(newX, newY);
                    
                    if (IsValidPosition(newPosition))
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