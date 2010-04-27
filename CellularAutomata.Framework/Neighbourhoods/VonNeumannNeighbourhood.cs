using System;
using System.Drawing;

namespace CellularAutomata.Framework
{
    [Serializable]
    public class VonNeumannNeighbourhood : TrivialNeighbourhood
    {
        public VonNeumannNeighbourhood()
            : base(new short[4,2] {{0, -1}, {1, 0}, {0, 1}, {-1, 0}})
        {
        }
    }
}