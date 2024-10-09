using System.Collections;
using System.Collections.Generic;
using Chess;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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


    
    private void Start()
     {
         Pièce[,] pièce =
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

         for (int i = 0; i < pièce.GetLength(0); i++)
         {
             for (int j = 0; j < pièce.GetLength(1); j++)
             {
                 if (pièce[i, j] != null)
                 {
                     GameObject newPièce = Instantiate(_piecePrefaf, _girdParent);
                     Image imgComponent = newPièce.GetComponent<Image>();
                     imgComponent.sprite = pièce[i, j].sprite;
                 }
                 else
                 {
                     GameObject newvoid = Instantiate(_piecePrefafTransparent, _girdParent);
                 }
             } 
         }
     }
}
