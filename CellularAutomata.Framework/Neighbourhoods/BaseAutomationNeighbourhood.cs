using System;
using System.Drawing;

namespace CellularAutomata.Framework
{
    [Serializable]
    public class BaseAutomationNeighbourhood : TrivialNeighbourhood
    {
        public BaseAutomationNeighbourhood()
            : base(new short[3,2] {{-1, 0}, {0, 0}, {1, 0}})
        {
        }
    }
}