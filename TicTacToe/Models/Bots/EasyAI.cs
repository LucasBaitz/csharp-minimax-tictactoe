using TicTacToe.Models.Bots.Interfaces;

namespace TicTacToe.Models.Bots
{
    public class EasyAI : IBot
    {
        private readonly Random _random;

        public EasyAI()
        {
            _random = new Random();
        }

        public int MaxDepth => 0;

        public int MakeMove(Board board)
        {
            int move;
            do
            {
                move = _random.Next(1, 10);
            } while (!board.IsCellEmpty(move));

            return move;
        }
    }
}
