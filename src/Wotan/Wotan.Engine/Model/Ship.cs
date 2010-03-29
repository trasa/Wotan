

namespace Wotan.Engine.Model
{
    /// <summary>
    /// A Ship.  Travels through the galaxy.  Etc.
    /// </summary>
    /// <remarks>
    /// This will eventually get refactored into something more meaningful - example:
    /// code dealing with Newtonian physics moved out to something else.  That sort of thing.
    /// </remarks>
    public class Ship
    {

        public string Name { get; set; }
        public Vector Position { get; set; } // instantaneous current position
        public Vector Velocity { get; set; }

        /// <summary>
        /// Computes the potential move this object could make this tick, if everything goes well.
        /// Does not actually change the state of the ship's position.
        /// </summary>
        /// <returns>Vector3 of the position we'd be in if everything worked out ok.</returns>
        public Vector ComputePotentialMove()
        {
            return Position + Velocity;
        }
    }
}
