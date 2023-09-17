using Msoft.Snake.Levels;
using System.Drawing;

namespace Msoft.Snake
{
    public class Render
    {
        private ILevel _level;
        private string[,] _map;

        private int _currentX = 12;
        private int _currentY = 10;

        public Render(ILevel level)
        {
            _level = level;
            _map = level.GetMap();
        }

        public void RenderFrame((int x, int y) newCoordinates, List<Point> snakeBody)
        {
            DrawSnake(newCoordinates, snakeBody);
            DrawMap();
        }

        private void DrawMap()
        {
            //Overwrite existing image instead of clearing it and rerendering reduces flicker.
            Console.SetCursorPosition(0, 0);

            for (int x = 0; x < _level.Height; x++)
            {
                for (int y = 0; y < _level.Width; y++)
                {
                    Console.Write(_map[x, y]);
                }
                Console.WriteLine();
            }
        }

        private void DrawFood()
        {

        }

        private void DrawSnake((int x, int y) newCoordinates, List<Point> snakeBody)
        {
            var newX = _currentX += newCoordinates.x;
            var newY = _currentY += newCoordinates.y;

            snakeBody.Add(new Point(newX, newY));
            _map[snakeBody[0].Y, snakeBody[0].X] = " ";
            snakeBody.Remove(snakeBody[0]);

            foreach (var point in snakeBody)
            {
                _map[point.Y, point.X] = "O";
            }
        }
    }
}
