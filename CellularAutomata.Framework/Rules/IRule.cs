namespace CellularAutomata.Framework
{
    /// <summary>
    /// Provides the functionality of a rule.
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Says whether a particular <see cref="Cell"/> can be live.
        /// </summary>
        /// <param name="currentCell">The <see cref="Cell"/> to be checked.</param>
        /// <param name="neighbours">The neighbours of the <see cref="Cell"/>.</param>
        /// <returns>Whether the <see cref="Cell"/> can be live.</returns>
        bool CanBeActivated(Cell currentCell, CellCollection neighbours);
    }
}