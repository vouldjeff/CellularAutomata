using System;
using System.Collections;
using System.Drawing;

namespace CellularAutomata.Framework
{
    /// <summary>
    /// Represents a Cellular Automata environment, with a rule, neighourhood etc.
    /// </summary>
    [Serializable]
    public class CAEnvironment
    {
        /// <summary>
        /// Fired when the count of live cells is changed.
        /// </summary>
        public event EventHandler<CellsCountUpdatedEventArgs> RaiseCellsCountUpdatedEvent;

        private IRule _rule;
        private INeighbourhood _neighbourhood;
        private int _liveCells = 0;

        /// <summary>
        /// Dictionary collection with the all live <see cref="Cell"/>.
        /// </summary>
        public CellState States { get; private set; }

        /// <summary>
        /// Dictionary collection with the all live <see cref="Cell"/>. (Only internal use)
        /// </summary>
        public CellState StatesNew { get; private set; }

        /// <summary>
        /// Is the grid endless or not.
        /// </summary>
        public bool Endless { get; set; }

        private Size _size;
        private Point _max;
        private Point _min = new Point(0, 0);
        /// <summary>
        /// Represents the dimentions of the grid.
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set { _size = value; _max = new Point(value.Width, value.Height); }
        }

        /// <summary>
        /// Initializes a new <see cref="CAEnvironment"/> object.
        /// </summary>
        /// <param name="size">The size of the grid.</param>
        /// <param name="endless">Is the grid endless.</param>
        /// <param name="ruleName">The name of the rule, which will operate.</param>
        /// <param name="neighbourhoodName">The name of the neighbourhood for all <see cref="Cell"/> objects.</param>
        /// <param name="ruleArgs">If needed - arguments for initializing a <see cref="IRule"/> object.</param>
        public CAEnvironment(Size size, bool endless, string ruleName, string neighbourhoodName, object[] ruleArgs)
        {
            Size = size;
            Endless = endless;

            _rule = RuleFactory.Create(ruleName, ruleArgs);
            _neighbourhood = NeighbourhoodFactory.Create(neighbourhoodName);
            States = new CellState();
            StatesNew = new CellState();
        }

        /// <summary>
        /// Makes all the cells dead.
        /// </summary>
        public void Clear()
        {
            States = new CellState();
            StatesNew = new CellState();
            _liveCells = 0;
        }

        /// <summary>
        /// Prapares the <see cref="CAEnvironment"/> for a new generation.
        /// </summary>
        public void Prepair()
        {
            States = new CellState(StatesNew);
        }

        /// <summary>
        /// Returns a new <see cref="Cell"/> object using cell location.
        /// </summary>
        /// <param name="location">The location of the <see cref="Cell"/> to be created.</param>
        /// <returns>Initialized <see cref="Cell"/> object.</returns>
        public Cell GetCell(Point location)
        {
            return CellFactory.Create(location, this);
        }

        /// <summary>
        /// Toggles the <see cref="Cell.State"/> of a particular <see cref="Cell"/>.
        /// </summary>
        /// <param name="location">The <see cref="Cell"/>, which <see cref="Cell.State"/> is toggled.</param>
        public void ToggleCellState(Point location)
        {
            CheckInnerGrid(location);

            long key = Utilities.GetKey(location);
            if (!StatesNew.Contains(key))
            {
                _liveCells++;
                StatesNew.Add(key);
            }
            else
            {
                _liveCells--;
                StatesNew.Remove(key);
            }
            OnRaiseCellsCountUpdatedEvent(new CellsCountUpdatedEventArgs(_liveCells));
        }

        public void DrawPattern(Pattern pattern, Point location)
        {
            long key;
            Point newPoint;
            foreach (Cell cell in pattern.Cells)
            {
                CheckInnerGrid(cell.Location);
                newPoint = location; 
                newPoint.Offset(cell.Location);
                key = Utilities.GetKey(newPoint);
                if (!StatesNew.Contains(key))
                {
                    _liveCells++;
                    StatesNew.Add(key);
                }
            }

            OnRaiseCellsCountUpdatedEvent(new CellsCountUpdatedEventArgs(_liveCells));
        }

        /// <summary>
        /// Gets and sets the new <see cref="Cell.State"/> of particular <see cref="Cell"/>.
        /// </summary>
        /// <param name="cell">The <see cref="Cell"/>, which <see cref="Cell.State"/> is pregenerated.</param>
        public bool SetCellState(Cell cell)
        {
            long key = cell.GetKey();
            if (_rule.CanBeActivated(cell, _neighbourhood.GetNeighbours(cell.Location, this)))
            {
                cell.State = true;
                if (!StatesNew.Contains(key))
                {
                    StatesNew.Add(key);
                }
            }
            else
            {
                cell.State = false;
                if (StatesNew.Contains(key))
                {
                    StatesNew.Remove(key);
                }
            }

            return cell.State;
        }

        /// <summary>
        /// Makes a new generation.
        /// </summary>
        public void Enumerate()
        {
            Prepair();
            Cell cell;

            Point newMin = new Point(Size.Width, Size.Height);
            Point newMax = new Point(0, 0);

            for (int i = _min.Y; i < _max.Y; i++)
            {
                if (!Endless && !IsInDisplay(new Point(0, i))) continue;
                for (int j = _min.X; j < _max.X; j++)
                {
                    if (!Endless && !IsInDisplay(new Point(j, i))) continue;
                    cell = CellFactory.Create(new Point(j, i), this);
                    if (SetCellState(cell))
                    {
                        if (cell.Location.X - 2 < newMin.X) newMin.X = cell.Location.X - 2;
                        if (cell.Location.Y - 2 < newMin.Y) newMin.Y = cell.Location.Y - 2;
                        if (cell.Location.X + 2 > newMax.X) newMax.X = cell.Location.X + 2;
                        if (cell.Location.Y + 2 > newMax.Y) newMax.Y = cell.Location.Y + 2;
                    }
                }
            }

            _min = newMin;
            _max = newMax;

            States = new CellState(StatesNew);
            _liveCells = States.Count;
            OnRaiseCellsCountUpdatedEvent(new CellsCountUpdatedEventArgs(_liveCells));
        }

        /// <summary>
        /// Returns an enumerator to walk through the live <see cref="Cell"/> objects.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return States.GetEnumerator();
        }

        /// <summary>
        /// Checks is a <see cref="Cell"/> is in the grid.
        /// </summary>
        /// <param name="location">The location of the <see cref="Cell"/> to be checked.</param>
        /// <returns>If a <see cref="Cell"/> is in the grid.</returns>
        public bool IsInDisplay(Point location)
        {
            if (location.Y < 0 || location.Y >= Size.Height
                || location.X < 0 || location.X >= Size.Width)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Fires an event, when the live <see cref="Cell"/> objects count is changed.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> of the event.</param>
        protected virtual void OnRaiseCellsCountUpdatedEvent(CellsCountUpdatedEventArgs e)
        {
            EventHandler<CellsCountUpdatedEventArgs> handler = RaiseCellsCountUpdatedEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void CheckInnerGrid(Point point)
        {
            if (point.X + 2 > _max.X || point.X - 2 < _min.X || point.Y + 2 > _max.Y || point.Y - 2 < _min.Y)
            {
                _min = new Point(0, 0);
                _max = new Point(Size.Width, Size.Height);
            }
        }
    }
}