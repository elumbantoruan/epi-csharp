using System;
using System.Diagnostics;

namespace _05._11_RectangleIntersection
{
    class Program
    {
        /*
                                _
                               | |               |-----| R3
                ---------------|-|---------------|-----|
                |              | |               |_____|
                |              | |                     |
             R1  --------------|-|----------------------
                            R2 |_|
         */
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(x:20, y:10, width:50, height:30);
            Rectangle r2 = new Rectangle(  40,    5,       10,         45/*45*/);
            Rectangle intersection = IntersectRectangle(r1, r2);
            Console.WriteLine(intersection);
        }

        static Rectangle IntersectRectangle(Rectangle r1, Rectangle r2) {
            bool isIntersect = IsIntersect(r1, r2);
            if (!IsIntersect(r1, r2)) {
                return null;
            }
            return new Rectangle (
                x: Math.Max(r1.X, r2.X),
                y: Math.Max(r1.Y, r2.Y),
                width:Math.Min(r1.X + r1.Width, r2.X + r2.Width) - Math.Max(r1.X, r2.X),
                height:Math.Min(r1.Y + r1.Height, r2.Y + r2.Height) - Math.Max(r1.Y, r2.Y)
            );
            
        }

        static bool IsIntersect(Rectangle r1, Rectangle r2) {
            return (r1.X <= r2.X + r2.Width && r1.X + r1.Width >= r2.X &&
                    r1.Y <= r2.Y + r2.Height && r1.Y + r1.Height >= r2.Y );
        }
    }

    public class Rectangle {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override string ToString() {
            return $"X:{X} Y:{Y} Width:{Width} Height:{Height}";
        }

    }
}
