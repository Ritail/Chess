using System.Collections.Generic;
using Chess;
using MinMax.Heuristic;
using UnityEngine;

public class Node
{
    public Piece[,] Pieces;
    public bool IsWhiteTurn;
    
    public Node(Piece[,] pieces, bool isWhiteTurn)
    {
        Pieces = (Piece[,])pieces.Clone();
        IsWhiteTurn = isWhiteTurn;
    }

    public bool IsTerminal()
    {
        
        return false;
    }

    public int HeursticValue()
    { 
        int value = 0;
        value = HeuristicHandler.Instance.CalculateHeuristic();
        return value;
    }

    public List<Node> Children()
    {
        List<Node> children = new List<Node>();
        for (int x = 0; x < Pieces.GetLength(0); x++)
        {
            for (int y = 0; y < Pieces.GetLength(1); y++)
            {
                Piece piece = Pieces[x, y];

                if (piece != null && piece.isWhite == IsWhiteTurn)
                {
                    Vector2Int position = new Vector2Int(x, y);
                    List<Vector2Int> possibleMove = piece.availableMouvments(position);

                    foreach (var move in possibleMove)
                    {
                        Node node = new Node(Pieces, false);
                        node.MovePiece(Pieces, piece, new Vector2Int(x, y), move);
                        children.Add(node);
                    }
                }
            }
        }
        return children;
    }

    public Piece[,] MovePiece(Piece[,] pieces, Piece piece, Vector2Int from, Vector2Int to)
    {
        Pieces[from.x, from.y] = null;
        Pieces[to.x, to.y] = piece;
        return pieces;
    }

    // private Piece[,] CreateCopy()
    // {
    //     if (Pieces == null) return null;
    //
    //     int rows = Pieces.GetLength(0);
    //     int cols = Pieces.GetLength(1);
    //     Piece[,] newPieces = new Piece[rows, cols];
    //
    //     for (int row = 0; row < rows; row++)
    //     {
    //         for (int col = 0; col < cols; col++)
    //         {
    //             if (Pieces[row, col] != null)
    //             {
    //                 newPieces[row, col] = Pieces[row, col];
    //             }
    //         }
    //     }
    //
    //     return newPieces;
    // }
}
