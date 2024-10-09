using System;
using System.Collections;
using System.Collections.Generic;
using Chess;
using Script;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Chess
{
    public class GameManager : MonoBehaviourSingleton<PieceHandler>
{
    [SerializeField] private Pièce BlackPawn;
    [SerializeField] private Pièce WhitePawn;
    [SerializeField] private Pièce WhiteRook;
    [SerializeField] private Pièce BlackRook;
    [SerializeField] private Pièce WhiteKnight;
    [SerializeField] private Pièce BlackKnight;
    [SerializeField] private Pièce WhiteBishop;
    [SerializeField] private Pièce BlackBishop;
    [SerializeField] private Pièce WhiteKing;
    [SerializeField] private Pièce BlackKing;
    [SerializeField] private Pièce WhiteQueen;
    [SerializeField] private Pièce BlackQueen;

    [SerializeField] private GameObject _piecePrefaf;
    [SerializeField] private GameObject _piecePrefafTransparent;
    [SerializeField] private Transform _girdParent;

    public Pièce[,] Pieces;

    
    public void Start()
     {
         Pieces = new Pièce[,]
        {
             { BlackRook, BlackKnight, BlackBishop, BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackRook},
             { BlackPawn,  BlackPawn, BlackPawn, BlackPawn,BlackPawn, BlackPawn,BlackPawn, BlackPawn},
             {null, null, null, null,null, null,null, null,},
             {null, null, null, null,null, null,null, null,},
             {null, null, null, null,null, null,null, null,},
             {null, null, null, null,null, null,null, null,},
             { WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn},
             { WhiteRook, WhiteKnight, WhiteBishop, WhiteKing, WhiteQueen, WhiteBishop, WhiteKnight, WhiteRook}
             
         };
         MatrixDes();
         
     }

    public void Matix()
    {
        for (int i = 0; i < Pieces.GetLength(0); i++)
        {
        for (int j = 0; j < Pieces.GetLength(1); j++)
        { 
            if (Pieces[i, j] != null) 
            {
                 GameObject newPièce = Instantiate(_piecePrefaf, _girdParent);
                 newPièce.GetComponent<PieceHandler>().Body(Pieces[i, j], new Vector2Int(i, j));
            }
            else
            {
                GameObject newvoid = Instantiate(_piecePrefafTransparent, _girdParent);
            }
        } 
        }
    }

    public void MatrixDes()
    {
        foreach (Transform child in _girdParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
}
}


