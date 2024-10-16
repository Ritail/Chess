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

            for (int i = 0; i < 4; i++)
            {
                int x = position.x;
                int y = position.y;
                
                while (true)
                {
                    x += position.x;
                    
                    if (x < 0 || x > 7 || y < 0 || y > 7)
                    {
                        break;
                    }

                    Vector2Int newPosition = new Vector2Int(x, y);
                    
                    if (GameManager.Instance.PiecesDisplay[x, y] != null)
                    {
                        if (GameManager.Instance.PiecesDisplay[x, y] && isWhite)
                        {
                            mouvements.Add(newPosition); 
                        }
                        break; 
                    }
                    mouvements.Add(newPosition);
                }
            }

            return mouvements;
        }
        
    }
 }