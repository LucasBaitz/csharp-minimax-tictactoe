using TicTacToe.Models;
using TicTacToe.Models.Bots;

namespace TicTacToe.Menu
{
    public class MainMenu
    {
        public Game Run()
        {
            Console.Clear();
            DrawTitle();

            DrawOptions();
            var option = UserInputOption();
            var settings = SelectOption(option);

            return new Game(settings);
        }
        private void DrawTitle()
        {
            Console.WriteLine(@"
             __  __  _____ _   _____       _____            ___  
             \ \/ / |_   _(_)_|_   _|_ _ _|_   _|__  ___   / _ \ 
              >  <    | | | / _|| |/ _` / _|| |/ _ \/ -_) | (_) |
             /_/\_\   |_| |_\__||_|\__,_\__||_|\___/\___|  \___/ 
                                                                 
             ");
        }

        private void DrawOptions()
        {
            Console.WriteLine("Type you desired mode and press ENTER");
            Console.WriteLine("1 - Multiplayer");
            Console.WriteLine("2 - Easy Bot");
            Console.WriteLine("3 - Medium Bot");
            Console.WriteLine("4 - Hard Bot");
        }

        private int UserInputOption()
        {
            int choiceInput;
            while (!int.TryParse(Console.ReadLine(), out choiceInput))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            return choiceInput;
        }

        private GameSettings SelectOption(int choice)
        {
            GameSettings settings = new();

            switch (choice)
            {
                case 1:
                    settings.SelectedBot = null;
                    break;

                case 2:
                    settings.SelectedBot = new EasyAI();
                    break;

                case 3:
                    settings.SelectedBot = new MediumBot();
                    break;

                case 4:
                    settings.SelectedBot = new HardBot();
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }

            return settings;
        }
    }
}
