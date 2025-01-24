using System.Collections;
using System.Collections.Generic;
using Chess;
using UnityEngine;

public class Node
{
    public Pièce[,] Pieces;
    public bool IsWhiteTurn;
    
    public Node() { }

    
    
    public Node(Pièce[,] pieces, bool isWhiteTurn)
    {
        Pieces = pieces;
        IsWhiteTurn = isWhiteTurn;
    }

    public bool IsTerminal()
    {
        return false;
    }

    public int HeursticValue()
    {
        int _globalPoints = 0;
        int _blackPoints = 0;
        int _whitePoints = 0;
        foreach (Pièce piece in Pieces)
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

        if (IsWhiteTurn)
        {
            _globalPoints = _whitePoints - _blackPoints;
        }
        else
        {
            _globalPoints = _blackPoints - _whitePoints;
        }
            
        return _globalPoints;
    }

    // public List<Node> Children()
    // {
    //     List<Node> children = new List<Node>();
    //     // Pour chaque movement possible
    //     Pièce[,] pieces = CreateCopy();
    //     Node node = new Node(pieces, false);
    //     MovePiece(node.Pieces);
    //     children.Add(node);
    // }

    public Pièce[,] MovePiece(Pièce[,] pieces, Pièce piece, Vector2Int from, Vector2Int to)
    {
        // Déplacement de la piece sur le pieces
        return pieces;
    }

    private Pièce[,] CreateCopy()
    {
        if (Pieces == null) return null;

        int rows = Pieces.GetLength(0);
        int cols = Pieces.GetLength(1);
        Pièce[,] newPieces = new Pièce[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (Pieces[row, col] != null)
                {
                    newPieces[row, col] = Pieces[row, col];
                }
            }
        }

        return newPieces;
    }
}
