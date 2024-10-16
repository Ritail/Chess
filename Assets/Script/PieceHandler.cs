using System;
using System.Collections.Generic;
using Chess;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


namespace Chess
{
    public class PieceHandler : MonoBehaviour , IPointerClickHandler
    {
        private Pièce _piece;
        private Image _image;
        private Vector2Int _position;
        private Vector2Int _oldPosition;
        private Vector2Int _deplacer;
        private AvailableMouvement _availableMouvement;
        private bool _isAValidMovement;

        [SerializeField] private GameObject _indicateurMouvement;

        

        private void Awake()
        {
                _image = GetComponent<Image>();
                _availableMouvement = GetComponent<AvailableMouvement>();
        }

        public void Body(Pièce piece, Vector2Int position)
        {
            _piece = piece;
            _position = position;
            _image.sprite = piece.sprite;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            // GameManager.Instance.DestroyMatrix();
            // GameManager.Instance.DisplayMatrix();

            GameManager.Instance.clickPiece = gameObject;
            
            if (_isAValidMovement)
            {
                
                _isAValidMovement = false;
            }
            else
            {
                List<Vector2Int> positions = _piece.availableMouvments(_position);
                foreach (Vector2Int possiblemove in positions) {
                
                    GameObject pieceGO = GameManager.Instance.PiecesDisplay[possiblemove.x, possiblemove.y];
                    PieceHandler possiblePieceHandler = pieceGO.GetComponent<PieceHandler>();
                    possiblePieceHandler.DefineAsPossibleMove(_position);
                }
            }
            
        }

        private void DefineAsPossibleMove(Vector2Int position)
        {
            GetComponent<Image>().color = Color.gray;
            _isAValidMovement = true;
            _oldPosition = position;
            Debug.Log("ancienne position : " + _oldPosition);
        }

        public void Deplacer(Vector2Int position)
        {
            GameManager.Instance.Pieces[_position.x, _position.y] = null;
            GameManager.Instance.Pieces[position.x, position.y] = _piece;
            transform.localPosition = new Vector2(position.x, position.y);
        }
    }
       
}

