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
