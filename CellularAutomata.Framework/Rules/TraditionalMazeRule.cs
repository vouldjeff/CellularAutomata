using System;
using System.Collections.Generic;

namespace CellularAutomata.Framework
{
    [Serializable]
    class TraditionalMazeRule : IRule
    {
        /// <summary>
        /// Initializes a new <see cref="TraditionalMazeRule"/> object.
        /// </summary>
        public TraditionalMazeRule()
        {
        }

        #region IRule Members

        public bool CanBeActivated(Cell currentCell, CellCollection neighbours)
        {
            if (currentCell.State) return true;

            short count = 0;
            IEnumerator<Cell> enumerator = neighbours.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Current.State)
                {
                    count++;
                }
            }

            if (count > 2) return true; 
            return false;
        }

        #endregion
    }
}
