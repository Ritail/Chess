using UnityEngine;

namespace Chess
{
    [CreateAssetMenu(fileName = "King", menuName = "Piece/King")]
    public class King : Pièce
    {
        public override Vector2Int[] availableMouvments()
        {
            throw new System.NotImplementedException();
        }
    }
}