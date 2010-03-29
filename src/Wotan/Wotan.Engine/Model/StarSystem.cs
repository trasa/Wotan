using System;
using System.Collections.Generic;

namespace Wotan.Engine.Model
{
    /// <summary>
    /// A Star System contains a Star, and zero or many planets and other orbiting bodies.
    /// </summary>
    /// <remarks>
    /// TODO: A Star System may actually contain more than 1 star.  In fact that configuration
    /// is quite common.
    /// </remarks>
    public class StarSystem
    {
        private readonly Star star;
        private readonly List<Ship> ships = new List<Ship>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StarSystem"/> class.
        /// </summary>
        /// <param name="star">The star at the center.</param>
        public StarSystem(Star star)
        {
            if (star == null)
                throw new ArgumentNullException("star");
            this.star = star;
        }


        /// <summary>
        /// Gets the star at the center of this system
        /// </summary>
        /// <value>The star.</value>
        public Star Star
        {
            get { return star; }
        }

        public string Name
        {
            get { return star.Name; }
        }

        public void Add(Ship ship)
        {
            ships.Add(ship);
        }

        public void MoveAll()
        {
            new MovementList(ships).MoveAll();
        }

        public void Tick()
        {
            // what happens on each tick?
            // for now, everybody moves...
            MoveAll();
        }
    }
}