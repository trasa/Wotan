using System.Collections.Generic;

namespace Wotan.Engine.Model
{
    /// <summary>
    /// Holds details about a queue of object moves, and then determines
    /// if those moves are legal, don't result in collisions, etc.
    /// </summary>
    public class MovementList : List<PotentialMovement>
    {
        public MovementList(){}

        public MovementList(IEnumerable<Ship> ships)
        {
            foreach (var ship in ships)
            {
                Add(new PotentialMovement(ship, ship.ComputePotentialMove()));
            }
        }

        public bool HasCollisions
        {
            get
            {
                // so, this turns out ot be a LOT harder than I was thinking it'd be.
                // I have written a lot of notes about the issues, but I think I'm going
                // to have to return to this after I've gotten farther on creating the 
                // setting + being able to navigate in it.
                //http://en.wikipedia.org/wiki/Collision_detection
                //http://www.jtaylor1142001.net/calcjat/Solutions/VLines/VLIntersect.htm

                return false;
            }
        }

        public void MoveAll()
        {

            // some sort of notification happens here... not sure what objects need to know
            // to be able to handle this yet.
            CheckForCollisions();

            // move everybody and do the appropriate notifications
            ApplyMovement();
        }


        public void CheckForCollisions()
        {
            // Not Implemented -- Collisions in 3D is more difficult than I thought it'd be.
        }

        public void ApplyMovement()
        {
            // TODO: how to figure out what moves are valid, will we just be updating the PotentialMovement list?
            // this isn't taking collisions or anything like that into consideration.
            ForEach(potentialMovement => potentialMovement.Ship.Position = potentialMovement.EndPosition);
        }
    }
}
