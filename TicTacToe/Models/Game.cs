using TicTacToe.Helpers;
using TicTacToe.Models.Bots.Interfaces;

namespace TicTacToe.Models
{
    public class Game
    {
        private const char playerOne = 'X';
        private const char playerTwo = 'O';
        private char currentPlayer;
        private bool gameOver = false;
        
        private readonly IBot? _bot;
        private readonly Board _board;

        public Game(GameSettings settings)
        {
            _bot = settings.SelectedBot;
            _board = new Board();
        }

        public void StartGame()
        {
            currentPlayer = playerOne;

            do
            {
                _board.DrawBoard();
                var currentPlayerMove = GetCurrentPlayerMove();
                _board.PlaceMove(currentPlayerMove, currentPlayer);

                if (_board.IsGameWon(currentPlayer))
                {
                    _board.DrawBoard();
                    ConsoleExtended.WriteGreenLine($"Player {currentPlayer} wins!");
                    gameOver = true; 
                    break;
                }

                if (_board.IsBoardFull())
                {
                    ConsoleExtended.WriteYellowLine("The game is a draw!");
                    gameOver = true;
                    break;
                }

                ChangePlayer();

            } while (!gameOver);
        }

        private int GetCurrentPlayerMove()
        {
            return currentPlayer == playerOne ? GetUserMove() : (_bot == null ? GetUserMove() : AIMove());
        }


        private int AIMove()
        {
            return _bot!.MakeMove(_board);
        }
        
        private int GetUserMove()
        {
            int move;
            bool isValidMove;

            do
            {
                Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
                isValidMove = int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9 && _board.IsCellEmpty(move);
                if (!isValidMove)
                {
                    ConsoleExtended.WriteRedLine("Invalid move. Please try again.");
                }
            } while (!isValidMove);

            return move;
        }

        private void ChangePlayer()
        {
            currentPlayer = (currentPlayer == playerOne) ? playerTwo : playerOne;
        }

    }
}
