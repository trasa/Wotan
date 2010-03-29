using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Wotan.Engine.Model;

namespace Wotan.Test.Engine.Motion
{
    [TestFixture]
    public class When_Applying_MovementList_To_Objects
    {
        [Test]
        public void Ships_Are_In_New_Position()
        {
            var shipA = new Ship {Position = new Vector(0, 0, 0), Velocity = new Vector(2, 0, 0)};
            var shipB = new Ship { Position = new Vector(10, 10, 10), Velocity = new Vector(2, 0, 0) };
            var list = new MovementList(new List<Ship> {shipA, shipB});

            list.ApplyMovement();

            Assert.That(shipA.Position, Is.EqualTo(new Vector(2, 0, 0)));
            Assert.That(shipB.Position, Is.EqualTo(new Vector(12, 10, 10)));
        }
    }
}
