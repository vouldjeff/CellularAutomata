using System.Collections.Generic;
using System;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents Comway`s Game of Life rule.
    /// </summary>
    [Serializable]
    public class GameOfLifeRule : IRule
    {
        /// <summary>
        /// Initializes a new <see cref="GameOfLifeRule"/> object.
        /// </summary>
        public GameOfLifeRule()
        {
        }

        public bool CanBeActivated(Cell currentCell, CellCollection neighbours)
        {
            short count = 0;
            IEnumerator<Cell> enumerator = neighbours.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.State)
                {
                    count++;
                }
            }

            if (count == 3)
            {
                return true;
            }
            if (count == 2 && currentCell.State)
            {
                return true;
            }
            return false;
        }
    }
}