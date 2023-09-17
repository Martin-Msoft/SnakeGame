using Msoft.Snake.Levels;

namespace Msoft.Snake
{
    public class Game
    {
        private Render _render;
        private State _state;
        private Snake _snakeClass;
        private Movement _movement;


        public Game(int speed, ILevel level)
        {
            _state = new(speed);
            _snakeClass = new(level.InitialSnakeLength, level.SnakeStartingPoint);
            _render = new(level);
            _movement = new();
        }

        public void Start() => GameLoop();

        private void GameLoop()
        {
            while (true)
            {
                var newCoordinates = _movement.MoveSnake();
                _render.RenderFrame(newCoordinates, _snakeClass.SnakeBody);
                DelayFrame();
            }
        }

        private void DelayFrame()
        {
            Thread.Sleep(_state.GameSpeed);
        }
    }
}
