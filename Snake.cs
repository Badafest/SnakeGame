namespace SnakeGame
{
    public enum Direction { LEFT, UP, RIGHT, DOWN };
    public class Snake
    {
        private readonly string SnakeCharacter = "●";
        private readonly int[,] Offsets = { { 2, 0 }, { 0, -1 }, { -2, 0 }, { 0, 1 } };
        private List<int> State = [];
        private Direction CurrentDirection = Direction.RIGHT;
        public int HeadX = 0;
        public int HeadY = 0;

        public int TailX = 0;
        public int TailY = 0;
        public int Length = 5;
        public int[] Anchor = [0, 0];
        public Snake(int length, int headX, int headY)
        {
            Length = length;
            HeadX = headX;
            HeadY = headY;
            Reset();
        }

        public void Reset()
        {
            State = [];
            for (int i = 0; i < Length; i++)
            {
                State.Add(0);
            }
            ;
            Anchor[0] = HeadX;
            Anchor[1] = HeadY;
            TailX = HeadX - Length;
            TailY = HeadY;
            CurrentDirection = Direction.RIGHT;
        }

        private int[] StateOffset(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new Exception("Invalid Index Provided");
            }

            var thisState = State[index];
            int[] offset = [Offsets[thisState, 0], Offsets[thisState, 1]];

            return offset;
        }

        public void Bend(Direction direction)
        {
            Anchor[0] = HeadX;
            Anchor[1] = HeadY;
            if (direction == CurrentDirection)
            {
                return;
            }
            switch (direction)
            {
                case Direction.UP:
                    if (CurrentDirection == Direction.DOWN)
                    {
                        return;
                    }
                    State[0] = 1;
                    break;
                case Direction.DOWN:
                    if (CurrentDirection == Direction.UP)
                    {
                        return;
                    }
                    State[0] = 3;
                    break;
                case Direction.LEFT:
                    if (CurrentDirection == Direction.RIGHT)
                    {
                        return;
                    }
                    State[0] = 2;
                    break;
                case Direction.RIGHT:
                    if (CurrentDirection == Direction.LEFT)
                    {
                        return;
                    }
                    State[0] = 0;
                    break;
            }
            CurrentDirection = direction;
        }

        public void Grow(int size = 1)
        {
            var tailOffset = StateOffset(Length - 1);
            for (int i = 0; i < size; i++)
            {
                State.Add(State[Length - 1]);
                Length++;
                TailX -= tailOffset[0];
                TailY -= tailOffset[1];
            }
        }

        public bool Draw()
        {
            int x = TailX;
            int y = TailY;
            int[][] coords = new int[Length - 1][];

            for (int i = Length - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(Math.Max(0, x), Math.Max(0, y));
                Console.Write(SnakeCharacter);
                if (i > 0)
                {
                    State[i] = State[i - 1];
                    coords[Length - 1 - i] = [x, y];
                }
                else
                {
                    HeadX = x;
                    HeadY = y;
                }
                var offset = StateOffset(i);
                x += offset[0];
                y += offset[1];
            }

            for (int i = 0; i < coords.Length; i++)
            {
                if (coords[i][0] == HeadX && coords[i][1] == HeadY)
                {
                    return true;
                }
            }

            var tailOffset = StateOffset(Length - 1);

            TailX += tailOffset[0];
            TailY += tailOffset[1];

            return false;
        }
    }

}