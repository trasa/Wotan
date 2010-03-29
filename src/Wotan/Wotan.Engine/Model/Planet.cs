using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wotan.Engine.Model
{
    /// <summary>
    /// Something that orbits a star.
    /// </summary>
    /// <remarks>
    /// This will get refactored into a more extensive base class involving things that orbit a Star.
    /// And perhaps refactored again into things that orbit other things (satellites vs planets for example)
    /// </remarks>
    public class Planet
    {
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Planet"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Planet(string name)
        {
            this.name = name;
        }

        public string Name { get { return name; } }
    }
}