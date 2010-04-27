using System;
using System.Collections.Generic;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents the basic 256 rules.
    /// </summary>
    [Serializable]
    public class CellularAutomationRule : IRule
    {
        private bool[] _rule;

        /// <summary>
        /// Initializes a new <see cref="CellularAutomationRule"/> using a rule number.
        /// </summary>
        /// <param name="ruleNumber">The number of the rule to be initialized.</param>
        public CellularAutomationRule(byte ruleNumber)
        {
            _rule = Utilities.GetBinaryFromByte(ruleNumber);
        }

        public bool CanBeActivated(Cell currentCell, CellCollection neighbours)
        {
            IEnumerator<Cell> enumerator = neighbours.GetEnumerator();

            byte currentCase = 0;
            int index = neighbours.Count - 1;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.State)
                {
                    currentCase += (byte) Math.Pow(2, index);
                }
                index--;
            }
            return _rule[currentCase];
        }
    }
}