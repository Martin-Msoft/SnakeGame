namespace Msoft.Snake
{
    internal class State
    {
        public State(int speed, int snakeLength = 3)
        {
            IsAlive = true;
            Score = 0;
            GameSpeed = speed;
            SnakeLenght = snakeLength;
        }

        public int GameSpeed { get; set; }
        public int SnakeLenght { get; set; }
        public bool IsAlive { get; set; }
        public int Score { get; set; }
    }
}
