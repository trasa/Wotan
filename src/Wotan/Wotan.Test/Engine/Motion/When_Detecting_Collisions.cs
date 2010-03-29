using System.Collections.Generic;
using NUnit.Framework;
using Wotan.Engine.Model;

namespace Wotan.Test.Engine.Motion
{
    [TestFixture]
    public class When_Detecting_Collisions
    {

        [Test, Ignore("Collision detection is not implemented yet.")]
        public void Determine_Collision_Exists()
        {
            var shipA = new Ship { Position = new Vector(0, 0, 0), Velocity = new Vector(10, 0, 0) };
            var shipB = new Ship { Position = new Vector(10, 10, 0), Velocity = new Vector(0, 20, 0) };
            var list = new MovementList(new List<Ship> { shipA, shipB });
            Assert.IsTrue(list.HasCollisions);
        }
    }
}
