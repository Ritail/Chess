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
            int[] directionsX = { 1, -1, 1, -1 };
            int[] directionsY = { 1, 1, -1, -1 };
            
            if (isWhite != true)
            { 
                
                for (int i = 0; i < 4; i++)
                {
                    int x = position.x + directionsX[i];
                    int y = position.y + directionsY[i];
            
                    while (true)
                    {
                        Vector2Int newPosition = new Vector2Int(x, y);
                        mouvements.Add(newPosition);
                        mouvements.Add(new Vector2Int(1,0) + position);
                        mouvements.Add(new Vector2Int(-1,0) + position);
                        mouvements.Add(new Vector2Int(0,1) + position);
                        mouvements.Add(new Vector2Int(0,-1) + position);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int x = position.x + directionsX[i];
                    int y = position.y + directionsY[i];
            
                    while (x > 0 && x < 8 && y > 0 && y < 8)
                    {
                        Vector2Int newPosition = new Vector2Int(x, y);
                        mouvements.Add(newPosition);
                        mouvements.Add(new Vector2Int(1,0) + position);
                        mouvements.Add(new Vector2Int(-1,0) + position);
                        mouvements.Add(new Vector2Int(0,1) + position);
                        mouvements.Add(new Vector2Int(0,-1) + position);
                    }
                }
            }
            return mouvements;
        }
    }
}