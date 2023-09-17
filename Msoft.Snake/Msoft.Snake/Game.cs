using Msoft.Snake.Levels;

namespace Msoft.Snake
{
    public class Game
    {
        private Render _render;
        private GameState _state;

        private Movement _movement;


        public Game(int speed, ILevel level)
        {
            _state = new(speed, level);
            _render = new(_state);
            _movement = new();
        }

        public void Start() => GameLoop();

        private void GameLoop()
        {
            while (_state.IsAlive)
            {
                var newCoordinates = _movement.MoveSnake();
                _state.Update(newCoordinates);
                _render.RenderFrame();
                DelayFrame();
            }
        }

        private void DelayFrame()
        {
            Thread.Sleep(_state.GameSpeed);
        }
    }
}



//Make a cell map.
//When creating food, check a list or something of available spaces to put the food. (maybe dictionary [x, y]?)
//  Available spaces are all the map cells where IsWalkable - current snakebody coordinates.
//Put current x & y in gamestate, pass gamestate as a constructor parameter where needed so it is referenced.