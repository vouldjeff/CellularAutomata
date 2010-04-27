using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Provides the functionality of a neighbourhood
    /// </summary>
    public interface INeighbourhood
    {
        /// <summary>
        /// Retrieves the neighbours of a <see cref="Cell"/> using location and <see cref="environment"/>  
        /// </summary>
        /// <param name="location">The location of the <see cref="Cell"/>.</param>
        /// <param name="environment"><see cref="Environment"/> object used to get <see cref="Cell.State"/>.</param>
        /// <returns>A collection with the neighbours.</returns>
        CellCollection GetNeighbours(Point location, CAEnvironment environment);
    }
}