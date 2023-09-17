namespace Msoft.Snake
{
    public class Render
    {
        private GameState _gameState;

        public Render(GameState gameState)
        {
            _gameState = gameState;
        }

        public void RenderFrame()
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < _gameState.MapHeight; y++)
            {
                for (int x = 0; x < _gameState.MapWidth; x++)
                {
                    var cell = _gameState.Map[y, x];
                    switch (cell)
                    {
                        case CellType.Wall:
                            Console.Write("█");//░ █ ■
                            break;
                        case CellType.Empty:
                            Console.Write(" ");
                            break;
                        case CellType.Snake:
                            Console.Write("O");
                            break;
                        case CellType.Food:
                            Console.Write("x");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
