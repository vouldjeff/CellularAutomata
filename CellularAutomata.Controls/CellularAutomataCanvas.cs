using System.Drawing;
using System.Windows.Forms;
using CellularAutomata.Drawing;
using CellularAutomata.Framework;

namespace CellularAutomata.Controls
{
	public partial class CellularAutomataCanvas : UserControl
	{
		private CAEnvironment _environment;

        internal CAEnvironment Environment
        { 
            get { return _environment; }
            set { _environment = value; }
        }

		private IDisplay _display;
		private CellularAutomataCanvasController _controller = new CellularAutomataCanvasController();
		private int _generation = 1;

		public CellularAutomataCanvas()
		{
			InitializeComponent();

		    automataSpace.AllowDrop = true;

			this.DoubleBuffered = true;

			speedControl.Minimum = 1;
			speedControl.Maximum = 500;
			speedControl.LargeChange = 100;
			speedControl.SmallChange = 10;
			speedControl.Value = 200;
			speedControl.AutoToolTip = true;
			speedControl.TrackBar.TickFrequency = 50;
			speedControl.ToolTipText = string.Format("{0}ms", speedControl.Value);
			speedValueLabel.Text = speedControl.ToolTipText;

			_display = new Monitor(10);

			Size trueSize = automataSpace.ClientSize;
			trueSize.Height /= _display.Ratio;
			trueSize.Width /= _display.Ratio;

			//_environment = new CAEnvironment(trueSize, false, "CellularAutomation", "BaseAutomation", new object[] { (byte) 1 });
			_environment = new CAEnvironment(trueSize, false, "GameOfLife", "Moore", null);

		    AttachEvents();
		}

        public void AttachEvents()
        {
            _environment.RaiseCellsCountUpdatedEvent += HandleCellsCountUpdatedEvent;
        }

        public void DetachEvents()
        {
            _environment.RaiseCellsCountUpdatedEvent -= HandleCellsCountUpdatedEvent;
        }

		public void Start()
		{
			timer.Start();
			startButton.Enabled = false;
			stopButton.Enabled = true;
		}

		public void Stop()
		{
			timer.Stop();
			stopButton.Enabled = false;
			startButton.Enabled = true;
		}

		public void Clear()
		{
			Stop();
			_environment.Clear();
			Refresh();
			_generation = 1;
			generation.Text = _generation.ToString();
			numberOfLiveCells.Text = "0";
		}

		private void controlStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			_controller.CreateCommand(e.ClickedItem.Tag.ToString(), this);
		}


		private void automataSpace_Resize(object sender, System.EventArgs e)
		{
			Size trueSize = automataSpace.ClientSize;
			trueSize.Height /= _display.Ratio;
			trueSize.Width /= _display.Ratio;

			_environment.Size = trueSize;
		}

		private void automataSpace_Paint(object sender, PaintEventArgs e)
		{
            _display.DrawGuides(new object[] { e.Graphics }, _environment);

			_display.DrawAutomata(new object[] { e.Graphics, Brushes.Black }, _environment);
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
			_environment.Enumerate();
			automataSpace.Refresh();
			_generation++;
			generation.Text = _generation.ToString();
		}

		private void HandleCellsCountUpdatedEvent(object sender, CellsCountUpdatedEventArgs e)
		{
			numberOfLiveCells.Text = e.Count.ToString();
			if (e.Count == 0)
			{
				Clear();
			}
		}

		private void speedControl_ValueChanged(object sender, System.EventArgs e)
		{
			timer.Interval = speedControl.Value;
			speedControl.ToolTipText = string.Format("{0}ms", speedControl.Value);
			speedValueLabel.Text = speedControl.ToolTipText;
		}


		private void DoSetState(MouseEventArgs e)
		{

			Point truePoint = e.Location;
			truePoint.X /= _display.Ratio;
			truePoint.Y /= _display.Ratio;

			if (_environment.IsInDisplay(truePoint))
			{
				_environment.ToggleCellState(truePoint);
				automataSpace.Refresh();
			}
		}

		private void automataSpace_MouseMove(object sender, MouseEventArgs e)
		{
			//if (e.Button == MouseButtons.Left)
			//{
			//    //TODO: Just draw do not togle the state
			//    DoDraw(e);
			//}
		}


		private void automataSpace_MouseDown(object sender, MouseEventArgs e)
		{
			DoSetState(e);
		}

		private void automataSpace_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				//TODO: Scan the canvas and set cell states depending on the drawing
			}
		}

		private void automataSpace_SizeChanged(object sender, System.EventArgs e)
		{
		}

        private void automataSpace_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void automataSpace_DragDrop(object sender, DragEventArgs e)
        {
            Pattern pattern = (Pattern) e.Data.GetData(typeof(Pattern));
            if (pattern != null)
            {
                Point point = automataSpace.PointToClient(new Point(e.X, e.Y));
                point.X /= _display.Ratio;
                point.Y /= _display.Ratio;
                _environment.DrawPattern(pattern, point);
                automataSpace.Refresh();
            }
        }
	}
}