namespace SnakeGame
{
    public class Fruit
    {
        private readonly static Random Random = new();

        private readonly static char FruitCharacter = '+';

        private readonly int[] Position = { 0, 0 };

        public Frame GameFrame { get; set; } = new();
        public void Spawn()
        {
            Position[0] = Random.Next(GameFrame.Left + 1, GameFrame.Right - 1);
            Position[1] = Random.Next(GameFrame.Top + 1, GameFrame.Bottom - 5);
        }

        public Fruit()
        {
            Spawn();
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position[0], Position[1]);
            Console.Write(FruitCharacter);
        }

        public bool Eaten(int x, int y)
        {
            Console.SetCursorPosition(12, 36);
            Console.Write($"{x},{y} : {Position[0]},{Position[1]}");
            return (y == Position[1]) && (Math.Abs(x - Position[0]) < 2);
        }
    }
}