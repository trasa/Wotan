using System.Reflection;
using log4net;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Wotan.Engine.Model;

namespace Wotan.Test.Engine.Motion
{
    [TestFixture]
    public class When_Computing_Ship_Position_Over_Time 
    {
        #region Setup/Teardown

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Ship ship;
        
        [SetUp]
        public void SetUp()
        {
            ship = new Ship {Position = Vector.Origin};
        }

        #endregion

        



        [Test]
        public void Velocity_Is_Applied_To_Vector_Resulting_In_Movement_Off_Axis()
        {
            ship.Velocity = new Vector(1, 1, 1);
            ship.Position = ship.ComputePotentialMove(); // move 1 unit
            ship.Position = ship.ComputePotentialMove(); // move 1 unit
            Assert.That(ship.Position, Is.EqualTo(new Vector(2, 2, 2))); // ship is where we expect it.
            log.Debug(ship.Position.ToVerboseString());
        }

        [Test]
        public void Velocity_Is_Applied_To_Vector_Resulting_In_Movement_On_Axis()
        {
            ship.Velocity = Vector.XAxis; // moving on the x axis 1 unit at a time.
            ship.Position = ship.ComputePotentialMove(); // move 1 unit
            ship.Position = ship.ComputePotentialMove(); // move 1 unit
            Assert.That(ship.Position, Is.EqualTo(new Vector(2, 0, 0))); // ship is where we expect it.
            log.Debug(ship.Position.ToVerboseString());
        }
    }
}