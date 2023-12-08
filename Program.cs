// See https://aka.ms/new-console-template for more information
using SnakeGame;

Frame GameFrame = new(80, 100);
GameFrame.Draw();
GameFrame.CenteredText("Welcome To Snake Game");
GameFrame.CenteredText(new string('─', 50), 1);
GameFrame.CenteredText("Github: https://github.com/badafest/SnakeGame", 2);
GameFrame.CenteredText(new string('─', 50), 3);
GameFrame.CenteredText("Instructions:".PadRight(48), 4);
GameFrame.CenteredText("1. Use arrow keys to conrol snake".PadRight(42), 5);
GameFrame.CenteredText("2. Press Enter Key to start game".PadRight(42), 6);
GameFrame.CenteredText("3. Press Escape to exit at any time".PadRight(42), 7);
GameFrame.CenteredText(new string('─', 50), 8);

while (true)
{
    var KeyPressed = Console.ReadKey(true);
    if (KeyPressed.Key == ConsoleKey.Enter)
    {
        GameFrame.Draw();
        continue;
    }

    if (KeyPressed.Key == ConsoleKey.Escape)
    {
        Console.Clear();
        Console.CursorVisible = true;
        break;
    }
}


