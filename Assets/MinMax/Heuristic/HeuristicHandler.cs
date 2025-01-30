using System;
using System.Collections.Generic;
using Chess;
using Script;
using Unity.VisualScripting;
using UnityEngine;

namespace MinMax.Heuristic
{
    public class HeuristicHandler : MonoBehaviourSingleton<HeuristicHandler>
    {
        private GameManager _gameManager;

        private int _blackPoints;
        private int _whitePoints;
        public int _globalPoints;
        public int _globalBonus;
        private int _positionBonusWhite;
        private int _positionBonusBlack;

        private static Dictionary<Piece, int[,]> positionBonus;
        
        private void Awake()
        {
            _gameManager = GetComponent<GameManager>();
        }

        private void Start()
        {
            positionBonus = new Dictionary<Piece, int[,]>
            {
                {_gameManager.WhitePawn, new int[8,8]
                {
                    {  0,   0,   0,   0,   0,   0,   0,   0 },
                    { 50,  50,  50,  50,  50,  50,  50,  50 },
                    { 10,  10,  20,  30,  30,  20,  10,  10 },
                    {  5,   5,  10,  25,  25,  10,   5,   5 },
                    {  0,   0,   0,  20,  20,   0,   0,   0 },
                    {  5,  -5, -10,   0,   0, -10,  -5,   5 },
                    {  5,  10,  10, -20, -20,  10,  10,   5 },
                    {  0,   0,   0,   0,   0,   0,   0,   0 }
                }},
                
                {_gameManager.BlackPawn, new int[8,8]
                {
                    {  0,   0,   0,   0,   0,   0,   0,   0 },
                    {  5,  10,  10, -20, -20,  10,  10,   5 },
                    {  5,  -5, -10,   0,   0, -10,  -5,   5 },
                    {  0,   0,   0,  20,  20,   0,   0,   0 },
                    {  5,   5,  10,  25,  25,  10,   5,   5 },
                    { 10,  10,  20,  30,  30,  20,  10,  10 },
                    { 50,  50,  50,  50,  50,  50,  50,  50 },
                    {  0,   0,   0,   0,   0,   0,   0,   0 }
                }},
                {_gameManager.WhiteKnight, new int[8,8]
                {
                    { -50, -40, -30, -30, -30, -30, -40, -50 },
                    { -40, -20, 0, 0, 0, 0, -20, -40 },
                    { -30, 0, 10, 15, 15, 10, 0, -30 },
                    { -30, 5, 15, 20, 20, 15, 5, -30 },
                    { -30, 0, 15, 20, 20, 15, 0, -30 },
                    { -30, 5, 10, 15, 15, 10, 5, -30 },
                    { -40, -20, 0, 5, 5, 0, -20, -40 },
                    { -50, -40, -30, -30, -30, -30, -40, -50 }
                }},
                {_gameManager.BlackKnight, new int[8,8]
                {
                    { -50, -40, -30, -30, -30, -30, -40, -50 },
                    { -40, -20, 0, 5, 5, 0, -20, -40 },
                    { -30, 5, 10, 15, 15, 10, 5, -30 },
                    { -30, 0, 15, 20, 20, 15, 0, -30 },
                    { -30, 5, 15, 20, 20, 15, 5, -30 },
                    { -30, 0, 10, 15, 15, 10, 0, -30 },
                    { -40, -20, 0, 0, 0, 0, -20, -40 },
                    { -50, -40, -30, -30, -30, -30, -40, -50 }
                }},
                {_gameManager.WhiteBishop, new int[8,8]
                {
                    { -20, -10, -10, -10, -10, -10, -10, -20 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -10, 0, 5, 10, 10, 5, 0, -10 },
                    { -10, 5, 5, 10, 10, 5, 5, -10 },
                    { -10, 0, 10, 10, 10, 10, 0, -10 },
                    { -10, 10, 10, 10, 10, 10, 10, -10 },
                    { -10, 5, 0, 0, 0, 0, 5, -10 },
                    { -20, -10, -10, -10, -10, -10, -10, -20 }
                }},
                {_gameManager.BlackBishop, new int[8,8]
                {
                    { -20, -10, -10, -10, -10, -10, -10, -20 },
                    { -10, 5, 0, 0, 0, 0, 5, -10 },
                    { -10, 10, 10, 10, 10, 10, 10, -10 },
                    { -10, 0, 10, 10, 10, 10, 0, -10 },
                    { -10, 5, 5, 10, 10, 5, 5, -10 },
                    { -10, 0, 5, 10, 10, 5, 0, -10 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -20, -10, -10, -10, -10, -10, -10, -20 }
                }},
                {_gameManager.WhiteQueen, new int[8,8]
                {
                    { -20, -10, -10, -5, -5, -10, -10, -20 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -10, 0, 5, 5, 5, 5, 0, -10 },
                    { -5, 0, 5, 5, 5, 5, 0, -5 },
                    { 0, 0, 5, 5, 5, 5, 0, -5 },
                    { -10, 5, 5, 5, 5, 5, 0, -10 },
                    { -10, 0, 5, 0, 0, 0, 0, -10 },
                    { -20, -10, -10, -5, -5, -10, -10, -20 }
                }},
                {_gameManager.BlackQueen, new int[8,8]
                {
                    { -20, -10, -10, -5, -5, -10, -10, -20 },
                    { -10, 0, 5, 0, 0, 0, 0, -10 },
                    { -10, 5, 5, 5, 5, 5, 0, -10 },
                    { 0, 0, 5, 5, 5, 5, 0, -5 },
                    { -5, 0, 5, 5, 5, 5, 0, -5 },
                    { -10, 0, 5, 5, 5, 5, 0, -10 },
                    { -10, 0, 5, 0, 0, 0, 0, -10 },
                    { -20, -10, -10, -5, -5, -10, -10, -20 }
                }},
                {_gameManager.WhiteKing, new int[8,8]
                {
                    { -30, -40, -40, -50, -50, -40, -40, -30 },
                    { -30, -40, -40, -50, -50, -40, -40, -30 },
                    { -30, -40, -40, -50, -50, -40, -40, -30 },
                    { -30, -40, -40, -50, -50, -40, -40, -30 },
                    { -20, -30, -30, -40, -40, -30, -30, -20 },
                    { -10, -20, -20, -20, -20, -20, -20, -10 },
                    { 20, 20, 0, 0, 0, 0, 20, 20 },
                    { 20, 30, 10, 0, 0, 10, 30, 20 }
                }},
                {_gameManager.BlackKing, new int[8,8]
                {
                    { 20, 30, 10, 0, 0, 10, 30, 20 },
                    { 20, 20, 0, 0, 0, 0, 20, 20 },
                    { -10, -20, -20, -20, -20, -20, -20, -10 },
                    { -20, -30, -30, -40, -40, -30, -30, -20 },
                    { -30, -40, -40, -50, -50, -40, -40, -30 },
                    { -30, -40, -40, -50, -50, -40, -40, -30 },
                    { -30, -40, -40, -50, -50, -40, -40, -30 },
                    { -30, -40, -40, -50, -50, -40, -40, -30 }
                }}
            };
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Heuristic Update : " + _globalPoints);
                Debug.Log("Bonus Update : " + _globalBonus);
            }
        }

        public int CalculateHeuristic()
        {
            _globalPoints = 0;
            _globalBonus = 0;
            _blackPoints = 0;
            _whitePoints = 0;
            _positionBonusWhite = 0;
            _positionBonusBlack = 0;

            for (int i = 0; i < _gameManager.Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < _gameManager.Pieces.GetLength(1); j++)
                {
                    Piece piece = _gameManager.Pieces[i, j];

                    if (piece != null)
                    {
                        if (piece.isWhite && positionBonus.ContainsKey(piece))
                        {
                            _positionBonusWhite += positionBonus[piece][i,j];
                        }
                        else if (!piece.isWhite && positionBonus.ContainsKey(piece))
                        {
                            _positionBonusBlack += positionBonus[piece][i,j];
                        }
                    }
                }
            }
            
            foreach (Piece piece in _gameManager.Pieces)
            {
                if (piece != null)
                {
                    if (piece.isWhite)
                    { 
                        _whitePoints += piece.Value;
                    }
                    else 
                    { 
                        _blackPoints += piece.Value;
                    }
                }
            }

            if (_gameManager._isWhiteTurn)
            {
                _globalBonus = _positionBonusWhite - _positionBonusBlack;
                _globalPoints = _whitePoints - _blackPoints + _positionBonusWhite - _positionBonusBlack;
            }
            else
            {
                _globalBonus = _positionBonusBlack - _positionBonusWhite;
                _globalPoints = _blackPoints - _whitePoints + _positionBonusBlack - _positionBonusWhite;
            }
            
            return _globalPoints; 
        }
    }
}

