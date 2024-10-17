using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Chess
{
    public class AvailableMouvement : MonoBehaviour , IPointerClickHandler
    {
        private Vector2Int _positiont;

        public Pièce[,] Pieces;

        public Vector2Int PositionBody(Vector2Int recuperationposition)
        {
            _positiont = recuperationposition;
            return recuperationposition;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.clickPiece.GetComponent<PieceHandler>().Deplacer(_positiont);
            GameManager.Instance.DestroyMatrix();
            GameManager.Instance.DisplayMatrix();
        }
    }
}

