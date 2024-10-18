using Script;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Chess
{
        public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [SerializeField] private Pièce BlackPawn;
        [SerializeField] private Pièce WhitePawn;
        [SerializeField] private Pièce WhiteRook;
        [SerializeField] private Pièce BlackRook;
        [SerializeField] private Pièce WhiteKnight;
        [SerializeField] private Pièce BlackKnight;
        [SerializeField] private Pièce WhiteBishop;
        [SerializeField] private Pièce BlackBishop;
        [SerializeField] private Pièce WhiteKing;
        [SerializeField] private Pièce BlackKing;
        [SerializeField] private Pièce WhiteQueen;
        [SerializeField] private Pièce BlackQueen;

        [SerializeField] private GameObject _piecePrefaf;
        [SerializeField] private GameObject _piecePrefafTransparent;
        [SerializeField] private Transform _girdParent;
        
        public Pièce[,] Pieces;
        public GameObject[,] PiecesDisplay;

        public Pièce clickPiece;
        public bool _isWhiteTurn = true;

    
        public void Start()
         {
             Pieces = new Pièce[,]
            {
                 { BlackRook, BlackKnight, BlackBishop, BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackRook},
                 { BlackPawn,  BlackPawn, BlackPawn, BlackPawn,BlackPawn, BlackPawn,BlackPawn, BlackPawn},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,BlackKing, null,},
                 { WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn},
                 { WhiteRook, WhiteKnight, WhiteBishop, WhiteKing, WhiteQueen, WhiteBishop, WhiteKnight, WhiteRook}
                 
             };
             DisplayMatrix();
         }

        public void DisplayMatrix()
        {
            PiecesDisplay = new GameObject[Pieces.GetLength(0), Pieces.GetLength(1)];
            
            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    GameObject newPièce;
                    if (Pieces[i, j] != null) 
                    {
                         newPièce = Instantiate(_piecePrefaf, _girdParent);
                         newPièce.GetComponent<PieceHandler>().Body(Pieces[i,j], new Vector2Int(i, j));
                    }
                    else
                    {
                        newPièce = Instantiate(_piecePrefafTransparent, _girdParent);
                        newPièce.GetComponent<PieceHandler>().PositionBody(new Vector2Int(i, j));
                    }

                    PiecesDisplay[i, j] = newPièce;
                    newPièce.GetComponent<BoxCollider2D>();
                } 
            }
        }
        public void EndTurn()
        {
            _isWhiteTurn = !_isWhiteTurn; // Alterner entre les blancs et les noirs
            DestroyMatrix();
            DisplayMatrix(); // Réafficher les pièces avec la mise à jour des interactions
        }

        public void DestroyMatrix()
        {
            foreach (Transform child in _girdParent.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}



