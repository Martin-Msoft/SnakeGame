using Msoft.Snake.Levels;

namespace Msoft.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var game = new Game(200, new Level1());
            game.Start();
        }
    }
}