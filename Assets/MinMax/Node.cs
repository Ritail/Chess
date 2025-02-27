using System.Collections.Generic;
using System.Data;
using Chess;
using MinMax;
using MinMax.Heuristic;
using Unity.VisualScripting;
using UnityEngine;

public class Node
{
    public Piece[,] Pieces;
    public bool IsWhiteTurn;
    public bool IsWhiteCheck;
    
    public Node(Piece[,] pieces, bool isWhiteTurn, bool isWhiteCheck)
    {
        Pieces = (Piece[,])pieces.Clone();
        IsWhiteTurn = isWhiteTurn;
        IsWhiteCheck = isWhiteCheck;
    }

    public bool IsTerminal()
    {
        if (Children().Count == 0)
        {
            return true;
        }
        
        return false;
    }

    public int HeursticValue()
    { 
        int value = 0;
        value = HeuristicHandler.Instance.CalculateHeuristic(Pieces, IsWhiteTurn, IsWhiteCheck);
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
                    List<Vector2Int> possibleMove = piece.availableMovements(position, Pieces);

                    foreach (var move in possibleMove)
                    {
                        Node node = new Node(Pieces, !IsWhiteTurn, IsWhiteCheck);
                        node.MovePiece(node.Pieces, piece, new Vector2Int(x, y), move);
                        Rules.PromotePawn(node.Pieces, IsWhiteTurn, GameManager.Instance.WhiteQueen, GameManager.Instance.BlackQueen);
                        children.Add(node);
                    }
                }
            }
        }
        return children;
    }

    public Piece[,] MovePiece(Piece[,] pieces, Piece piece, Vector2Int from, Vector2Int to)
    {
        pieces[to.x, to.y] = piece;
        pieces[from.x, from.y] = null;
        return pieces;
    }
}
