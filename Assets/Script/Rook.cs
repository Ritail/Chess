 using System.Collections.Generic;
 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Rook", menuName = "Piece/Rook")]
     public class Rook : Pièce
     {
         private Vector2Int _currentUp ;
         private Vector2Int _currentRight;
        public override List<Vector2Int> availableMouvments(Vector2Int position)
        {
             
            List<Vector2Int> mouvements = new List<Vector2Int>();
            int[] directionX = {1,-1,0,0};
            int[] directionY = {0,0,1,-1};

            if (isWhite != true)
            {
                for (int i = 0; i < 4; i++)
                {
                    int x = position.x + directionX[i];
                    int y = position.y + directionY[i];
                    while (x >= 0 && x < 8 && y >= 0 && y < 8)
                    {
                        Vector2Int newPosition = new Vector2Int(x, y);
                        mouvements.Add(newPosition);
                    }
                    
                }
            }
            return mouvements;
        }
        
    }
 }