using System.Collections.Generic;
using Chess;
using Unity.VisualScripting;
using UnityEngine;

namespace MinMax
{
    public class Rules
    {
        public Piece[,] Pieces;
        private Piece _king;
        private Vector2Int _kingPosition;
        private bool _isWhite;
        private bool _isFindKing;

        public Rules(Piece[,] pieces, bool isWhite)
        {
            Pieces = pieces;
            _isWhite = isWhite;
        }

        public void FindKing()
        {
            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    Piece piece = Pieces[i, j];
                    if (piece is King && piece.isWhite == _isWhite)
                    {
                        _kingPosition = new Vector2Int(i, j);
                        _king = piece;
                        IsKingInCheck();
                        break;
                    }
                }
            }
        }
        public bool IsKingInCheck()
        {
            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    Piece piece = Pieces[i,j]; 
                        
                    if (piece != null && piece.isWhite != _isWhite)
                    {
                        Vector2Int position = new Vector2Int(i, j);
                        List<Vector2Int> possibleMoves = piece.availableMovements(position, Pieces);
                        if (possibleMoves.Contains(_kingPosition))
                        { 
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }
    }
}
