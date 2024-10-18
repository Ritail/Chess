using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        public bool _isAValidMovement;

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
            GameManager.Instance.DisplayMatrix();
            if (_isAValidMovement)
            {
                _isAValidMovement = false;
                Pièce movingPiece = GameManager.Instance.Pieces[_oldPosition.x, _oldPosition.y];
                GameManager.Instance.Pieces[_oldPosition.x, _oldPosition.y] = null;
                GameManager.Instance.Pieces[_position.x, _position.y] = movingPiece;
                Debug.Log("position :" + _position);
                GameManager.Instance.EndTurn();
            }
            if (_piece == null)
            {
                return;
            }
            else
            {
                if ((GameManager.Instance._isWhiteTurn && !_piece.isWhite) || (!GameManager.Instance._isWhiteTurn && _piece.isWhite))
                {
                    Debug.Log("Ce n'est pas le tour de cette pièce.");
                    return; 
                }
                
                List<Vector2Int> positions = _piece.availableMouvments(_position);
                
                foreach (Vector2Int possiblemove in positions) 
                {
                    GameObject pieceGO = GameManager.Instance.PiecesDisplay[possiblemove.x, possiblemove.y];
                    PieceHandler possiblePieceHandler = pieceGO.GetComponent<PieceHandler>();
                    possiblePieceHandler.DefineAsPossibleMove(_position);
                    Debug.Log("moove possible" + possiblemove);
                }
            }
            
        }

        public void DefineAsPossibleMove(Vector2Int position)
        {
            GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            _isAValidMovement = true;
            _oldPosition = position;
            GameManager.Instance.clickPiece = _piece; 
            Debug.Log("ancienne position : " + _oldPosition);
        }
        
        public void PositionBody(Vector2Int recuperationposition)
        {
            _position = recuperationposition;
        }
    }
       
}

