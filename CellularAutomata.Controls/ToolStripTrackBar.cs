﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CellularAutomata.Controls
{
    [System.ComponentModel.DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(
        ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    public partial class ToolStripTrackBar : ToolStripControlHost
    {
    	private ToolTip _toolTip;

        public ToolStripTrackBar(): base(CreateControlInstance())
        {

        }

        /// <summary>
        /// Create a strongly typed property called TrackBar - handy to prevent casting everywhere.
        /// </summary>
        public TrackBar TrackBar
        {
            get { return Control as TrackBar; }
        }

        /// <summary>
        /// Create the actual control, note this is static so it can be called from the
        /// constructor.
        /// 
        /// </summary>
        /// <returns></returns>
        private static Control CreateControlInstance()
        {
            TrackBar t = new TrackBar();
            t.AutoSize = false;
            t.Height = 16;

            // Add other initialization code here.

			

            return t;
        }

        [DefaultValue(0)]
        public int Value
        {
            get { return TrackBar.Value; }
            set { TrackBar.Value = value; }
        }

        [DefaultValue(1000)]
        public int Maximum
        {
            get { return TrackBar.Maximum; }
            set { TrackBar.Maximum = value; }
        }

        [DefaultValue(1)]
        public int Minimum
        {
            get { return TrackBar.Minimum; }
            set { TrackBar.Minimum = value; }
        }

        [DefaultValue(1)]
        public int SmallChange
        {
            get { return TrackBar.SmallChange; }
            set { TrackBar.SmallChange = value; }
        }

        [DefaultValue(100)]
        public int LargeChange
        {
            get { return TrackBar.LargeChange; }
            set { TrackBar.LargeChange = value; }
        }

        /// <summary>
        /// Attach to events we want to re-wrap
        /// </summary>
        /// <param name="control"></param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            TrackBar trackBar = control as TrackBar;
            trackBar.ValueChanged += new EventHandler(trackBar_ValueChanged);
        }

        /// <summary>
        /// Detach from events.
        /// </summary>
        /// <param name="control"></param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            TrackBar trackBar = control as TrackBar;
            trackBar.ValueChanged -= new EventHandler(trackBar_ValueChanged);
        }


        /// <summary>
        /// Routing for event
        /// TrackBar.ValueChanged -> ToolStripTrackBar.ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            // when the trackbar value changes, fire an event.
            if (this.ValueChanged != null)
            {
                ValueChanged(sender, e);
            }
        }

        // add an event that is subscribable from the designer.
        public event EventHandler ValueChanged;


        // set other defaults that are interesting
        protected override Size DefaultSize
        {
            get { return new Size(200, 16); }
        }

		protected override bool DefaultAutoToolTip
		{
			get
			{
				return true;
			}
		}

 
    }
}