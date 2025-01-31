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
        
        public Piece[,] Pieces;
        public GameObject[,] PiecesDisplay;
        public bool IsWhiteStartTurn;
        public Piece clickPiece;
        
        [HideInInspector] public bool IsWhiteTurn;

        private void Awake()
        {
            _heuristicHandler = GetComponent<HeuristicHandler>();
            _aiHandler = GetComponent<AIHandler>();
        }

        public void Start()
        {
            SetupBoard(); 
        }
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Node node = new Node(Pieces, IsWhiteTurn, IsWhiteTurn);
                
                Debug.Log(" Children Node : " + node.Children().Count);
                Debug.Log("Heuristic Update : " + node.HeursticValue());
                Debug.Log("Bonus Update : " + HeuristicHandler.Instance._globalBonus);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Node node = new Node(Pieces, IsWhiteTurn, IsWhiteTurn);
                int maxValue = int.MinValue;
                Node bestNode = null;

                var children = node.Children();
                Debug.Log(" Children Node : " + children.Count);
                foreach (Node child in children)
                {
                    var value = _aiHandler.MinMax(child, _depth - 1 , false);
                    Debug.Log("Children with heuristic : " + value);
                    
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



