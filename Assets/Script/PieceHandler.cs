using System.Collections.Generic;
using Script;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;


namespace Chess
{
    public class PieceHandler : MonoBehaviour , IPointerClickHandler
    {
        private Piece _piece;
        private Image _image;
        public Vector2Int _position;
        private Vector2Int _oldPosition;
        private Vector2Int _deplacer;
        private bool _isFirtClick = true;
        public bool _isAValidMovement;

        [SerializeField] private GameObject _indicateurMouvement;
        
        private void Awake()
        { 
            _image = GetComponent<Image>();
        }

        public void Body(Piece piece, Vector2Int position)
        {
            _piece = piece;
            _position = position;
            _image.sprite = piece.sprite;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            GameManager.Instance.DestroyMatrix();
            GameManager.Instance.DisplayMatrix();
            if (_isAValidMovement)
            {
                _isAValidMovement = false;
                Piece movingPiece = GameManager.Instance.Pieces[_oldPosition.x, _oldPosition.y];
                GameManager.Instance.Pieces[_oldPosition.x, _oldPosition.y] = null;
                GameManager.Instance.Pieces[_position.x, _position.y] = movingPiece;
                GameManager.Instance.EndTurn();
                _isFirtClick = true;
            }
            if (_piece == null)
            {
                return;
            }
            else
            {
                if (_isFirtClick)
                {
                    if ((GameManager.Instance.IsWhiteTurn && !_piece.isWhite) || (!GameManager.Instance.IsWhiteTurn && _piece.isWhite))
                    {
                        Debug.Log("Ce n'est pas le tour de cette pièce.");
                        return; 
                    }
                
                    List<Vector2Int> positions = _piece.availableMovements(_position, GameManager.Instance.Pieces);
                
                    foreach (Vector2Int possiblemove in positions) 
                    {
                        GameObject pieceGO = GameManager.Instance.PiecesDisplay[possiblemove.x, possiblemove.y];
                        PieceHandler possiblePieceHandler = pieceGO.GetComponent<PieceHandler>();
                        possiblePieceHandler.DefineAsPossibleMove(_position);
                    }
                }
            }
            
        }

        public void DefineAsPossibleMove(Vector2Int position)
        {
            GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            _isAValidMovement = true;
            _isFirtClick = false;
            _oldPosition = position;
            GameManager.Instance.ClickPiece = _piece; 
        }
        
        public void PositionBody(Vector2Int recuperationposition)
        {
            _position = recuperationposition;
        }
    }
       
}

