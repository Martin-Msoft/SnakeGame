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
            return GetNewDirection();
        }

        private (int x, int y) GetNewDirection()
        {
            (int x, int y) direction;
            switch (_direction)
            {
                case SnakeDirection.Left:
                    direction = (0, -1);
                    break;
                case SnakeDirection.Right:
                    direction = (0, 1);
                    break;
                case SnakeDirection.Up:
                    direction = (-1, 0);
                    break;
                case SnakeDirection.Down:
                    direction = (1, 0);
                    break;
                default:
                    direction = (0, 0);
                    break;
            }
            return direction;
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
