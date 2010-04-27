using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using CellularAutomata.Framework;

namespace CellularAutomata.Drawing
{
    public class Monitor : IDisplay, IDisposable
    {
        private static Bitmap gridBitmap;
        private static Size MaxSize = new Size(2000, 2000);

        public int Ratio { get; set; }

        private Monitor()
        {

        }

        /// <summary>
        /// Initializes a Monitor display with ratio.
        /// </summary>
        /// <param name="ratio">The <see cref="IDisplay.Ratio"/> property.</param>
        public Monitor(int ratio)
        {
            Ratio = ratio;
            gridBitmap = new Bitmap(MaxSize.Width, MaxSize.Height);
            InitGridBitmap();
        }

        #region IDisplay Members

        public void DrawGuides(object[] args, CAEnvironment environment)
        {
            Graphics g = (Graphics)args[0];
            g.DrawImageUnscaled(gridBitmap, 0, 0);
        }

        public void DrawAutomata(object[] args, CAEnvironment environment)
        {
            Graphics graphics = (Graphics)args[0];
            Brush brush = (Brush)args[1];

            int maxWidth = environment.Size.Width * Ratio;
			int maxHeight = environment.Size.Height * Ratio;

			Bitmap BackBuffer = new Bitmap(maxWidth, maxHeight);
			Graphics drawingArea = Graphics.FromImage(BackBuffer);  

            environment.Prepair();
            IEnumerator enumerator = environment.GetEnumerator();
            Point cell;

            while (enumerator.MoveNext())
            {
                cell = Utilities.GetCellFromKey((long) enumerator.Current);
                drawingArea.FillRectangle(brush, Ratio * cell.X, Ratio * cell.Y, Ratio, Ratio);
            }

            graphics.DrawImageUnscaled(BackBuffer, 0, 0);
            BackBuffer.Dispose();
        }

        #endregion

        private void InitGridBitmap()
        {
            Graphics drawingArea = Graphics.FromImage(gridBitmap);

            for (int i = 0; i < MaxSize.Width; i += Ratio)
            {
                var p = new Pen(new SolidBrush(Color.Gainsboro));
                drawingArea.DrawLine(p, i, 0, i, MaxSize.Height);

                for (int j = 0; j < MaxSize.Height; j += Ratio)
                {
                    drawingArea.DrawLine(p, 0, j, MaxSize.Width, j);
                }
            }

            drawingArea.DrawImageUnscaled(gridBitmap, 0, 0);
        }

        #region IDisposable Members

        public void Dispose()
        {
            gridBitmap.Dispose();
        }

        #endregion
    }
}