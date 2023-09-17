using Msoft.Snake.Levels;
using System.Drawing;

namespace Msoft.Snake
{
    public class GameState
    {
        private Snake _snake;

        public int GameSpeed { get; set; }
        public bool IsAlive { get; set; }
        public int Score { get; set; }
        public readonly int MapHeight;
        public readonly int MapWidth;

        public CellType[,] Map { get; private set; }
        private Food _food;

        public GameState(int speed, ILevel level)
        {
            IsAlive = true;
            Score = 0;
            GameSpeed = speed;
            MapHeight = level.Height;
            MapWidth = level.Width;
            Map = level.GetMap();
            _snake = new(level.InitialSnakeLength, level.SnakeStartingPoint);
            _food = new();
        }

        public void Update((int x, int y) direction)
        {

            var newCoordinates = _snake.UpdateSnakePosition(direction);

            if (CheckCollision(newCoordinates))
            {
                IsAlive = false;

                Console.Beep(400, 200);
                Console.Beep(110, 800);

                return;
            }


            if (Map[newCoordinates.X, newCoordinates.Y] != CellType.Food)
            {
                var removeCoordinates = _snake.RemoveTail();
                Map[removeCoordinates.X, removeCoordinates.Y] = CellType.Empty;
            }
            else
            {
                _food.Exists = false;
                //only grow snake when tail is at food location
                //set counter that will not remove tail if SnakeLength is reached.
            }

            Map[newCoordinates.X, newCoordinates.Y] = CellType.Snake;
            if (!_food.Exists)
            {
                var newFood = _food.GetNewFoodCoordinates(GetEmptyCells());
                Map[newFood.X, newFood.Y] = CellType.Food;
            }
        }

        private List<Point> GetEmptyCells()
        {
            List<Point> emptyCells = new();
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (Map[y, x] == CellType.Empty)
                    {
                        emptyCells.Add(new Point(y, x));
                    }
                }
            }
            return emptyCells;
        }

        private bool CheckCollision(Point coordinates)
        {
            var cell = Map[coordinates.X, coordinates.Y];
            return cell == CellType.Snake || cell == CellType.Wall;
        }
    }
}
