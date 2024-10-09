using Chess;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;
using Script;


namespace Chess
{
    public class PieceHandler : MonoBehaviour , IPointerClickHandler
    {
        private Pièce _piece;
        private Image _image;
        private Vector2Int _position;
        
        public Pièce[,] Pieces;



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
            GameObject clickPiece = gameObject;

            // List<Vector2Int> positions = _piece.availableMouvments();
            Vector2Int mouvement = Vector2Int.right;
            Vector2Int NewPosition = _position + mouvement;

            GameManager.Instance.Pieces[_position.x, _position.y] = null;
            GameManager.Instance.Pieces[NewPosition.x, NewPosition.y] = _piece;
            GameManager.Instance.Matix();


             if (eventData.button == PointerEventData.InputButton.Left)   
             {
                 
                 GameObject gameObjectClique = eventData.pointerPress; // Récupère directement le GameObject cliqué
                 Debug.Log("GameObject cliqué : " + gameObjectClique.name);
             }    
        }
    }
}

