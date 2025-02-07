using System;
using System.Collections.Generic;
using MinMax;
using MinMax.Heuristic;
using Script;
using UnityEngine;
using UnityEngine.Serialization;


namespace Chess
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [Header("<color=white>===== Piece =====</color>")]
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
        [Header("<color=blue>===== Board Settings =====</color>")]
        [SerializeField] private GameObject _piecePrefaf;
        [SerializeField] private GameObject _piecePrefafTransparent;
        [SerializeField] private Transform _girdParent;
        [Header("<color=red>===== Settings =====</color>")]
        [SerializeField] private int _depth = 3;
        [SerializeField] private BoardType _chooseBoard = BoardType.BaseBoard;
        
        private HeuristicHandler _heuristicHandler;
        private AIHandler _aiHandler;
        
        public Piece[,] Pieces;
        public GameObject[,] PiecesDisplay;
        public bool IsWhiteStartTurn;
        public Piece ClickPiece;
        
        [HideInInspector] public bool IsWhiteTurn;

        private void Awake()
        {
            _heuristicHandler = GetComponent<HeuristicHandler>();
            _aiHandler = GetComponent<AIHandler>();
        }

        public void Start()
        {
            SetupBoard(); 
            WhiteKing.IsInCheck = false;
            BlackKing.IsInCheck = false;
            WhiteKing.IsCheckMate = false;
            BlackKing.IsCheckMate = false;
        }
        
        private void Update()
        {

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Node node = new Node(Pieces, IsWhiteTurn, IsWhiteTurn);
                int maxValue = int.MinValue;
                Node bestNode = null;

                var children = node.Children();
                
                foreach (Node child in children)
                {
                    // In Check et In CheckMate
                    // var value = _aiHandler.MinMax(child, _depth - 1 , false);
                    // Debug.Log("Children with heuristic : " + value);
                    // Rules.FindKing(child.Pieces,IsWhiteTurn);
                    // if (Rules.IsKingInCheck(child.Pieces, IsWhiteTurn))
                    // {
                    //     if (IsWhiteTurn) 
                    //     {
                    //         WhiteKing.IsInCheck = true;
                    //         Debug.Log("White King in Check");
                    //         if (Rules.IsCheckMate(Pieces, IsWhiteTurn))
                    //         {
                    //             WhiteKing.IsCheckMate = true;
                    //             Debug.Log("White King in CheckMate");
                    //         }
                    //     }
                    //     else
                    //     {
                    //         BlackKing.IsInCheck = true;
                    //         Debug.Log("Black King in Check");
                    //         if (Rules.IsCheckMate(Pieces, IsWhiteTurn))
                    //         {
                    //             BlackKing.IsCheckMate = true;
                    //             Debug.Log("Black King in CheckMate");
                    //         } 
                    //     }
                    // }
                    // else
                    // {
                    //     if (IsWhiteTurn)
                    //     {
                    //         WhiteKing.IsInCheck = false;
                    //         Debug.Log("White King not Check");
                    //     }
                    //     else
                    //     {
                    //         BlackKing.IsInCheck = false;
                    //         Debug.Log("Black King not Check");
                    //     }
                    // }
                    var value = _aiHandler.MinMax(child, _depth - 1 , false);
                    if (value > maxValue)
                    {
                        maxValue = value;
                        bestNode = child;
                    }
                }

                if (bestNode != null)
                {
                    Pieces = bestNode.Pieces;
                    EndTurn();
                }
                
            }
        }

        [ContextMenu("Setup Board")]
        public void SetupBoard()
        {
            Pieces = BoardList.BoardSelector(_chooseBoard);
            
            IsWhiteTurn = IsWhiteStartTurn;
            DestroyMatrix();
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
            DestroyMatrix();
            DisplayMatrix(); 
            IsWhiteTurn = !IsWhiteTurn;
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



