using System;
using System.Drawing;

namespace CellularAutomata.Framework
{
    [Serializable]
    public class MooreNeighbourhood : TrivialNeighbourhood
    {
        public MooreNeighbourhood()
            : base(new short[8,2] {{-1, -1}, {0, -1}, {1, -1}, {1, 0}, {1, 1}, {0, 1}, {-1, 1}, {-1, 0}})
        {
        }
    }
}