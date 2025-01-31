using System;
using System.Collections.Generic;
using MinMax;
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
        [SerializeField] private int _depth = 2;
        
        private HeuristicHandler _heuristicHandler;
        private AIHandler _aiHandler;
        private bool _initialized = true;
        
        public Piece[,] Pieces;
        public GameObject[,] PiecesDisplay;

        public Piece clickPiece;
        public bool _isWhiteTurn = true;
        public Node bestNode;

        private void Awake()
        {
            _heuristicHandler = GetComponent<HeuristicHandler>();
            _aiHandler = GetComponent<AIHandler>();
        }

        public void Start()
        {
             Pieces = new Piece[,]
            {
                {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, WhiteBishop,null, null,null, null,},
                 {null, null, WhiteRook, BlackKing,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {null, null, null, null,null, null,null, null,},
                 {WhiteKing, null, null, null,null, null,null, null,}
                 
             };
             DisplayMatrix();
         }
        
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Node node = new Node(Pieces, _isWhiteTurn);
                
                Debug.Log(" Children Node : " + node.Children().Count);
                Debug.Log("Heuristic Update : " + node.HeursticValue());
                Debug.Log("Bonus Update : " + HeuristicHandler.Instance._globalBonus);
            }

            if (Input.GetKey(KeyCode.Mouse0) && _initialized)
            {
                _initialized = false;
                Node node = new Node(Pieces, _isWhiteTurn);
                int maxValue = int.MinValue;
                int bestChildrenValue = int.MinValue;
                
                
                Debug.Log(" Children Node : " + node.Children().Count);
                foreach (Node children in node.Children())
                {
                    maxValue = Mathf.Max(maxValue, _aiHandler.MinMax(children, _depth - 1 , false));

                    if (bestChildrenValue < maxValue)
                    {
                        bestChildrenValue = maxValue;
                        bestNode = children;
                    }
                }

                if (bestNode != null)
                {
                    Pieces = bestNode.Pieces;
                    Invoke("ResetBool", 0.5f);
                    // EndTurn();
                }
                
            }
        }

        private void ResetBool()
        {
            _initialized = true;
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



