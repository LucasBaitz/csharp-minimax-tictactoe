namespace TicTacToe.Models.Bots.Interfaces
{
    public interface IBot
    {
        int MaxDepth { get; }
        int MakeMove(Board board);
    }
}
