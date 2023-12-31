namespace TicTacToe.Models.Bots.Helpers
{
    public class MoveSelector : IMoveSelector
    {
        public int Minimax(Board board, int depth, bool isMaximizingPlayer, int maxDepth)
        {
            if (board.IsGameWon('O'))
            {
                return 1;
            }
            else if (board.IsGameWon('X'))
            {
                return -1;
            }
            else if (board.IsBoardFull())
            {
                return 0;
            }

            if (depth >= maxDepth)
            {
                return 0;
            }

            if (isMaximizingPlayer)
            {
                int bestScore = int.MinValue;

                for (int i = 1; i <= 9; i++)
                {
                    if (board.IsCellEmpty(i))
                    {
                        board.PlaceMove(i, 'O');
                        int score = Minimax(board, depth + 1, false, maxDepth);

                        board.PlaceMove(i, (char)('0' + i));

                        bestScore = Math.Max(score, bestScore);
                    }
                }

                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 1; i <= 9; i++)
                {
                    if (board.IsCellEmpty(i))
                    {
                        board.PlaceMove(i, 'X');
                        int score = Minimax(board, depth + 1, true, maxDepth);

                        board.PlaceMove(i, (char)('0' + i));

                        bestScore = Math.Min(score, bestScore);
                    }
                }

                return bestScore;
            }
        }
    }
}
