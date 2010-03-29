
namespace Wotan.Engine.Model
{
    public class PotentialMovement
    {
        public PotentialMovement(Ship ship, Vector endPosition)
        {
            Ship = ship;
            EndPosition = endPosition;
        }

        public Ship Ship { get; private set; }
        public Vector StartPosition { get { return Ship.Position; } }
        public Vector EndPosition { get; private set; }
    }
}
