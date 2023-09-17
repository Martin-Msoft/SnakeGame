namespace Msoft.Snake
{
    public class Movement
    {
        private SnakeDirection _direction;

        public Movement()
        {
            _direction = SnakeDirection.Right;
        }

        public (int x, int y) MoveSnake()
        {
            UpdateDirection();
            return GetNewCoordinates();
        }

        private (int x, int y) GetNewCoordinates()
        {
            (int x, int y) coordinates;
            switch (_direction)
            {
                case SnakeDirection.Left:
                    coordinates = (-1, 0);
                    break;
                case SnakeDirection.Right:
                    coordinates = (1, 0);
                    break;
                case SnakeDirection.Up:
                    coordinates = (0, -1);
                    break;
                case SnakeDirection.Down:
                    coordinates = (0, 1);
                    break;
                default:
                    coordinates = (0, 0);
                    break;
            }
            return coordinates;
        }

        private void UpdateDirection()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        _direction = _direction != SnakeDirection.Down ? SnakeDirection.Up : _direction;
                        break;
                    case ConsoleKey.DownArrow:
                        _direction = _direction != SnakeDirection.Up ? SnakeDirection.Down : _direction;
                        break;
                    case ConsoleKey.LeftArrow:
                        _direction = _direction != SnakeDirection.Right ? SnakeDirection.Left : _direction;
                        break;
                    case ConsoleKey.RightArrow:
                        _direction = _direction != SnakeDirection.Left ? SnakeDirection.Right : _direction;
                        break;
                    default:

                        break;
                }
            }
        }
    }
}
