using System;
using System.Drawing;

namespace Animation
{
    internal class Pixel
    {
        Color pixelColor { get; }
        ConsoleColor backColor { get; }

        public Pixel(Color pixelColor, ConsoleColor backColor)
        {
            this.pixelColor = pixelColor;
            this.backColor = backColor;
        }

        public Color PixelColor { get { return pixelColor; } }


        public ConsoleColor BackColor { get { return backColor; } }
    }
}
