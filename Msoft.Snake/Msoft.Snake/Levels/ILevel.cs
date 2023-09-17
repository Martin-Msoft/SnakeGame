using System.Drawing;

namespace Msoft.Snake.Levels
{
    public interface ILevel
    {
        int Height { get; }
        int Width { get; }
        List<Point> SnakeStartingPoint { get; }
        int InitialSnakeLength { get; }
        CellType[,] GetMap();
    }
}
