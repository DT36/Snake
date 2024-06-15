using System;

namespace Snake
{
    internal class Berry
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Berry(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}