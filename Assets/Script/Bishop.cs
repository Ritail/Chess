using System.Collections.Generic;
using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "Bishop", menuName = "Piece/Bishop")]
    public class Bishop : Pièce
    {
        private bool _hautDroite = true;
        private bool _hautGauche = true;
        private bool _basDroite = true;
        private bool _basGauche = true;
        private Vector2Int _basDroit = new Vector2Int(1,1) ; 
        private Vector2Int _basGauch = new Vector2Int(-1,1) ;
        private Vector2Int _hautDroit = new Vector2Int(1,-1);
        private Vector2Int _hautGauch = new Vector2Int(-1,-1);
        public override List<Vector2Int> availableMouvments(Vector2Int position)
        {
            List<Vector2Int> mouvements = new List<Vector2Int>();
            int[] directionsX = { 1, -1, 1, -1 };
            int[] directionsY = { 1, 1, -1, -1 };
            
            if (isWhite != true)
            {
                for (int i = 0; i < 8; i++)
                {
                    int x = position.x + directionsX[i];
                    int y = position.y + directionsY[i];
                    while (true)
                    {
                        Vector2Int newPosition = new Vector2Int(x, y);
                        mouvements.Add(newPosition);

                        //if (GameManager.Instance.PiecesDisplay != null)
                        {
                            //if (isWhite)
                            {
                                //mouvements.Add(newPosition);
                            }
                            //else
                            {
                                //break;  
                            }
                        }
                        break;
                    }
                }
            }
            return mouvements;
        }     
    }
}