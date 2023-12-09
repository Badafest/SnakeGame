namespace SnakeGame
{
    public class Message
    {
        public static readonly string Separator = new('─', 50);

        public static readonly string[] Instructions = {
            "Instructions:".PadRight(48),
            "1. Use arrow keys to conrol snake".PadRight(42),
            "2. Press Enter to start new game".PadRight(42),
            "3. Press Escape to exit".PadRight(42),
            Separator
        };

        public static readonly string[] Introduction = {
            "Welcome To Snake Game",
            Separator,
            "Github: https://github.com/badafest/SnakeGame",
            Separator
        };

        public static string[] GameOverTexts(int score, int highScore)
        {
            string[] gameOverTexts = {
                "GAME OVER",
                Separator,
                $"SCORE: {score} | HIGH: {highScore}",
                Separator
            };
            return gameOverTexts;
        }
    }

}