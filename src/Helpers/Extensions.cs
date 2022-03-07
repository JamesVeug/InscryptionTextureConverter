using System.Drawing;

namespace InscryptionTextureConverter.Helpers
{
    public static class Extensions
    {
        public static Point Add(this Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        
        public static Point Scale(this Point a, int s)
        {
            return new Point(a.X * s, a.Y * s);
        }
    }
}