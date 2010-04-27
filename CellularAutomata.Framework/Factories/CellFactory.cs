using System.Drawing;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Static class, which is used for creating <see cref="Cell"/> objects.
    /// </summary>
    public static class CellFactory
    {
        /// <summary>
        /// Creates a new <see cref="Cell"/> instance using its location and state from an environment.
        /// </summary>
        /// <param name="location">The location of the state to be created.</param>
        /// <param name="environment">It is used to get the <see cref="Cell"/>`s state.</param>
        /// <returns>The initialized <see cref="Cell"/> object.</returns>
        public static Cell Create(Point location, CAEnvironment environment)
        {
            var c = new Cell(location);
            var key = c.GetKey();

            if (environment.States.Contains(key))
            {
                c.State = true;
            }

            return c;
        }
    }
}