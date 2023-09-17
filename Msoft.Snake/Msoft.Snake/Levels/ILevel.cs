using System.Drawing;

namespace Msoft.Snake.Levels
{
    public interface ILevel
    {
        public int Height { get; }
        public int Width { get; }
        public List<Point> SnakeStartingPoint { get; }
        public int InitialSnakeLength { get; }
        public string[,] GetMap();
    }
}
