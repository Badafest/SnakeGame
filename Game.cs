namespace SnakeGame
{
    public class Game
    {
        private bool GameRunning = false;

        public Frame GameFrame { get; set; } = new(80, 100);
        public Snake GameSnake { get; set; } = new(5, 50, 50);

        public Fruit GameFruit { get; set; } = new();
        private int[]? SnakeResetState;
        private int Score = 0;

        private int Level = 1;

        private int HighScore = 0;
        private Task? KeyPressTask;
        public void Init()
        {
            if (SnakeResetState == null)
            {
                int[] SnakeInitialState = [GameSnake.Length, GameSnake.HeadX, GameSnake.HeadY];
                SnakeResetState = SnakeInitialState;
            }
            else
            {
                GameSnake.Length = SnakeResetState[0];
                GameSnake.HeadX = SnakeResetState[1];
                GameSnake.HeadY = SnakeResetState[2];
                GameSnake.Reset();
                Score = 0;
            }

            KeyPressTask = Task.Run(ListenKeyPress);

            while (GameRunning)
            {
                if (KeyPressTask.IsCompleted)
                {
                    KeyPressTask = Task.Run(ListenKeyPress);
                }
                GameFrame.Draw();
                bool ateOwnTail = GameSnake.Draw();
                if (GameFrame.TouchedBorder(GameSnake.HeadX, GameSnake.HeadY) || ateOwnTail)
                {
                    GameFrame.Draw();
                    GameRunning = false;
                    GameFrame.CenteredText([.. Message.GameOverTexts(Score, HighScore), .. Message.Instructions]);
                    break;
                }
                GameFruit.Draw(Level);
                if (GameFruit.Eaten(GameSnake.HeadX, GameSnake.HeadY))
                {
                    GameFruit.Spawn();
                    GameSnake.Grow();
                    Score += Level;
                }
                HighScore = Math.Max(Score, HighScore);
                Level = Math.Min(1 + ((GameSnake.Length - SnakeResetState[0]) / 10), 10);
                GameFrame.CenteredText($"LEVEL: {Level} | SCORE: {Score} | HIGH: {HighScore}".PadLeft(GameFrame.Width - 3), GameFrame.Height / 2 + 7);
                Thread.Sleep(220 - (Level * 20));
            }

            KeyPressTask?.Wait();
        }

        private void ListenKeyPress()
        {
            var KeyPressed = Console.ReadKey(true);
            if (KeyPressed.Key == ConsoleKey.Escape)
            {
                Frame.Clear();
                Environment.Exit(0);
                return;
            }
            if (!GameRunning && KeyPressed.Key == ConsoleKey.Enter)
            {
                GameRunning = true;
                Init();
                return;
            }
            if (!GameRunning)
            {
                return;
            }
            switch (KeyPressed.Key)
            {
                case ConsoleKey.UpArrow:
                    GameSnake.Bend(Direction.UP);
                    break;
                case ConsoleKey.DownArrow:
                    GameSnake.Bend(Direction.DOWN);
                    break;
                case ConsoleKey.LeftArrow:
                    GameSnake.Bend(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    GameSnake.Bend(Direction.RIGHT);
                    break;
            }
        }
    }
}