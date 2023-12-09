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
        public void Init()
        {
            if (SnakeResetState == null)
            {
                int[] SnakeInitialState = { GameSnake.Length, GameSnake.HeadX, GameSnake.HeadY };
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

            while (GameRunning)
            {
                Task.Run(ListenKeyPress);
                GameFrame.Draw();
                GameSnake.Draw();
                GameFruit.Draw();
                if (GameFruit.Eaten(GameSnake.HeadX, GameSnake.HeadY))
                {
                    GameFruit.Spawn();
                    GameSnake.Grow();
                }
                int Score = GameSnake.Length - SnakeResetState[0];
                Level = Math.Min(1 + (Score / 10), 10);
                GameFrame.CenteredText($"SCORE: {Score} | LEVEL: {Level}".PadLeft(GameFrame.Width - 3), GameFrame.Height / 2 + 6);
                if (GameFrame.TouchedBorder(GameSnake.HeadX, GameSnake.HeadY))
                {
                    GameRunning = false;
                    GameFrame.CenteredText(Message.GameOverTexts(Score).Concat(Message.Instructions).ToArray());
                }

                Thread.Sleep(550 - (Level * 50));
            }

            ListenKeyPress();
            Init();
        }

        private void ListenKeyPress()
        {
            var KeyPressed = Console.ReadKey();
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