using System;
using MinMax.Heuristic;
using Script;
using UnityEngine;


namespace Chess
{
        public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public Piece BlackPawn;
        public Piece WhitePawn;
        public Piece WhiteRook;
        public Piece BlackRook;
        public Piece WhiteKnight;
        public Piece BlackKnight;
        public Piece WhiteBishop;
        public Piece BlackBishop;
        public Piece WhiteKing;
        public Piece BlackKing;
        public Piece WhiteQueen; 
        public Piece BlackQueen;

        [SerializeField] private GameObject _piecePrefaf;
        [SerializeField] private GameObject _piecePrefafTransparent;
        [SerializeField] private Transform _girdParent;
        
        private HeuristicHandler _heuristicHandler;
        
        public Piece[,] Pieces;
        public GameObject[,] PiecesDisplay;

        public Piece clickPiece;
        public bool _isWhiteTurn = true;


        private void Awake()
        {
            _heuristicHandler = GetComponent<HeuristicHandler>();
        }

        public void Start()
        {
             Pieces = new Piece[,]
            {
                 { BlackRook, BlackKnight, BlackBishop, BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackRook},
                 { BlackPawn,  BlackPawn, BlackPawn, BlackPawn,BlackPawn, BlackPawn,BlackPawn, BlackPawn},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
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
            int heuristicScore = _heuristicHandler.CalculateHeuristic();
            Debug.Log("Heuristic = " + heuristicScore);
            _isWhiteTurn = !_isWhiteTurn;
            DestroyMatrix();
            DisplayMatrix(); 
            
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



