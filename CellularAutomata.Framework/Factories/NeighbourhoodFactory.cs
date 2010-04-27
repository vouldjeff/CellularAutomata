using System;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Static class, which creates <see cref="INeighbourhood"/> objects.
    /// </summary>
    public static class NeighbourhoodFactory
    {
        /// <summary>
        /// Creates a new <see cref="INeighbourhood"/> instance using the neighbourhood name.
        /// </summary>
        /// <param name="name">The name of the neighbourhood to be created.</param>
        /// <returns>The initialized <see cref="INeighbourhood"/> object.</returns>
        public static INeighbourhood Create(string name)
        {
            return Create(Utilities.GetNeighbourhoodType(name));
        }

        /// <summary>
        /// Creates a new <see cref="INeighbourhood"/> instance using the neighbourhood <see cref="Type"/>.
        /// </summary>
        /// <param name="neighbourhoodType">The <see cref="Type"/> of the neighbourhood to be created.</param>
        /// <returns>The initialized <see cref="INeighbourhood"/> object.</returns>
        public static INeighbourhood Create(Type neighbourhoodType)
        {
            return (INeighbourhood) Activator.CreateInstance(neighbourhoodType);
        }
    }
}