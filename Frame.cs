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

        public Frame(int height = 100, int width = 100)
        {
            Height = 3 * height / 7;
            Width = width;
            Left = 1;
            Top = 1;
            Right = Width - 2;
            Bottom = Height;
            Console.CursorVisible = false;
        }

        public static void Clear()
        {
            Console.Clear();
            Console.CursorVisible = true;
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
            var XTouched = x < Left || x > Right;
            var yTouched = y < Top || y > Bottom;
            return XTouched || yTouched;
        }

        public void CenteredText(string text, int line = 0)
        {
            Console.SetCursorPosition(Left + (Width - text.Length) / 2, Top + (Height / 2) - 5 + line);
            Console.Write(text);
        }

        public void CenteredText(string[] texts)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                CenteredText(texts[i], i);
            }
        }
    }
}