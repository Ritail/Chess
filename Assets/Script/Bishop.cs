using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "Bishop", menuName = "Piece/Bishop")]
    public class Bishop : Pièce
    {
        public override Vector2Int availableMouvments()
        {
            throw new System.NotImplementedException();
        }
    }
}