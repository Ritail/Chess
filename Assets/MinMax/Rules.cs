using System.Collections.Generic;
using Chess;
using Unity.VisualScripting;
using UnityEngine;

namespace MinMax
{
    public static class Rules
    {
        private static Piece _king;
        private static Vector2Int _kingPosition;

        public static Vector2Int FindKing(Piece[,] pieces, bool isWhite)
        {
            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    Piece piece = pieces[i, j];
                    if (piece is King && piece.isWhite == isWhite)
                    {
                        return new Vector2Int(i, j);
                    }
                }
            }

            return new Vector2Int(-1, -1);
        }
        public static bool IsKingInCheck(Piece[,] pieces, bool isWhite)
        {
            Vector2Int kingPosition = FindKing(pieces, isWhite);
            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    Piece piece = pieces[i,j]; 
                        
                    if (piece != null && piece.isWhite != isWhite)
                    {
                        Vector2Int position = new Vector2Int(i, j);
                        List<Vector2Int> possibleMoves = piece.availableMovements(position, pieces);
                        if (possibleMoves.Contains(kingPosition))
                        { 
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }

        public static bool IsCheckMate(Piece[,] pieces, bool isWhite)
        {
            if (!IsKingInCheck(pieces, isWhite))
            {
                return false;
            }

            Vector2Int kingPosition = FindKing(pieces, isWhite);
            Piece king = pieces[kingPosition.x, kingPosition.y];
            
            List<Vector2Int> kingMoves = king.availableMovements(kingPosition, pieces);
            foreach (var move in kingMoves)
            {
                Piece temp = pieces[move.x, move.y];
                pieces[kingPosition.x, kingPosition.y] = null;
                pieces[move.x, move.y] = king;
                kingPosition = move;

                bool stillInCheck = IsKingInCheck(pieces, isWhite);
                
                pieces[move.x, move.y] = temp;
                pieces[kingPosition.x, kingPosition.y] = king;

                if (!stillInCheck)
                {
                    return false;
                }
                
            }
            for (int i = 0; i < pieces.GetLength(0); i++)
            {
                for (int j = 0; j < pieces.GetLength(1); j++)
                {
                    Piece piece = pieces[i, j];
                    if (piece != null && piece.isWhite == isWhite && !(piece is King))
                    {
                        List<Vector2Int> possibleMoves = piece.availableMovements(new Vector2Int(i, j), pieces);
                        foreach (var move in possibleMoves)
                        {
                            Piece temp = pieces[move.x, move.y];
                            
                            pieces[i, j] = null;
                            pieces[move.x, move.y] = piece;

                            bool stillInCheck = IsKingInCheck(pieces, isWhite);
                            
                            pieces[move.x, move.y] = temp;
                            pieces[i, j] = piece;

                            if (!stillInCheck)
                            {
                                return false; // Une pièce peut protéger le roi
                            }
                        }
                    }
                }
            }
            
            return true;
        }

        public static void PromotePawn(Piece[,] pieces, bool isWhite, Piece WhiteQueen, Piece BlackQueen)
        {
            int topRow = 0;
            int downRow = 7;
            if (isWhite)
            {
                for (int i = 0; i < pieces.GetLength(0); i++)
                {
                    Piece piece = pieces[topRow, i];
                    if (piece is Pawn && piece.isWhite == isWhite)
                    {
                        if (piece.isWhite)
                        {
                            pieces[topRow, i] = WhiteQueen;
                            pieces[topRow, i].isWhite = true;
                        }
                    }
                
                }
            }
            else
            {
                for (int i = 0; i < pieces.GetLength(0); i++)
                {
                    Piece piece = pieces[downRow, i];
                    if (piece is Pawn && piece.isWhite == isWhite)
                    {
                        if (!piece.isWhite)
                        {
                            pieces[downRow, i] = BlackQueen;
                            pieces[downRow, i].isWhite = false;
                        }
                    }
                
                }
            }
        }
    }
}
