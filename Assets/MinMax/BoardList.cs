using System;
using Chess;

namespace MinMax
{
    [Serializable]
    public enum BoardType
    {
        BaseBoard,
        ThirdCheckBoard,
        StopPawnBoard,
        PawnBoard,
        BugBoard,
    }
    
    public static class BoardList
    {
        public static Piece[,] BoardSelector(BoardType boardType)
        {
            switch (boardType)
            {
                case BoardType.ThirdCheckBoard:
                    return new Piece[,]
                    {
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, GameManager.Instance.WhiteBishop, null, null, null, null, null, null },
                        { GameManager.Instance.WhiteKnight, GameManager.Instance.WhiteKnight, null, null, null, null, null, null },
                        { GameManager.Instance.BlackPawn, GameManager.Instance.BlackKing, null, GameManager.Instance.WhiteKing, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                    };
                
                case BoardType.StopPawnBoard:
                    return new Piece[,]
                    {
                        { null, null, null, null, null, null, null, null },
                        { GameManager.Instance.WhiteRook, null, GameManager.Instance.WhitePawn, null, null, null, null, null },
                        { null, null, null, null, null, GameManager.Instance.WhiteKing, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, GameManager.Instance.WhitePawn },
                        { GameManager.Instance.BlackPawn, null, null, null, null, null, null, null },
                        { null, GameManager.Instance.BlackKing, null, null, null, GameManager.Instance.BlackPawn, null, null },
                        { null, null, null, null, GameManager.Instance.WhiteRook, null, null, null },
                    };
                    
                case BoardType.BaseBoard:
                    return new Piece[,]
                    {
                        { GameManager.Instance.BlackRook, GameManager.Instance.BlackKnight, GameManager.Instance.BlackBishop,GameManager.Instance.BlackKing, GameManager.Instance.BlackQueen, GameManager.Instance.BlackBishop, GameManager.Instance.BlackKnight, GameManager.Instance.BlackRook },
                        { GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn,GameManager.Instance.BlackPawn },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn },
                        { GameManager.Instance.WhiteRook, GameManager.Instance.WhiteKnight, GameManager.Instance.WhiteBishop,GameManager.Instance.WhiteKing ,GameManager.Instance.WhiteQueen, GameManager.Instance.WhiteBishop, GameManager.Instance.WhiteKnight, GameManager.Instance.WhiteRook },
                    };
                case BoardType.PawnBoard:
                    return new Piece[,]
                    {
                        { null, null, null,null ,null, null, null, null },
                        { GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn,GameManager.Instance.BlackPawn },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn },
                        { null, null, null,null ,null, null, null, null },
                    };
                case BoardType.BugBoard:
                    return new Piece[,]
                    {
                        { GameManager.Instance.BlackRook, null, GameManager.Instance.BlackBishop,GameManager.Instance.BlackKing, GameManager.Instance.BlackQueen, null, null, GameManager.Instance.BlackRook },
                        { GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, GameManager.Instance.BlackPawn, null, GameManager.Instance.BlackKnight, null, null,GameManager.Instance.BlackPawn },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, GameManager.Instance.BlackPawn, GameManager.Instance.WhiteBishop, null },
                        { null, null, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn, null, null, null },
                        { null, GameManager.Instance.WhitePawn, null, null, null, GameManager.Instance.WhitePawn, null, null },
                        { GameManager.Instance.WhitePawn, null, null, null, null, GameManager.Instance.WhiteQueen, GameManager.Instance.WhitePawn, GameManager.Instance.WhitePawn },
                        { GameManager.Instance.WhiteRook, null, null,GameManager.Instance.WhiteKing ,null, GameManager.Instance.WhiteBishop, null, GameManager.Instance.WhiteRook },
                    };
            
                default:
                    return new Piece[,]
                    {
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                        { null, null, null, null, null, null, null, null },
                    };
            }
        }
    }
}
