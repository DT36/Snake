using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Snake
    {
        private readonly List<Pixel> _body;
        private readonly ConsoleColor _color;
        private string _direction;

        public Snake(int startX, int startY, ConsoleColor color)
        {
            _body = new List<Pixel> { new Pixel(startX, startY, color) };
            this._color = color;
            _direction = "RIGHT";
        }

        public void Move()
        {
            int newX = _body[0].X;
            int newY = _body[0].Y;

            switch (_direction)
            {
                case "UP":
                    newY--;
                    break;
                case "DOWN":
                    newY++;
                    break;
                case "LEFT":
                    newX--;
                    break;
                case "RIGHT":
                    newX++;
                    break;
            }

            _body.Insert(0, new Pixel(newX, newY, _color));
            _body.RemoveAt(_body.Count - 1);
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (_direction != "DOWN") _direction = "UP";
                    break;
                case ConsoleKey.DownArrow:
                    if (_direction != "UP") _direction = "DOWN";
                    break;
                case ConsoleKey.LeftArrow:
                    if (_direction != "RIGHT") _direction = "LEFT";
                    break;
                case ConsoleKey.RightArrow:
                    if (_direction != "LEFT") _direction = "RIGHT";
                    break;
            }
        }

        public bool CheckCollision(int screenWidth, int screenHeight)
        {
            return _body[0].X <= 0 || _body[0].X >= screenWidth - 1 || _body[0].Y <= 0 || _body[0].Y >= screenHeight - 1;
        }

        public bool EatBerry(Berry berry)
        {
            if (_body[0].X == berry.X && _body[0].Y == berry.Y)
            {
                _body.Add(new Pixel(_body[_body.Count - 1].X, _body[_body.Count - 1].Y, _color));
                return true;
            }
            return false;
        }

        public bool CheckSelfCollision()
        {
            for (int i = 1; i < _body.Count; i++)
            {
                if (_body[0].X == _body[i].X && _body[0].Y == _body[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Pixel> GetBody()
        {
            return _body;
        }
    }
}
