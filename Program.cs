// See https://aka.ms/new-console-template for more information
using SnakeGame;

Frame GameFrame = new(80, 100);
GameFrame.Draw();
GameFrame.CenteredText(Message.Introduction.Concat(Message.Instructions).ToArray());

Snake GameSnake = new(5, GameFrame.Left + GameFrame.Width / 2 + 3, GameFrame.Top + GameFrame.Height / 2);
Fruit GameFruit = new() { GameFrame = GameFrame };

Game NewGame = new() { GameFrame = GameFrame, GameSnake = GameSnake, GameFruit = GameFruit };

NewGame.Init();