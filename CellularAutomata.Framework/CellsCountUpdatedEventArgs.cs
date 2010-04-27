using System;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents <see cref="EventArgs"/> returned, when the count of live cells is updated.
    /// </summary>
    public class CellsCountUpdatedEventArgs : EventArgs
    {
        private int _count;

        /// <summary>
        /// Initializes a new <see cref="CellsCountUpdatedEventArgs"/> object using the new live cells count.
        /// </summary>
        /// <param name="count">The count of live cells.</param>
        public CellsCountUpdatedEventArgs(int count)
        {
            _count = count;
        }

        /// <summary>
        /// The count of live cells.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }
    }
}