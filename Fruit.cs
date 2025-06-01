namespace SnakeGame
{
    public class Fruit
    {
        private readonly static Random Random = new();

        private readonly static string[] FruitCharacter = ["🍎", "🍏", "🍊", "🦎", "🍖", "🥩", "🐀", "🐤", "🦆", "🐐"];

        private readonly int[] Position = [0, 0];

        public Frame GameFrame { get; set; } = new();
        public void Spawn()
        {
            Position[0] = Random.Next(GameFrame.Left + 1, GameFrame.Right - 1);
            Position[1] = Random.Next(GameFrame.Top + 1, GameFrame.Bottom - 1);
        }

        public Fruit()
        {
            Spawn();
        }

        public void Draw(int level)
        {
            Console.SetCursorPosition(Position[0], Position[1]);
            Console.Write(FruitCharacter[level - 1]);
        }

        public bool Eaten(int x, int y)
        {
            return (y == Position[1]) && (Math.Abs(x - Position[0]) < 2);
        }
    }
}