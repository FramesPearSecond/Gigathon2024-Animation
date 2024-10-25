using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Media;


namespace Animation
{
    internal class Projector
    {
        string[] frames;

        Pixel[] pixelReferences = new Pixel[]
        {
            //skin
            new Pixel(Color.FromArgb(255, 221, 189), ConsoleColor.Yellow),
            new Pixel(Color.FromArgb(228, 197, 168), ConsoleColor.DarkYellow),
            //jacket
            new Pixel(Color.FromArgb(75, 91, 171), ConsoleColor.Blue),
            new Pixel(Color.FromArgb(67, 80, 149), ConsoleColor.DarkBlue),
            //pants
            new Pixel(Color.FromArgb(52, 52, 54), ConsoleColor.Green),
            new Pixel(Color.FromArgb(43, 43, 44), ConsoleColor.DarkGreen),
            //boots
            new Pixel(Color.FromArgb(0, 0, 0), ConsoleColor.DarkGray),
            //hat
            new Pixel(Color.FromArgb(208, 212, 213), ConsoleColor.Gray),
            new Pixel(Color.FromArgb(201, 205, 206), ConsoleColor.Gray),
            new Pixel(Color.FromArgb(193, 196, 197), ConsoleColor.DarkGray),
            //hair
            new Pixel(Color.FromArgb(165, 123, 83), ConsoleColor.Red),
            new Pixel(Color.FromArgb(152, 113, 76), ConsoleColor.DarkRed),
            //shirt
            new Pixel(Color.FromArgb(255, 255, 235), ConsoleColor.White)
        };

        public Projector(string path)
        {
            frames = Directory.GetFiles(path, "*.png");


            while (true)
            {
                foreach (string imgPath in frames)
                {
                    using (Bitmap frame = new Bitmap(imgPath))
                    {
                        displayChar(frame);
                    }
                    Thread.Sleep(100);
                    Console.Clear();
                }
                SystemSounds.Asterisk.Play();
            }
        }

        void displayChar(Bitmap frame)
        {
            for (int y = 0; y < frame.Height; y++)
            {
                Console.Write("\n");

                for (int x = 0; x < frame.Width; x++)
                {
                    Color pixel = frame.GetPixel(x, y);

                    Pixel unit = colorComparation(pixel);

                    if(unit != null)
                    {
                        Console.BackgroundColor = unit.BackColor;
                    }
                    
                    Console.Write(" ");
                    Console.ResetColor();

                }
            }
        }

        Pixel colorComparation(Color p)
        {
            foreach (Pixel u in pixelReferences)
            {
                if(u.PixelColor == p)
                {
                    return u;
                }
            }
            return null;

        }
    }
}
