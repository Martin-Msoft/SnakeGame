namespace Msoft.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Start from here
            Console.CursorVisible = false;
            var game = new Game(100, new Level1());
            game.Start();
        }
    }
}