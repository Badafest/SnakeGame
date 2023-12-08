namespace SnakeGame
{
    public class Frame
    {
        public readonly int Height;
        public readonly int Width;
        public readonly int Left;
        public readonly int Right;
        public readonly int Top;
        public readonly int Bottom;

        public Frame(int Height = 100, int Width = 100)
        {
            this.Height = Height / 3;
            this.Width = Width;
            Left = 1;
            Top = 1;
            Right = this.Width - 2;
            Bottom = this.Height;
            Console.CursorVisible = false;
        }

        public void Draw()
        {
            Console.Clear();
            var head = "╔" + new string('═', Width - 2) + "╗";
            var body = '║' + new string(' ', Width - 2) + '║';
            var tail = "╚" + new string('═', Width - 2) + "╝";
            Console.WriteLine(head);
            for (int i = 0; i < Height; i++)
            {
                Console.WriteLine(body);
            }
            Console.WriteLine(tail);
        }

        public bool TouchedBorder(int x, int y)
        {
            var XTouched = x <= Left || x >= Right;
            var yTouched = y <= Top || y >= Bottom;
            return XTouched || yTouched;
        }

        public void CenteredText(string Text, int Line = 0)
        {
            Console.SetCursorPosition(Left + (Width - Text.Length) / 2, Top + (Height / 2) - 5 + Line);
            Console.Write(Text);
        }
    }
}