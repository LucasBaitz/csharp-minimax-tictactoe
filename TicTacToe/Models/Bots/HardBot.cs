﻿using TicTacToe.Models.Bots.Helpers;
using TicTacToe.Models.Bots.Interfaces;

namespace TicTacToe.Models.Bots
{
    public class HardBot : IBot
    {
        public int MaxDepth => int.MaxValue;
        private IMoveSelector _moveSelector;

        public HardBot()
        {
            _moveSelector = new MoveSelector();
        }

        public int MakeMove(Board board)
        {
            int bestMove = -1;
            int bestScore = int.MinValue;

            for (int i = 1; i <= 9; i++)
            {
                if (board.IsCellEmpty(i))
                {
                    board.PlaceMove(i, 'O');

                    int score = _moveSelector.Minimax(board, 0, false, MaxDepth);

                    board.PlaceMove(i, (char)('0' + i));

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }
            }

            return bestMove;
        }
    }
}
