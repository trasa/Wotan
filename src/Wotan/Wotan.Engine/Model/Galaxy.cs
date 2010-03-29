using System.Collections.Generic;

namespace Wotan.Engine.Model
{
    /// <summary>
    /// A Galaxy is an object found in the Universe that contains StarSystems.
    /// </summary>
    public class Galaxy 
    {
        private readonly List<StarSystem> systems = new List<StarSystem>();

        public void Add(StarSystem system)
        {
            systems.Add(system);
        }

        public int SystemCount
        {
            get { return systems.Count; }
        }

        public void Tick()
        {
            systems.ForEach(system => system.Tick());
        }
    }
}