using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Wotan.Engine.Model;

namespace Wotan.Test.Engine.Galaxies
{
    [TestFixture]
    public class When_Creating_Galaxy
    {
        [Test]
        public void StarSystems_Are_Contained_In_Galaxies()
        {
            var g = new Galaxy();
            g.Add(new StarSystem(new Star("bob")));
            Assert.That(g.SystemCount, Is.EqualTo(1));
        }
    }
}
