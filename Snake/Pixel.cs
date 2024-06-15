using System;

namespace Snake
{
    internal class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }

        public Pixel(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}