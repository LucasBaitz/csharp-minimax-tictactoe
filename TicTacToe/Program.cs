using TicTacToe.Menu;
using TicTacToe.Models;

var menu = new MainMenu();

while (true)
{
    Game newGame = menu.Run();
    newGame.StartGame();

    Console.WriteLine("Returning to the menu in 3 seconds...");
    Thread.Sleep(3000);
}