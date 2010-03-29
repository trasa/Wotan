

namespace Wotan.Engine.Model
{
    /// <summary>
    /// A celestial body of hot gases that radiates energy derived from thermonuclear reactions in the interior.
    /// </summary>
    public class Star
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Star"/> class.
        /// </summary>
        /// <param name="name">The name of the star.</param>
        public Star(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }
    }
}