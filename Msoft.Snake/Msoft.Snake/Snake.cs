using System.Drawing;

namespace Msoft.Snake
{
    public class Snake
    {
        public int SnakeLength { get; private set; }
        public List<Point> SnakeBody { get; private set; }

        public Snake(int snakeLength, List<Point> snakeStartingPoint)
        {
            SnakeLength = snakeLength;
            SnakeBody = snakeStartingPoint;
        }
    }
}
