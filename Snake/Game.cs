using System;

namespace Snake
{
    internal class Game
    {
        private const int ScreenWidth = 32;
        private const int ScreenHeight = 16;
        private readonly Snake _snake;
        private Berry _berry;
        private readonly Renderer _renderer;
        private readonly Random _random;
        private int _score;
        private bool _isGameOver;

        public Game()
        {
            Console.WindowHeight = ScreenHeight;
            Console.WindowWidth = ScreenWidth;
            _random = new Random();
            _snake = new Snake(ScreenWidth / 2, ScreenHeight / 2, ConsoleColor.Red);
            _berry = new Berry(_random.Next(1, ScreenWidth - 2), _random.Next(1, ScreenHeight - 2), ConsoleColor.Cyan);
            _renderer = new Renderer(ScreenWidth, ScreenHeight);
            _score = 5;
            _isGameOver = false;
        }

        public void Start()
        {
            while (!_isGameOver)
            {
                Console.Clear();
                _renderer.DrawWalls();
                _renderer.DrawBerry(_berry);
                _renderer.DrawSnake(_snake);
                
                if (_snake.CheckCollision(ScreenWidth, ScreenHeight))
                {
                    _isGameOver = true;
                    break;
                }

                if (_snake.EatBerry(_berry))
                {
                    _score++;
                    _berry = new Berry(_random.Next(1, ScreenWidth - 2), _random.Next(1, ScreenHeight - 2), ConsoleColor.Cyan);
                }

                if (_snake.CheckSelfCollision())
                {
                    _isGameOver = true;
                    break;
                }

                _snake.Move();

                System.Threading.Thread.Sleep(200);
            }

            GameOver();
        }

        private void GameOver()
        {
            Console.SetCursorPosition(ScreenWidth / 5, ScreenHeight / 2);
            Console.WriteLine($"Game over, Score: {_score}");
            Console.SetCursorPosition(ScreenWidth / 5, ScreenHeight / 2 + 1);
        }
    }
}
