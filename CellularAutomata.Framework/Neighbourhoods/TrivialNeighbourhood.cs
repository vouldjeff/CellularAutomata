using System;
using System.Drawing;

namespace CellularAutomata.Framework
{
    [Serializable]
    public class TrivialNeighbourhood : INeighbourhood
    {
        protected short[,] _neighboursDelta;

        public TrivialNeighbourhood(short[,] neighbourPointsDelta)
        {
            if (neighbourPointsDelta.GetLength(1) != 2)
            {
                throw new ArgumentException("The size of the second dimention of the array is not 2.");
            }

            _neighboursDelta = neighbourPointsDelta;
        }

        public CellCollection GetNeighbours(Point location, CAEnvironment environment)
        {
            Cell c = environment.GetCell(location);
            CellCollection neighbours = new CellCollection();
            Point newPoint = location;

            for (int i = 0; i < _neighboursDelta.Length / 2; i++)
            {
                newPoint.Offset(_neighboursDelta[i, 0], _neighboursDelta[i, 1]);
                neighbours.Add(environment.GetCell(newPoint));
                newPoint = location;
            }

            return neighbours;
        }
    }
}