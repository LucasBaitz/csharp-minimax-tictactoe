namespace TicTacToe.Models
{
    public class Board
    {
        public char[,] board =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };
        public void DrawBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    char symbol = board[i, j];
                    ConsoleColor color = (symbol == 'X') ? ConsoleColor.Green : 
                                         (symbol == 'O') ? ConsoleColor.Red : ConsoleColor.Blue;

                    Console.ForegroundColor = color;
                    Console.Write($" {symbol} ");
                    Console.ResetColor();

                    if (j < 2)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (i < 2)
                {
                    Console.WriteLine("-----------");
                }
            }
        }

        public void PlaceMove(int move, char currentPlayer)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;
            this.board[row, col] = currentPlayer;
        }

        public bool IsCellEmpty(int move)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;
            return this.board[row, col] != 'X' && this.board[row, col] != 'O';
        }

        public bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != 'X' && board[i, j] != 'O')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsGameWon(char playerMarker)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == playerMarker && board[i, 1] == playerMarker && board[i, 2] == playerMarker ||
                    board[0, i] == playerMarker && board[1, i] == playerMarker && board[2, i] == playerMarker)
                {
                    return true;
                }
            }

            if (board[0, 0] == playerMarker && board[1, 1] == playerMarker && board[2, 2] == playerMarker ||
                board[0, 2] == playerMarker && board[1, 1] == playerMarker && board[2, 0] == playerMarker)
            {
                return true;
            }

            return false;
        }
    }
}
