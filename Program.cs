using SnakeGame;

int height = Console.WindowHeight;
int width = Console.WindowWidth;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int dim = Math.Min(height, width);
Frame GameFrame = new(dim - 5, 2 * (dim - 2));
GameFrame.Draw();
GameFrame.CenteredText(Message.Introduction.Concat(Message.Instructions).ToArray());

Snake GameSnake = new(5, GameFrame.Left + GameFrame.Width / 2 + 3, GameFrame.Top + GameFrame.Height / 2);
Fruit GameFruit = new() { GameFrame = GameFrame };

Game NewGame = new() { GameFrame = GameFrame, GameSnake = GameSnake, GameFruit = GameFruit };

NewGame.Init();