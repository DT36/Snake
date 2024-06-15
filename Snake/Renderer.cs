using System;

namespace Snake
{
    internal class Renderer
    {
        private readonly int _screenWidth;
        private readonly int _screenHeight;

        public Renderer(int screenWidth, int screenHeight)
        {
            this._screenWidth = screenWidth;
            this._screenHeight = screenHeight;
        }

        public void DrawWalls()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < _screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, _screenHeight - 1);
                Console.Write("■");
            }

            for (int i = 0; i < _screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(_screenWidth - 1, i);
                Console.Write("■");
            }
        }

        public void DrawSnake(Snake snake)
        {
            foreach (var pixel in snake.GetBody())
            {
                Console.SetCursorPosition(pixel.X, pixel.Y);
                Console.ForegroundColor = pixel.Color;
                Console.Write("■");
            }
        }

        public void DrawBerry(Berry berry)
        {
            Console.SetCursorPosition(berry.X, berry.Y);
            Console.ForegroundColor = berry.Color;
            Console.Write("■");
        }
    }
}