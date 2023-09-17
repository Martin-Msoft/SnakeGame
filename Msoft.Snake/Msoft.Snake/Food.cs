using System.Drawing;

namespace Msoft.Snake
{
    public class Food
    {
        public bool Exists;

        public Point GetNewFoodCoordinates(List<Point> validCells)
        {
            int maxInteger = validCells.Count;
            Random random = new();
            var index = random.Next(0, maxInteger);
            Exists = true;
            return validCells[index];
        }
    }
}
