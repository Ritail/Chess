using System;
using Chess;
using UnityEngine;

namespace MinMax.Heuristic
{
    public class HeuristicHandler : MonoBehaviour
    {
        private GameManager _gameManager;

        private int _blackPoints;
        private int _whitePoints;
        private int _globalPoints;

        private void Awake()
        {
            _gameManager = GetComponent<GameManager>();
        }

        public int CalculateHeuristic()
        {
            _globalPoints = 0;
            _blackPoints = 0;
            _whitePoints = 0;
            foreach (Pièce piece in _gameManager.Pieces)
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

            if (_gameManager._isWhiteTurn)
            {
                _globalPoints = _whitePoints - _blackPoints;
            }
            else
            {
                _globalPoints = _blackPoints - _whitePoints;
            }
            
            return _globalPoints;
        }
    }
}
