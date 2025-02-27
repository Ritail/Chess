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

        private int _blackPoints;
        private int _whitePoints;
        public int _globalPoints;
        public int _globalBonus;
        private int _positionBonusWhite;
        private int _positionBonusBlack;

        private static Dictionary<Piece, int[,]> positionBonus;

        private void Start()
        {
            positionBonus = new Dictionary<Piece, int[,]>
            {
                {GameManager.Instance.WhitePawn, new int[8,8]
                {
                    {  0,   0,   0,   0,   0,   0,   0,   0 },
                    { 90,  90,  90,  90,  90,  90,  90,  90 },
                    { 30,  30,  40,  60,  60,  40,  30,  30 },
                    {  10,   10,  20,  40,  40,  20, 10, 10},
                    {  5,   5, 10,  20,  20,   10,   5,   5 },
                    {  0,  0, 0,   -10,   -10, 0,  0,   0 },
                    {  5,  -5,  -10, 0, 0,  -10,  -5,   5 },
                    {  0,   0,   0,   0,   0,   0,   0,   0 }
                }},
                
                {GameManager.Instance.BlackPawn, new int[8,8]
                {
                    {  0,   0,   0,   0,   0,   0,   0,   0 },
                    {  5,  -5,  -10, 0, 0,  -10,  -5,   5 },
                    {  0,  0, 0,   -10,   -10, 0,  0,   0 },
                    {  5,   5, 10,  20,  20,   10,   5,   5 },
                    {  10,   10,  20,  40,  40,  20, 10, 10},
                    { 30,  30,  40,  60,  60,  40,  30,  30 },
                    { 90,  90,  90,  90,  90,  90,  90,  90 },
                    {  0,   0,   0,   0,   0,   0,   0,   0 }
                }},
                {GameManager.Instance.WhiteKnight, new int[8,8]
                {
                    { -50, -40, -30, -30, -30, -30, -40, -50 },
                    { -40, -20, 0, 5, 5, 0, -20, -40 },
                    { -30, 5, 10, 15, 15, 10, 5, -30 },
                    { -30, 5, 15, 20, 20, 15, 5, -30 },
                    { -30, 5, 15, 20, 20, 15, 5, -30 },
                    { -30, 5, 10, 15, 15, 10, 5, -30 },
                    { -40, -20, 0, 0, 0, 0, -20, -40 },
                    { -50, -40, -30, -30, -30, -30, -40, -50 }
                }},
                {GameManager.Instance.BlackKnight, new int[8,8]
                {
                    { -50, -40, -30, -30, -30, -30, -40, -50 },
                    { -40, -20, 0, 0, 0, 0, -20, -40 },
                    { -30, 5, 10, 15, 15, 10, 5, -30 },
                    { -30, 5, 15, 20, 20, 15, 5, -30 },
                    { -30, 5, 15, 20, 20, 15, 5, -30 },
                    { -30, 5, 10, 15, 15, 10, 5, -30 },
                    { -40, -20, 0, 5, 5, 0, -20, -40 },
                    { -50, -40, -30, -30, -30, -30, -40, -50 }
                }},
                {GameManager.Instance.WhiteBishop, new int[8,8]
                {
                    { -20, -10, -10, -10, -10, -10, -10, -20 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -10, 0, 5, 10, 10, 5, 0, -10 },
                    { -10, 5, 5, 10, 10, 5, 5, -10 },
                    { -10, 0, 10, 15, 15, 10, 0, -10 },
                    { -10, 10, 10, 10, 10, 10, 10, -10 },
                    { -10, 5, 0, 0, 0, 0, 5, -10 },
                    { -20, -10, -10, -10, -10, -10, -10, -20 }
                }},
                {GameManager.Instance.BlackBishop, new int[8,8]
                {
                    { -20, -10, -10, -10, -10, -10, -10, -20 },
                    { -10, 5, 0, 0, 0, 0, 5, -10 },
                    { -10, 10, 10, 10, 10, 10, 10, -10 },
                    { -10, 0, 10, 15, 15, 10, 0, -10 },
                    { -10, 5, 5, 10, 10, 5, 5, -10 },
                    { -10, 0, 5, 10, 10, 5, 0, -10 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -20, -10, -10, -10, -10, -10, -10, -20 }
                }},
                {GameManager.Instance.WhiteRook, new int[8,8]
                {
                { 0,  0,  0,  0,  0,  0,  0,  0},
                {  5, 20, 20, 20, 20, 20, 20,  5},
                { -5,  0,  0,  0,  0,  0,  0, -5},
                { -5,  0,  0,  0,  0,  0,  0, -5},
                { -5,  0,  0,  0,  0,  0,  0, -5},
                {  -5,  0,  0,  0,  0,  0,  0, -5},
                { -5,  0,  0,  0,  0,  0,  0, -5},
                {  0,  0,  0,  5,  5,  0,  0,  0}
                }},
                {GameManager.Instance.BlackRook, new int[8,8]
                {
                    { 0,  0,  0,  5,  5,  0,  0,  0},
                    { -5,  0,  0,  0,  0,  0,  0, -5},
                    {-5,  0,  0,  0,  0,  0,  0, -5},
                    {-5,  0,  0,  0,  0,  0,  0, -5},
                    {-5,  0,  0,  0,  0,  0,  0, -5},
                    {-5,  0,  0,  0,  0,  0,  0, -5},
                    { 5, 20, 20, 20, 20, 20, 20,  5},
                    {0,  0,  0,  0,  0,  0,  0,  0}
                }},
                {GameManager.Instance.WhiteQueen, new int[8,8]
                {
                    { -20, -10, -10, -5, -5, -10, -10, -20 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -10, 0, 5, 5, 5, 5, 0, -10 },
                    { -5, 0, 5, 10, 10, 5, 0, -5 },
                    { -5, 0, 5, 10, 10, 5, 0, -5 },
                    { -10, 0, 5, 5, 5, 5, 0, -10 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -20, -10, -10, -5, -5, -10, -10, -20 }
                }},
                {GameManager.Instance.BlackQueen, new int[8,8]
                {
                    { -20, -10, -10, -5, -5, -10, -10, -20 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -10, 0, 5, 5, 5, 5, 0, -10 },
                    { -5, 0, 5, 10, 10, 5, 0, -5 },
                    { -5, 0, 5, 10, 10, 5, 0, -5 },
                    { -10, 0, 5, 5, 5, 5, 0, -10 },
                    { -10, 0, 0, 0, 0, 0, 0, -10 },
                    { -20, -10, -10, -5, -5, -10, -10, -20 }
                }},
                {GameManager.Instance.WhiteKing, new int[8,8]
                {
                    { 50,-30,-30,-30,-30,-30,-30,-50},
                    {-30,-30,  0,  0,  0,  0,-30,-30},
                    {-30,-10, 20, 30, 30, 20,-10,-30},
                    {-30,-10, 30, 40, 40, 30,-10,-30},
                    {-30,-10, 30, 40, 40, 30,-10,-30},
                    { -30,-10, 20, 30, 30, 20,-10,-30},
                    { -30,-20,-10,  0,  0,-10,-20,-30},
                    { -50,-40,-30,-20,-20,-30,-40,-50}
                }},
                {GameManager.Instance.BlackKing, new int[8,8]
                {
                    { -50,-40,-30,-20,-20,-30,-40,-50},
                    {-30,-20,-10,  0,  0,-10,-20,-30},
                    { -30,-10, 20, 30, 30, 20,-10,-30},
                    { -30,-10, 30, 40, 40, 30,-10,-30},
                    { -30,-10, 30, 40, 40, 30,-10,-30},
                    { -30,-10, 20, 30, 30, 20,-10,-30},
                    { -30,-30,  0,  0,  0,  0,-30,-30},
                    { -50,-30,-30,-30,-30,-30,-30,-50}
                }}
            };
        }

        public int CalculateHeuristic(Piece[,] pieces, bool isWhite, bool isWhiteCheck)
        {
            _globalPoints = 0;
            _globalBonus = 0;
            _blackPoints = 0;
            _whitePoints = 0;
            _positionBonusWhite = 0;
            _positionBonusBlack = 0;

            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    Piece piece = pieces[i, j];
            
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
            }
            
            // if (Rules.IsKingInCheck(pieces, isWhite))
            // {
            //     if (isWhite)
            //     {
            //         GameManager.Instance.WhiteKing.IsInCheck = true;
            //         _whitePoints -= 50000;
            //         if (Rules.IsCheckMate(pieces, isWhite))
            //         {
            //             GameManager.Instance.WhiteKing.IsCheckMate = true;
            //             _whitePoints -= 100000;
            //         }
            //     }
            //     else
            //     {
            //         GameManager.Instance.BlackKing.IsInCheck = true;
            //         _blackPoints -= 50000;
            //         if (Rules.IsCheckMate(pieces, isWhite))
            //         {
            //             GameManager.Instance.BlackKing.IsCheckMate = true;
            //             _whitePoints -= 100000;
            //         }
            //     }
            // }
            // else
            // {
            //     if (isWhite == true)
            //     {
            //         GameManager.Instance.WhiteKing.IsInCheck = false;
            //         GameManager.Instance.WhiteKing.IsCheckMate = false;
            //     }
            //     else
            //     {
            //         GameManager.Instance.BlackKing.IsInCheck = false;
            //         GameManager.Instance.BlackKing.IsCheckMate = false;
            //     }
            // }

            if (isWhiteCheck)
            {
                _globalPoints = _whitePoints - _blackPoints + _positionBonusWhite - _positionBonusBlack;
            }
            else
            {
                _globalPoints = _blackPoints - _whitePoints + _positionBonusBlack - _positionBonusWhite;
            }
            
            return _globalPoints; 
        }
    }
}

