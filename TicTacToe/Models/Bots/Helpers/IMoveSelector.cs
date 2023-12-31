namespace TicTacToe.Models.Bots.Helpers
{
    public interface IMoveSelector
    {
        int Minimax(Board board, int depth, bool isMaximizingPlayer, int maxDepth);
    }
}
