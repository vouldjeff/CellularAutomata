using System.Collections.Generic;
using System;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents a <see cref="Dictionary{TKey,TValue}"/> holding the <see cref="Cell.State"/>.
    /// The key is a <see cref="long"/>, which combines the cordinates of a <see cref="Cell"/>.
    /// </summary>
    [Serializable]
    public class CellState : List<long>
    {
        /// <summary>
        /// Initializes a new <see cref="CellState"/> collection.
        /// </summary>
        public CellState() : base()
        {
        }

        /// <summary>
        /// Initializes a copy of old <see cref="CellState"/> collection.
        /// </summary>
        /// <param name="old">The old <see cref="CellState"/> collection.</param>
        public CellState(CellState old) : base(old)
        {
        }
    }
}