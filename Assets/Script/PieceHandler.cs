using System.Collections.Generic;
using Chess;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



namespace Chess
{
    public class PieceHandler : MonoBehaviour , IPointerClickHandler
    {
        private Pièce _piece;
        private Image _image;
        private Vector2Int _position;

        [SerializeField] private GameObject _indicateurMouvement;

        

        private void Awake()
        {
                _image = GetComponent<Image>();

        }

        public void Body(Pièce piece, Vector2Int position)
        {
            _piece = piece;
            _position = position;
            _image.sprite = piece.sprite;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.DestroyMatrix();
            GameManager.Instance.Matrix();
            
            List<Vector2Int> positions = _piece.availableMouvments(_position);

            foreach (var move in positions) {
                GameObject pieceGO = GameManager.Instance.PiecesDisplay[move.x, move.y];
                pieceGO.GetComponent<Image>().color = Color.gray;
            }
            
        }
    }
}

